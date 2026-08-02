using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Api.Entity;
using FactStatus.Domain.Api.Value;

namespace FactStatus.Domain.Internal.Setup {
    public class FactStatusRepository : IFactStatusRepository {

        public IEntity? FindById(IdValue id) => throw new NotSupportedException();
        public bool HasById(IdValue id) => throw new NotSupportedException();
        public List<IEntity> GetEntityList(IdTypeEnum idType) => throw new NotSupportedException();
        public int EntityCount(IdTypeEnum idType) => throw new NotSupportedException();
        public int OKCount() => throw new NotSupportedException();
        public int NGCount() => throw new NotSupportedException();
        public List<IEntity> SearchByTitle(string title) => throw new NotSupportedException();
        public List<IEntity> SearchByText(string text) => throw new NotSupportedException();
        public IEntity AddEntity(AddValue addValue) => throw new NotSupportedException();
        public List<IEntity> AddByAddValueList(List<AddValue> addValueList) => throw new NotSupportedException();
        public void Move(PairIdValue pairId, bool only) => throw new NotSupportedException();
        public void MoveByPairIdValueList(List<PairIdValue> pairIds, bool only) => throw new NotSupportedException();
        public void Copy(PairIdValue pairId, bool only) => throw new NotSupportedException();
        public void CopyByPairIdValueList(List<PairIdValue> pairIds, BoolValue only) => throw new NotSupportedException();
        public void Delete(IdValue id, BoolValue only) => throw new NotSupportedException();
        public void DeleteByIdValueList(List<IdValue> ids, BoolValue only) => throw new NotSupportedException();
        public void UpdateByAttributeId() => throw new NotSupportedException();
        public void UpdateByAttributeIdList() => throw new NotSupportedException();
        public void AddByPairIdValue() => throw new NotSupportedException();
        public void AddByPairIdValueList() => throw new NotSupportedException();
        public void LoadJson(PathValue pathName) => throw new NotSupportedException();
        public void SaveJson(PathValue pathName) => throw new NotSupportedException();
        public void LoadXml(PathValue pathName) => throw new NotSupportedException();
        public void SaveXml(PathValue pathName) => throw new NotSupportedException();
        public void LoadMarkdown(PathValue pathName) => throw new NotSupportedException();
        public void LoadMarkdownEntitys(PathValue pathName) => throw new NotSupportedException();
        public void LoadMarkdownDocuments(PathValue pathName) => throw new NotSupportedException();
        public void SaveMarkdown(PathValue pathName) => throw new NotSupportedException();
        public void SaveMarkdownEntitys(PathValue pathName) => throw new NotSupportedException();
        public void SaveMarkdownDocuments(PathValue pathName) => throw new NotSupportedException();

        /// <summary>
        /// データベース型jsonファイルから内容を読み込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>RelationalDataDto</returns>
        public JsonDto LoadRelational(PathValue filePath) {
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(filePath.Path);

            // JsonTextをRelationalDataDtoに変換
            JsonDto? relationalDataDto = JsonSerializer.Deserialize<JsonDto>(jsonText);

            // RelationalDataDtoが空の場合の対処
            if (relationalDataDto == null) {
                return relationalDataDto!;
            }

            return relationalDataDto;
        }

        /// <summary>
        /// データベース型jsonファイルを書き出す
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="relationalDto"></param>
        public void SaveRelational(PathValue filePath, JsonDto relationalDto) {

            // 整形オプションを作成
            JsonSerializerOptions jsonSerializerOptions1 = new() {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var jsonSerializerOptions = jsonSerializerOptions1;

            // JSON文字列に変換
            string jsonText = JsonSerializer.Serialize(relationalDto, jsonSerializerOptions);

            // jsonファイルに書き出し
            File.WriteAllText(filePath.Path, jsonText);
        }

        /// <summary>
        /// IDパターン設定のjsonファイルを内容を読み込み
        /// </summary>
        /// <returns>IdPatternRulesDto</returns>
        public IdPatternRulesDto LoadIdPatternRules(PathValue filePath) {
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(filePath.Path);

            // JsonTextをRelationalDataDtoに変換
            IdPatternRulesDto? idPatternRulesDto = JsonSerializer.Deserialize<IdPatternRulesDto>(jsonText);

            // RelationalDataDtoが空の場合の対処
            if (idPatternRulesDto == null) {
                return idPatternRulesDto!;
            }

            return idPatternRulesDto;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusRepository() {
            // 処理なし
        }
    }
}
