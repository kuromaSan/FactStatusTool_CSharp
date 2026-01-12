using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Setup {
    /// <summary>
    /// 
    /// </summary>
    public class FactStatusBuilder {
        // フィールド
        private List<SubjectConfig> _subjectConfigList;
        private List<AchievementConfig> _achievementConfigList;
        private List<EvidenceConfig> _evidenceConfigList;
        private List<ResultConfig> _resultConfigList;
        private List<ArgumentConfig> _argumentConfigList;
        private List<AssertionConfig> _assertionConfigList;
        private List<RecordConfig> _recordConfigList;
        private List<TodoConfig> _todoConfigList;
        private List<SchemaConfig> _schemaConfigList;

        public FactStatusBuilder OfSubjectConfigList(List<SubjectConfig> value) {
            _subjectConfigList = value;
            return this;
        }

        public FactStatusBuilder OfAchievementConfigList(List<AchievementConfig> value) {
            _achievementConfigList = value;
            return this;
        }
        
        public FactStatusBuilder OfEvidenceConfigList(List<EvidenceConfig> value) {
            _evidenceConfigList = value;
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

        public FactStatusBuilder OfAssertionConfigList(List<AssertionConfig> value) {
            _assertionConfigList = value;
            return this;
        }

        public FactStatusBuilder OfRecordConfigList(List<RecordConfig> value) {
            _recordConfigList = value;
            return this;
        }

        public FactStatusBuilder OfTodoConfigList(List<TodoConfig> value) {
            _todoConfigList = value;
            return this;
        }

        public FactStatusBuilder OfSchemaConfigList(List<SchemaConfig> value) {
            _schemaConfigList = value;
            return this;
        }

        public FactStatusBuilder OfSubjectConfigList(List<SubjectJsonByRelationalDto> value) {
            foreach (SubjectJsonByRelationalDto projectDto in value) {
                var projectConfig = new SubjectConfig(
                    projectDto.Id,
                    projectDto.PathName,
                    projectDto.Title,
                    projectDto.Description);
                _subjectConfigList.Add(projectConfig);
            }
            return this;
        }

        public FactStatusBuilder OfAchievementConfigList(List<AchievementJsonByRelationalDto> value) {
            foreach (AchievementJsonByRelationalDto achievementDto in value) {
                var achievementConfig = new AchievementConfig(
                    achievementDto.ParentId,
                    achievementDto.Id,
                    achievementDto.PathName,
                    achievementDto.Title,
                    achievementDto.Description);
                _achievementConfigList.Add(achievementConfig);
            }
            return this;
        }

        public FactStatusBuilder OfEvidenceConfigList(List<EvidenceJsonByRelationalDto> value) {
            foreach (EvidenceJsonByRelationalDto evidenceDto in value) {
                var evidenceConfig = new EvidenceConfig(
                    evidenceDto.ParentId,
                    evidenceDto.Id,
                    evidenceDto.PathName,
                    evidenceDto.Title,
                    evidenceDto.Description);
                _evidenceConfigList.Add(evidenceConfig);
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
                    resultDto.Success switch { "1" => true, "0" => false, _ => throw new ArgumentException($"Invalid Success value: '{resultDto.Success}'") });
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
        public FactStatusBuilder OfAssertionConfigList(List<AssertionJsonByRelationalDto> value) {
            foreach (AssertionJsonByRelationalDto asssertionDto in value) {
                var assertionConfig = new AssertionConfig(
                    asssertionDto.ParentId,
                    asssertionDto.Id,
                    asssertionDto.Assert,
                    asssertionDto.Target,
                    asssertionDto.Type,
                    asssertionDto.Value);
                _assertionConfigList.Add(assertionConfig);
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
                    recordDto.Success switch { "1" => true, "0" => false, _ => throw new ArgumentException($"Invalid Success value: '{recordDto.Success}'") },
                    recordDto.Description);
                _recordConfigList.Add(recordConfig);
            }
            return this;
        }

        public FactStatusBuilder OfTodoConfigList(List<TodoJsonByRelationalDto> value) {
            foreach (TodoJsonByRelationalDto todoDto in value) {
                var todoConfig = new TodoConfig(
                    todoDto.ParentId,
                    todoDto.Id,
                    todoDto.PathName,
                    todoDto.Title,
                    todoDto.Description);
                _todoConfigList.Add(todoConfig);
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
                    schemaDto.Hypothesis,
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
        public FactStatusConfig Build() {
            return new FactStatusConfig(
                this._subjectConfigList,
                this._achievementConfigList,
                this._evidenceConfigList,
                this._resultConfigList,
                this._argumentConfigList,
                this._assertionConfigList,
                this._recordConfigList,
                this._todoConfigList,
                this._schemaConfigList);
        }

        static public FactStatusBuilder InitFactStatusBuilder() {
            var factStatusBuilder = new FactStatusBuilder();

            // 
            var subjectConfigList = new List<SubjectConfig> { 
                new SubjectConfig(
                    "00010001",
                    "Subject",
                    "主題名",
                    "")
            };
            factStatusBuilder.OfSubjectConfigList(subjectConfigList);

            // 
            var achievementConfigList = new List<AchievementConfig> {
                new AchievementConfig(
                    "00010001",
                    "00010002",
                    "Achievement",
                    "達成名",
                    "")
            };
            factStatusBuilder.OfAchievementConfigList(achievementConfigList);

            //
            var evidenceConfigList = new List<EvidenceConfig> {
                new EvidenceConfig(
                    "00010002",
                    "00010003",
                    "Evidence",
                    "証拠名",
                    "")
            };
            factStatusBuilder.OfEvidenceConfigList(evidenceConfigList);
            
            //
            var resultConfigList = new List<ResultConfig> {
                new ResultConfig(
                    "00010003",
                    "00010004",
                    "result",
                    "結果名",
                    true)
            };
            factStatusBuilder.OfResultConfigList(resultConfigList);
            
            //
            var argumentConfigList = new List<ArgumentConfig> {
                new ArgumentConfig(
                    "00010004",
                    "00010104",
                    "intKey",
                    "int",
                    "12")
            };
            factStatusBuilder.OfArgumentConfigList(argumentConfigList);

            //
            var assertionConfigList = new List<AssertionConfig> {
                new AssertionConfig(
                    "00010006",
                    "00010106",
                    "",
                    "",
                    "",
                    ""),
                new AssertionConfig(
                    "00010006",
                    "00020106",
                    "",
                    "",
                    "",
                    ""),
                new AssertionConfig(
                    "00010006",
                    "00030106",
                    "",
                    "",
                    "",
                    ""),
            };
            factStatusBuilder.OfAssertionConfigList(assertionConfigList);

            //
            var recordConfigList = new List<RecordConfig> {
                new RecordConfig(
                    "00010004",
                    "00010005",
                    "20001010101010",
                    "2000年10月10日10時10分10秒",
                    DateTime.ParseExact(
                        "2000-10-10 10:10:10",
                        "yyyy-MM-dd HH:mm:ss",
                        CultureInfo.InvariantCulture),
                    "確認者",
                    true,
                    "")
            };
            factStatusBuilder.OfRecordConfigList(recordConfigList);
            
            //
            var todoConfigList = new List<TodoConfig> {
                new TodoConfig(
                    "00010002",
                    "00010006",
                    "Process",
                    "手順名",
                    ""),
                new TodoConfig(
                    "00010003",
                    "00020006",
                    "Process",
                    "手順名",
                    ""),
            };
            factStatusBuilder.OfTodoConfigList(todoConfigList);

            // 
            var schemaConfigList = new List<SchemaConfig> {
                new SchemaConfig(
                    "00010001",
                    "00010007",
                    "Schema",
                    "構想名",
                    "体験内容",
                    "評価内容",
                    "仮説内容",
                    "抽象目標内容",
                    "具体目標内容"),
                new SchemaConfig(
                    "00010002",
                    "00020007",
                    "Schema",
                    "構想名",
                    "体験内容",
                    "評価内容",
                    "仮説内容",
                    "抽象目標内容",
                    "具体目標内容"),
            };
            factStatusBuilder.OfSchemaConfigList(schemaConfigList);

            return factStatusBuilder;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusBuilder() {
            this._subjectConfigList = new List<SubjectConfig>();
            this._achievementConfigList = new List<AchievementConfig>();
            this._evidenceConfigList = new List<EvidenceConfig>();
            this._resultConfigList = new List<ResultConfig>();
            this._argumentConfigList = new List<ArgumentConfig>();
            this._assertionConfigList = new List<AssertionConfig>();
            this._recordConfigList = new List<RecordConfig>();
            this._todoConfigList = new List<TodoConfig>();
            this._schemaConfigList = new List<SchemaConfig>();
        }
    }
}
