using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatusTool.Scripts.Logic;
using FactStatusTool.Scripts.Setup;
using FactStatusTool.Scripts.Value;

namespace FactStatusTool.Scripts.Main {
    public class FactStatusCrafter {
        private FactStatusPolicy _factStatusPolicy;
        private FactStatusBuilder _factStatusBuilder;
        private List<SubjectConfig> _subjectConfigList;
        private List<AchievementConfig> _achievementConfigList;
        private List<EvidenceConfig> _evidenceConfigList;
        private List<ResultConfig> _resultConfigList;
        private List<ArgumentConfig> _argumentConfigList;
        private List<AssertionConfig> _assertionConfigList;
        private List<RecordConfig> _recordConfigList;
        private List<TodoConfig> _todoConfigList;
        private List<SchemaConfig> _schemaConfigList;


        public void AddSubjectConfig(SubjectConfig value) {
            this._subjectConfigList.Add(value);
            this._factStatusBuilder.OfSubjectConfigList(this._subjectConfigList);
        }
        
        public void AddAchievementConfig(AchievementConfig value) {
            this._achievementConfigList.Add(value);
            this._factStatusBuilder.OfAchievementConfigList(this._achievementConfigList);
        }

        public void AddEvidenceConfig(EvidenceConfig value) {
            this._evidenceConfigList.Add(value);
            this._factStatusBuilder.OfEvidenceConfigList(this._evidenceConfigList);
        }

        public void AddResultConfig(ResultConfig value) {
            this._resultConfigList.Add(value);
            this._factStatusBuilder.OfResultConfigList(this._resultConfigList);
        }

        public void AddArgumentConfig(ArgumentConfig value) {
            this._argumentConfigList.Add(value);
            this._factStatusBuilder.OfArgumentConfigList(this._argumentConfigList);
        }
        public void AddAssertionConfig(AssertionConfig value) {
            this._assertionConfigList.Add(value);
            this._factStatusBuilder.OfAssertionConfigList(this._assertionConfigList);
        }

        public void AddRecordConfig(RecordConfig value) {
            this._recordConfigList.Add(value);
            this._factStatusBuilder.OfRecordConfigList(this._recordConfigList);
        }

        public void AddTodoConfig(TodoConfig value) {
            this._todoConfigList.Add(value);
            this._factStatusBuilder.OfAssertionConfigList(this._assertionConfigList);
        }


        public void AddSchemaConfig(SchemaConfig value) {
            this._schemaConfigList.Add(value);
            this._factStatusBuilder.OfSchemaConfigList(this._schemaConfigList);
        }

        /// <summary>
        /// FactStatusModelを生成
        /// </summary>
        /// <returns></returns>
        public FactStatus Build() {
            FactStatusConfig factStatusConfig = this._factStatusBuilder.Build();
            return new FactStatus(
                factStatusConfig,
                this._factStatusPolicy);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusCrafter() {
            // FactStatusPolicyの生成
            var jsonRepository = new JsonRepository();
            var markdownRepository = new MarkdownRepository();
            var factStatusStrategy = new FactStatusStrategy(jsonRepository, markdownRepository);
            this._factStatusPolicy = new FactStatusPolicy(factStatusStrategy);

            // FactStatusBuilderの生成
            this._factStatusBuilder = new FactStatusBuilder();

            // ConfigListの生成
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
