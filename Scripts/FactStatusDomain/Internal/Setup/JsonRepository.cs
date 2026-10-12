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
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Setup {
    public class JsonRepository {

        /// <summary>
        /// データベース型jsonファイルから内容を読み込み
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <returns>RelationalDataDto</returns>
        public FactStatusDomainDao LoadJson(PathValue jsonFilePath) {
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(jsonFilePath.Path);

            // JsonTextをRelationalDataDtoに変換
            FactStatusDomainDao? relationalDataDto = JsonSerializer.Deserialize<FactStatusDomainDao>(jsonText);

            // RelationalDataDtoが空の場合の対処
            if (relationalDataDto == null) {
                return relationalDataDto!;
            }

            return relationalDataDto;
        }

        /// <summary>
        /// データベース型jsonファイルを書き出す
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="jsonDto"></param>
        public void SaveJson(PathValue jsonFilePath, FactStatusDomainDao jsonDto) {

            // 整形オプションを作成
            JsonSerializerOptions jsonSerializerOptions1 = new() {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var jsonSerializerOptions = jsonSerializerOptions1;

            // JSON文字列に変換
            string jsonText = JsonSerializer.Serialize(jsonDto, jsonSerializerOptions);

            // jsonファイルに書き出し
            File.WriteAllText(jsonFilePath.Path, jsonText);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JsonRepository() {

            // 処理なし
        }
    }
}
