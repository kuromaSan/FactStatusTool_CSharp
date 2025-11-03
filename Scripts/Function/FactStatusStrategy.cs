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

        public object SelectConfigById(FactStatusConfig documentConfig, string ducumentId) {

            // Idを"'0000','00','00'"で区切る

            // タイプを選択
            switch (ducumentId) {
                case "01":

                    break;
                case "02":
                    break;
            }

            // タイプ一覧から同じIDを取得

            return new object();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusConfig LoadJsonByRelational(string filePath) {
            // jsonファイルを読み込み
            JsonByRelationalDto relationalDataDto = this._JsonRepository.LoadJsonByRelational(filePath);

            // DocumentConfigに変換
            var documentBuilder = new FactStatusBuilder();
            documentBuilder.OfSubjectConfigList(relationalDataDto.Subjects);
            documentBuilder.OfTodoConfigList(relationalDataDto.Todos);
            documentBuilder.OfEvidenceConfigList(relationalDataDto.Evidences);
            documentBuilder.OfResultConfigList(relationalDataDto.Results);
            documentBuilder.OfArgumentConfigList(relationalDataDto.Arguments);
            documentBuilder.OfRecordConfigList(relationalDataDto.Records);
            documentBuilder.OfProcessConfigList(relationalDataDto.Processs);
            documentBuilder.OfStepConfigList(relationalDataDto.Steps);
            documentBuilder.OfSchemaConfigList(relationalDataDto.Schemas);
            FactStatusConfig documentConfig = documentBuilder.Build();

            return documentConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="documentConfig"></param>
        public void SaveJsonByRelational(string filePath, FactStatusConfig documentConfig) {
            // DocumentConfigをRelationalDataDtoに変換
            var jsonByRelationalDtoBuilder = new JsonByRelationalDtoBuilder();
            jsonByRelationalDtoBuilder.OfSubjects(documentConfig.SubjectConfigList);
            jsonByRelationalDtoBuilder.OfTodos(documentConfig.TodoConfigList);
            jsonByRelationalDtoBuilder.OfEvidences(documentConfig.EvidenceConfigList);
            jsonByRelationalDtoBuilder.OfResults(documentConfig.ResultConfigList);
            jsonByRelationalDtoBuilder.OfArguments(documentConfig.ArgumentConfigList);
            jsonByRelationalDtoBuilder.OfRecords(documentConfig.RecordConfigList);
            jsonByRelationalDtoBuilder.OfProcess(documentConfig.ProcessConfigList);
            jsonByRelationalDtoBuilder.OfSteps(documentConfig.StepConfigList);
            jsonByRelationalDtoBuilder.OfSchemas(documentConfig.SchemaConfigList);
            JsonByRelationalDto jsonByRelationalDto = jsonByRelationalDtoBuilder.Build();
            // jsonファイルを保存
            this._JsonRepository.SaveJsonByRelational(filePath, jsonByRelationalDto);
        }

        public FactStatusStrategy(
            JsonRepository jsonRepository,
            MarkdownRepository markdownRepository) {

            this._JsonRepository = jsonRepository;
            this._MarkdownRepository = markdownRepository;
        }
    }
}
