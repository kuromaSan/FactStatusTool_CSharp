using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Setup {
    public class FactStatusRepository : IFactStatusRepository {

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
