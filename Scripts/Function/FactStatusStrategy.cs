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

        public object SelectConfigById(FacutStatusConfig documentConfig, string ducumentId) {

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

        public FacutStatusConfig LoadJsonByRelational(string filePath) {
            // jsonファイルを読み込み
            JsonByRelationalDto relationalDataDto = this._JsonRepository.LoadJsonByRelational(filePath);

            // DocumentConfigに変換
            var documentBuilder = new FactStatusBuilder();
            documentBuilder.OfProjectConfigList(relationalDataDto.Subjects);
            documentBuilder.OfTodoConfigList(relationalDataDto.Todos);
            documentBuilder.OfValidateConfigList(relationalDataDto.Validates);
            documentBuilder.OfResultConfigList(relationalDataDto.Results);
            documentBuilder.OfArgumentConfigList(relationalDataDto.Arguments);
            documentBuilder.OfRecordConfigList(relationalDataDto.Records);
            documentBuilder.OfProcessConfigList(relationalDataDto.Processs);
            documentBuilder.OfStepConfigList(relationalDataDto.Steps);
            documentBuilder.OfSchemaConfigList(relationalDataDto.Schemas);
            documentBuilder.OfExceptionConfigList(relationalDataDto.Exceptions);
            FacutStatusConfig documentConfig = documentBuilder.Build();

            return documentConfig;
        }

        public void SaveJsonByRelational(string filePath, FacutStatusConfig documentConfig) {
            // DocumentConfigをRelationalDataDtoに変換
            var jsonByRelationalDtoBuilder = new JsonByRelationalDtoBuilder();
            jsonByRelationalDtoBuilder.OfSubjects(documentConfig.SubjectConfigList);
            jsonByRelationalDtoBuilder.OfTodos(documentConfig.TodoConfigList);
            jsonByRelationalDtoBuilder.OfValidates(documentConfig.ValidateConfigList);
            jsonByRelationalDtoBuilder.OfResults(documentConfig.ResultConfigList);
            jsonByRelationalDtoBuilder.OfArguments(documentConfig.ArgumentConfigList);
            jsonByRelationalDtoBuilder.OfRecords(documentConfig.RecordConfigList);
            jsonByRelationalDtoBuilder.OfProcess(documentConfig.ProcessConfigList);
            jsonByRelationalDtoBuilder.OfSteps(documentConfig.StepConfigList);
            jsonByRelationalDtoBuilder.OfSchemas(documentConfig.SchemaConfigList);
            jsonByRelationalDtoBuilder.OfExceptions(documentConfig.ExceptionConfigList);
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
