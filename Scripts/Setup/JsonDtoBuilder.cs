using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Setup {
    public class JsonByRelationalDtoBuilder {
        private List<SubjectJsonByRelationalDto> _subjects;
        private List<AchievementJsonByRelationalDto> _achievements;
        private List<EvidenceJsonByRelationalDto> _evidences;
        private List<ResultJsonByRelationalDto> _results;
        private List<ArgumentJsonByRelationalDto> _arguments;
        private List<AssertionJsonByRelationalDto> _assertions;
        private List<RecordJsonByRelationalDto> _records;
        private List<TodoJsonByRelationalDto> _todos;
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

        public JsonByRelationalDtoBuilder OfAchievements(List<AchievementConfig> value) {
            foreach (AchievementConfig achievementConfig in value) {
                AchievementJsonByRelationalDto achievementDto = new() {
                    ParentId = achievementConfig.ParentId,
                    Id = achievementConfig.Id,
                    PathName = achievementConfig.PathName,
                    Title = achievementConfig.Title,
                    Description = achievementConfig.Description
                };
                _achievements.Add(achievementDto);
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
                    Success = resultConfig.Success switch { true => "1", false => "0"},
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
                    Success = recordConfig.Success switch { true => "1", false => "0"},
                    Description = recordConfig.Description
                };
                _records.Add(recordDto);
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
                    AbstractionGoal = schemaConfig.AbstractionGoal,
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

        public JsonByRelationalDtoBuilder OfAssertions(List<AssertionConfig> value) {
            foreach (AssertionConfig assertionConfig in value) {
                AssertionJsonByRelationalDto assertionDto = new() {
                    ParentId = assertionConfig.ParentId,
                    Id = assertionConfig.Id,
                    Assert = assertionConfig.Assert,
                    Target = assertionConfig.Target,
                    Type = assertionConfig.Type,
                    Value = assertionConfig.Value
                };
                _assertions.Add(assertionDto);
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
                Achievements = _achievements,
                Evidences = _evidences,
                Results = _results,
                Records = _records,
                Todos = _todos,
                Schemas = _schemas,
                Arguments = _arguments,
                Assertions = _assertions
            };
            return jsonByRelationalDto;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JsonByRelationalDtoBuilder() {
            this._subjects = new List<SubjectJsonByRelationalDto>();
            this._achievements = new List<AchievementJsonByRelationalDto>();
            this._evidences = new List<EvidenceJsonByRelationalDto>();
            this._results = new List<ResultJsonByRelationalDto>();
            this._arguments = new List<ArgumentJsonByRelationalDto>();
            this._assertions = new List<AssertionJsonByRelationalDto>();
            this._records = new List<RecordJsonByRelationalDto>();
            this._todos = new List<TodoJsonByRelationalDto>();
            this._schemas = new List<SchemaJsonByRelationalDto>();
        }
    }
}
