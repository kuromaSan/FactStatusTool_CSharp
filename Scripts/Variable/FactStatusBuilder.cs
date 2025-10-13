using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
    /// <summary>
    /// 
    /// </summary>
    public class FactStatusBuilder {
        // フィールド
        private List<SubjectConfig> _projectConfigList;
        private List<TodoConfig> _todoConfigList;
        private List<ValidateConfig> _validateConfigList;
        private List<ResultConfig> _resultConfigList;
        private List<ArgumentConfig> _argumentConfigList;
        private List<RecordConfig> _recordConfigList;
        private List<ProcessConfig> _processConfigList;
        private List<StepConfig> _stepConfigList;
        private List<SchemaConfig> _schemaConfigList;

        public FactStatusBuilder OfProjectConfigList(List<SubjectConfig> value) {
            _projectConfigList = value;
            return this;
        }

        public FactStatusBuilder OfTodoConfigList(List<TodoConfig> value) {
            _todoConfigList = value;
            return this;
        }
        
        public FactStatusBuilder OfValidateConfigList(List<ValidateConfig> value) {
            _validateConfigList = value;
            return this;
        }

        public FactStatusBuilder OfResultConfigList(List<ResultConfig> value) {
            _resultConfigList = value;
            return this;
        }

        public FactStatusBuilder OfArgumentConfigList(List<ArgumentConfig> value) {
            _argumentConfigList = value;
            return this;
        }

        public FactStatusBuilder OfRecordConfigList(List<RecordConfig> value) {
            _recordConfigList = value;
            return this;
        }

        public FactStatusBuilder OfProcessConfigList(List<ProcessConfig> value) {
            _processConfigList = value;
            return this;
        }

        public FactStatusBuilder OfStepConfigList(List<StepConfig> value) {
            _stepConfigList = value;
            return this;
        }

        public FactStatusBuilder OfSchemaConfigList(List<SchemaConfig> value) {
            _schemaConfigList = value;
            return this;
        }

        public FactStatusBuilder OfProjectConfigList(List<SubjectJsonByRelationalDto> value) {
            foreach (SubjectJsonByRelationalDto projectDto in value) {
                SubjectConfig projectConfig = new SubjectConfig(
                    projectDto.Id,
                    projectDto.PathName,
                    projectDto.Title,
                    projectDto.Description);
                _projectConfigList.Add(projectConfig);
            }
            return this;
        }

        public FactStatusBuilder OfTodoConfigList(List<TodoJsonByRelationalDto> value) {
            foreach (TodoJsonByRelationalDto todoDto in value) {
                TodoConfig todoConfig = new TodoConfig(
                    todoDto.ParentId,
                    todoDto.Id,
                    todoDto.PathName,
                    todoDto.Title,
                    todoDto.Description);
                _todoConfigList.Add(todoConfig);
            }
            return this;
        }

        public FactStatusBuilder OfValidateConfigList(List<ValidateJsonByRelationalDto> value) {
            foreach (ValidateJsonByRelationalDto validateDto in value) {
                ValidateConfig validateConfig = new ValidateConfig(
                    validateDto.ParentId,
                    validateDto.Id,
                    validateDto.PathName,
                    validateDto.Title,
                    validateDto.Description);
                _validateConfigList.Add(validateConfig);
            }
            return this;
        }

        public FactStatusBuilder OfResultConfigList(List<ResultJsonByRelationalDto> value) {
            foreach (ResultJsonByRelationalDto resultDto in value) {
                ResultConfig resultConfig = new ResultConfig(
                    resultDto.ParentId,
                    resultDto.Id,
                    resultDto.PathName,
                    resultDto.Title,
                    resultDto.Success,
                    resultDto.ExpectedValue,
                    resultDto.ExpectedType,
                    resultDto.ExceptionType);
                _resultConfigList.Add(resultConfig);
            }
            return this;
        }

        public FactStatusBuilder OfArgumentConfigList(List<ArgumentJsonByRelationalDto> value) {
            foreach (ArgumentJsonByRelationalDto argumentDto in value) {
                ArgumentConfig argumentConfig = new ArgumentConfig(
                    argumentDto.ParentId,
                    argumentDto.Id,
                    argumentDto.Key,
                    argumentDto.Type,
                    argumentDto.Value);
                _argumentConfigList.Add(argumentConfig);
            }
            return this;
        }

        public FactStatusBuilder OfRecordConfigList(List<RecordJsonByRelationalDto> value) {
            foreach (RecordJsonByRelationalDto recordDto in value) {
                RecordConfig recordConfig = new RecordConfig(
                    recordDto.ParentId,
                    recordDto.Id,
                    recordDto.PathName,
                    recordDto.Title,
                    DateTime.ParseExact(recordDto.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    recordDto.Reviewer,
                    recordDto.Success,
                    recordDto.ExpectedValue,
                    recordDto.ExpectedType,
                    recordDto.ExceptionType,
                    recordDto.Message);
                _recordConfigList.Add(recordConfig);
            }
            return this;
        }

        public FactStatusBuilder OfProcessConfigList(List<ProcessJsonByRelationalDto> value) {
            foreach (ProcessJsonByRelationalDto processDto in value) {
                ProcessConfig processConfig = new ProcessConfig(
                    processDto.ParentId,
                    processDto.Id,
                    processDto.PathName,
                    processDto.Title);
                _processConfigList.Add(processConfig);
            }
            return this;
        }

        public FactStatusBuilder OfStepConfigList(List<StepJsonByRelationalDto> value) {
            foreach (StepJsonByRelationalDto stepDto in value) {
                StepConfig stepConfig = new StepConfig(
                    stepDto.ParentId,
                    stepDto.Id,
                    stepDto.Value);
                _stepConfigList.Add(stepConfig);
            }
            return this;
        }

        public FactStatusBuilder OfSchemaConfigList(List<SchemaJsonByRelationalDto> value) {
            // SchemaConfigに変換して追加
            foreach (SchemaJsonByRelationalDto schemaDto in value) {
                SchemaConfig schemaConfig = new SchemaConfig(
                    schemaDto.ParentId,
                    schemaDto.Id,
                    schemaDto.PathName,
                    schemaDto.Title,
                    schemaDto.Experience,
                    schemaDto.Evaluation,
                    schemaDto.Abduction,
                    schemaDto.AbstractionGoal,
                    schemaDto.ExecutionGoal);
                _schemaConfigList.Add(schemaConfig);
            }
            return this;
        }

        /// <summary>
        /// DocumentConfigの生成
        /// </summary>
        /// <returns></returns>
        public FacutStatusConfig Build() {
            return new FacutStatusConfig(
                this._projectConfigList,
                this._todoConfigList,
                this._validateConfigList,
                this._resultConfigList,
                this._argumentConfigList,
                this._recordConfigList,
                this._processConfigList,
                this._stepConfigList,
                this._schemaConfigList);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusBuilder() {
            this._projectConfigList = new List<SubjectConfig>();
            this._todoConfigList = new List<TodoConfig>();
            this._validateConfigList = new List<ValidateConfig>();
            this._resultConfigList = new List<ResultConfig>();
            this._argumentConfigList = new List<ArgumentConfig>();
            this._recordConfigList = new List<RecordConfig>();
            this._processConfigList = new List<ProcessConfig>();
            this._stepConfigList = new List<StepConfig>();
            this._schemaConfigList = new List<SchemaConfig>();
        }
    }
}
