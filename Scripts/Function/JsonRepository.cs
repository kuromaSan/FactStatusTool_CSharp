using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Function {
    public class JsonRepository {
        /// <summary>
        /// 階層型jsonファイルから内容を読み込み
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <returns>TreeDataDto</returns>
        public JsonByRelationalDto LoadJsonByTree(string jsonFilePath){
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(jsonFilePath);

            // JsonTextをTreeDataDtoに変換
            JsonByRelationalDto? relationalDataDto = JsonSerializer.Deserialize<JsonByRelationalDto>(jsonText);

            // TreeDataDtoが空の場合の対処
            if (relationalDataDto == null) {
                return relationalDataDto!;
            }

            return relationalDataDto;
        }

        /// <summary>
        /// データベース型jsonファイルから内容を読み込み
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <returns>RelationalDataDto</returns>
        public JsonByRelationalDto LoadJsonByRelational(string jsonFilePath){
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(jsonFilePath);

            // JsonTextをRelationalDataDtoに変換
            JsonByRelationalDto? relationalDataDto = JsonSerializer.Deserialize<JsonByRelationalDto>(jsonText);

            // RelationalDataDtoが空の場合の対処
            if (relationalDataDto == null) {
                return relationalDataDto!;
            }

            return relationalDataDto;
        }

        /// <summary>
        /// 階層型jsonファイルを書き出す
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="jsonNode"></param>
        public void SaveJsonByTree(string jsonFilePath, JsonNode jsonNode){
            // 整形オプションを作成
            var options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            // jsonファイルに書き出し
            File.WriteAllText(jsonFilePath, jsonNode.ToJsonString(options));
        }

        /// <summary>
        /// データベース型jsonファイルを書き出す
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="jsonNode"></param>
        public void SaveJsonByRelational(string jsonFilePath, JsonByRelationalDto jsonByRelationalDto) {

            // 整形オプションを作成
            JsonSerializerOptions jsonSerializerOptions1 = new() {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var jsonSerializerOptions = jsonSerializerOptions1;

            // JSON文字列に変換
            string jsonText = JsonSerializer.Serialize(jsonByRelationalDto, jsonSerializerOptions);

            // jsonファイルに書き出し
            File.WriteAllText(jsonFilePath, jsonText);
        }

        /// <summary>
        /// IDパターン設定のjsonファイルを内容を読み込み
        /// </summary>
        /// <returns>IdPatternRulesDto</returns>
        public IdPatternRulesDto LoadJsonByIdPatternRules(string jsonFilePath) {
            // ファイルパスからテキストに変換
            string jsonText = File.ReadAllText(jsonFilePath);

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
        public JsonRepository() {
            // 処理なし
        }
    }
}
