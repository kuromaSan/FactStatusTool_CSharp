using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Function {
    public class FactStatusStrategy {
        private readonly JsonRepository _JsonRepository;
        private readonly MarkdownRepository _MarkdownRepository;

        /// <summary>
        /// IDから設定を検索
        /// </summary>
        /// <param name="factStatusConfig"></param>
        /// <param name="configId"></param>
        /// <returns>一致したConfig。見つからない場合はnull</returns>
        public object? SearchConfig(
            FactStatusConfig factStatusConfig,
            string configId) {
            
            return this.SelectConfigById(factStatusConfig, configId);
        }

        /// <summary>
        /// IDの末尾2桁でタイプを判定して、対応するConfigを返す
        /// </summary>
        /// <param name="factStatusConfig"></param>
        /// <param name="configId"></param>
        /// <returns>一致したConfig。見つからない場合はnull</returns>
        public object? SelectConfigById(
            FactStatusConfig factStatusConfig,
            string configId){

            var (registrationId, propertyClassType) = this.SplitConfigId(configId);

            // タイプを選択し、各リストから同じIDの要素を取得
            return propertyClassType switch {
                "0001" => factStatusConfig.SubjectConfigList?.FirstOrDefault(x => x.Id == configId),
                "0002" => factStatusConfig.TodoConfigList?.FirstOrDefault(x => x.Id == configId),
                "0003" => factStatusConfig.EvidenceConfigList?.FirstOrDefault(x => x.Id == configId),
                "0004" => factStatusConfig.ResultConfigList?.FirstOrDefault(x => x.Id == configId),
                "0104" => factStatusConfig.ArgumentConfigList?.FirstOrDefault(x => x.Id == configId),
                "0005" => factStatusConfig.RecordConfigList?.FirstOrDefault(x => x.Id == configId),
                "0006" => factStatusConfig.ProcessConfigList?.FirstOrDefault(x => x.Id == configId),
                "0106" => factStatusConfig.StepConfigList?.FirstOrDefault(x => x.Id == configId),
                "0007" => factStatusConfig.SchemaConfigList?.FirstOrDefault(x => x.Id == configId),
                _ => throw new Exception($"IDの形式が不正です。ID:{configId}")
            };
        }

        /// <summary>
        /// データベース型JSONファイルを読み込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusConfig LoadJsonByRelational(string filePath) {
            // jsonファイルを読み込み
            JsonByRelationalDto relationalDataDto = this._JsonRepository.LoadJsonByRelational(filePath);

            // factStatusConfigに変換
            var factStatusBuilder = new FactStatusBuilder();
            factStatusBuilder.OfSubjectConfigList(relationalDataDto.Subjects);
            factStatusBuilder.OfTodoConfigList(relationalDataDto.Todos);
            factStatusBuilder.OfEvidenceConfigList(relationalDataDto.Evidences);
            factStatusBuilder.OfResultConfigList(relationalDataDto.Results);
            factStatusBuilder.OfArgumentConfigList(relationalDataDto.Arguments);
            factStatusBuilder.OfRecordConfigList(relationalDataDto.Records);
            factStatusBuilder.OfProcessConfigList(relationalDataDto.Processs);
            factStatusBuilder.OfStepConfigList(relationalDataDto.Steps);
            factStatusBuilder.OfSchemaConfigList(relationalDataDto.Schemas);
            FactStatusConfig factStatusConfig = factStatusBuilder.Build();

            return factStatusConfig;
        }

        /// <summary>
        /// データベース型JSONファイルを保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="factStatusConfig"></param>
        public void SaveJsonByRelational(string filePath, FactStatusConfig factStatusConfig) {
            // factStatusConfigをRelationalDataDtoに変換
            var jsonByRelationalDtoBuilder = new JsonByRelationalDtoBuilder();
            jsonByRelationalDtoBuilder.OfSubjects(factStatusConfig.SubjectConfigList);
            jsonByRelationalDtoBuilder.OfTodos(factStatusConfig.TodoConfigList);
            jsonByRelationalDtoBuilder.OfEvidences(factStatusConfig.EvidenceConfigList);
            jsonByRelationalDtoBuilder.OfResults(factStatusConfig.ResultConfigList);
            jsonByRelationalDtoBuilder.OfArguments(factStatusConfig.ArgumentConfigList);
            jsonByRelationalDtoBuilder.OfRecords(factStatusConfig.RecordConfigList);
            jsonByRelationalDtoBuilder.OfProcess(factStatusConfig.ProcessConfigList);
            jsonByRelationalDtoBuilder.OfSteps(factStatusConfig.StepConfigList);
            jsonByRelationalDtoBuilder.OfSchemas(factStatusConfig.SchemaConfigList);
            JsonByRelationalDto jsonByRelationalDto = jsonByRelationalDtoBuilder.Build();

            // jsonファイルを保存
            this._JsonRepository.SaveJsonByRelational(filePath, jsonByRelationalDto);
        }

        /// <summary>
        /// 指定したIDを '登録番号',('プロパティ番号','クラス番号') の2つに分割する。
        /// 例: "00010203" -> ("0001","0203")
        /// 仕様:
        /// - 末尾4桁をクラス番号として取り出す
        /// - 残りを登録番号として取り出す（可変長。先頭の0は保持）
        /// </summary>
        /// <param name="configId">分割するID</param>
        /// <returns>(registrationId, propertyClassType)</returns>
        /// <exception cref="ArgumentException">IDがnull/空、もしくは長さが4未満の場合</exception>
        private (string registrationId, string propertyClassType) SplitConfigId(string configId) {
            if (string.IsNullOrWhiteSpace(configId) || configId.Length < 4) {
                throw new ArgumentException($"IDの形式が不正です。少なくとも'登録番号(1桁以上) + プロパティ2桁 + クラス2桁'が必要です。ID:{configId}");
            }

            // プロパティ番号&クラス番号: 末尾4桁
            string propertyClassType = configId[^4..];

            // 登録番号: 残り（可変長、先頭の0を保持）
            string registrationId = configId.Substring(0, configId.Length - 4);

            return (registrationId, propertyClassType);
        }

        public FactStatusStrategy(
            JsonRepository jsonRepository,
            MarkdownRepository markdownRepository) {

            this._JsonRepository = jsonRepository;
            this._MarkdownRepository = markdownRepository;
        }
    }
}
