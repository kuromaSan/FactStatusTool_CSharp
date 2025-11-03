using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
    public class JsonByRelationalDtoBuilder {
        private List<SubjectJsonByRelationalDto> _subjects;
        private List<TodoJsonByRelationalDto> _todos;
        private List<EvidenceJsonByRelationalDto> _evidences;
        private List<ResultJsonByRelationalDto> _results;
        private List<ArgumentJsonByRelationalDto> _arguments;
        private List<RecordJsonByRelationalDto> _records;
        private List<ProcessJsonByRelationalDto> _processs;
        private List<StepJsonByRelationalDto> _steps;
        private List<SchemaJsonByRelationalDto> _schemas;

        public JsonByRelationalDtoBuilder OfSubjects(List<SubjectConfig> value) {
            foreach (SubjectConfig subjectConfig in value) {
                SubjectJsonByRelationalDto subjectDto = new() {
                    Id = subjectConfig.Id,
                    PathName = subjectConfig.PathName,
                    Title = subjectConfig.Title,
                    Description = subjectConfig.Description
                };
                _subjects.Add(subjectDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfTodos(List<TodoConfig> value) {
            foreach (TodoConfig todoConfig in value) {
                TodoJsonByRelationalDto todoDto = new() {
                    ParentId = todoConfig.ParentId,
                    Id = todoConfig.Id,
                    PathName = todoConfig.PathName,
                    Title = todoConfig.Title,
                    Description = todoConfig.Description
                };
                _todos.Add(todoDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfEvidences(List<EvidenceConfig> value) {
            foreach (EvidenceConfig evidenceConfig in value) {
                EvidenceJsonByRelationalDto evidenceDto = new() {
                    ParentId = evidenceConfig.ParentId,
                    Id = evidenceConfig.Id,
                    PathName = evidenceConfig.PathName,
                    Title = evidenceConfig.Title,
                    Description = evidenceConfig.Description
                };
                _evidences.Add(evidenceDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfResults(List<ResultConfig> value) {
            foreach (ResultConfig resultConfig in value) {
                ResultJsonByRelationalDto resultDto = new() {
                    ParentId = resultConfig.ParentId,
                    Id = resultConfig.Id,
                    PathName = resultConfig.PathName,
                    Title = resultConfig.Title,
                    Success = resultConfig.Success,
                    ExpectedValue = resultConfig.ExpectedValue,
                    ExpectedType = resultConfig.ExpectedType,
                    ExceptionType = resultConfig.ExceptionType
                };
                _results.Add(resultDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfRecords(List<RecordConfig> value) {
            foreach (RecordConfig recordConfig in value) {
                RecordJsonByRelationalDto recordDto = new() {
                    ParentId = recordConfig.ParentId,
                    Id = recordConfig.Id,
                    PathName = recordConfig.PathName,
                    Title = recordConfig.Title,
                    Date = recordConfig.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    Reviewer = recordConfig.Reviewer,
                    Success = recordConfig.Success,
                    ExpectedValue = recordConfig.ExpectedValue,
                    ExpectedType = recordConfig.ExpectedType,
                    ExceptionType = recordConfig.ExceptionType,
                    Message = recordConfig.Message
                };
                _records.Add(recordDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfProcess(List<ProcessConfig> value) {
            foreach (ProcessConfig processConfig in value) {
                ProcessJsonByRelationalDto processDto = new() {
                    ParentId = processConfig.ParentId,
                    Id = processConfig.Id,
                    PathName = processConfig.PathName,
                    Title = processConfig.Title
                };
                _processs.Add(processDto);
            }
            return this;
        }


        public JsonByRelationalDtoBuilder OfSchemas(List<SchemaConfig> value) {
            // SchemaConfigに変換して追加
            foreach (SchemaConfig schemaConfig in value) {
                SchemaJsonByRelationalDto schemaDto = new() {
                    ParentId = schemaConfig.ParentId,
                    Id = schemaConfig.Id,
                    PathName = schemaConfig.PathName,
                    Title = schemaConfig.Title,
                    Experience = schemaConfig.Experience,
                    Evaluation = schemaConfig.Evaluation,
                    Hypothesis = schemaConfig.Hypothesis,
                    AbstractionGoal = schemaConfig.AbstractGoal,
                    ExecutionGoal = schemaConfig.ExecutionGoal
                };
                _schemas.Add(schemaDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfArguments(List<ArgumentConfig> value) {
            foreach (ArgumentConfig argumentConfig in value) {
                ArgumentJsonByRelationalDto argumentDto = new() {
                    ParentId = argumentConfig.ParentId,
                    Id = argumentConfig.Id,
                    Key = argumentConfig.Key,
                    Type = argumentConfig.Type,
                    Value = argumentConfig.Value
                };
                _arguments.Add(argumentDto);
            }
            return this;
        }

        public JsonByRelationalDtoBuilder OfSteps(List<StepConfig> value) {
            foreach (StepConfig stepConfig in value) {
                StepJsonByRelationalDto stepDto = new() {
                    ParentId = stepConfig.ParentId,
                    Id = stepConfig.Id,
                    Value = stepConfig.Value
                };
                _steps.Add(stepDto);
            }
            return this;
        }

        /// <summary>
        /// JsonByRelationalDtoの生成
        /// </summary>
        /// <returns></returns>
        public JsonByRelationalDto Build() {
            JsonByRelationalDto jsonByRelationalDto = new() {
                Subjects = _subjects,
                Todos = _todos,
                Evidences = _evidences,
                Results = _results,
                Records = _records,
                Processs = _processs,
                Schemas = _schemas,
                Arguments = _arguments,
                Steps = _steps
            };
            return jsonByRelationalDto;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JsonByRelationalDtoBuilder() {
            this._subjects = new List<SubjectJsonByRelationalDto>();
            this._todos = new List<TodoJsonByRelationalDto>();
            this._evidences = new List<EvidenceJsonByRelationalDto>();
            this._results = new List<ResultJsonByRelationalDto>();
            this._arguments = new List<ArgumentJsonByRelationalDto>();
            this._records = new List<RecordJsonByRelationalDto>();
            this._processs = new List<ProcessJsonByRelationalDto>();
            this._steps = new List<StepJsonByRelationalDto>();
            this._schemas = new List<SchemaJsonByRelationalDto>();
        }
    }
}
