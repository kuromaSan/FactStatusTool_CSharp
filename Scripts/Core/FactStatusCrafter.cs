using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatusTool.Scripts.Variable;
using FactStatusTool.Scripts.Function;

namespace FactStatusTool.Scripts.Core {
    public class FactStatusCrafter {
        private FactStatusPolicy _factStatusPolicy;
        private FactStatusBuilder _factStatusBuilder;
        private List<SubjectConfig> _subjectConfigList;
        private List<TodoConfig> _todoConfigList;
        private List<EvidenceConfig> _evidenceConfigList;
        private List<ResultConfig> _resultConfigList;
        private List<ArgumentConfig> _argumentConfigList;
        private List<RecordConfig> _recordConfigList;
        private List<ProcessConfig> _processConfigList;
        private List<StepConfig> _stepConfigList;
        private List<SchemaConfig> _schemaConfigList;


        public void addSubjectConfig(SubjectConfig value) {
            this._subjectConfigList.Add(value);
            this._factStatusBuilder.OfSubjectConfigList(this._subjectConfigList);
        }
        
        public void addTodoConfig(TodoConfig value) {
            this._todoConfigList.Add(value);
            this._factStatusBuilder.OfTodoConfigList(this._todoConfigList);
        }

        public void addEvidenceConfig(EvidenceConfig value) {
            this._evidenceConfigList.Add(value);
            this._factStatusBuilder.OfEvidenceConfigList(this._evidenceConfigList);
        }

        public void addResultConfig(ResultConfig value) {
            this._resultConfigList.Add(value);
            this._factStatusBuilder.OfResultConfigList(this._resultConfigList);
        }

        public void addArgumentConfig(ArgumentConfig value) {
            this._argumentConfigList.Add(value);
            this._factStatusBuilder.OfArgumentConfigList(this._argumentConfigList);
        }

        public void addRecordConfig(RecordConfig value) {
            this._recordConfigList.Add(value);
            this._factStatusBuilder.OfRecordConfigList(this._recordConfigList);
        }

        public void addProcessConfig(ProcessConfig value) {
            this._processConfigList.Add(value);
            this._factStatusBuilder.OfProcessConfigList(this._processConfigList);
        }

        public void addStepConfig(StepConfig value) {
            this._stepConfigList.Add(value);
            this._factStatusBuilder.OfStepConfigList(this._stepConfigList);
        }

        public void addSchemaConfig(SchemaConfig value) {
            this._schemaConfigList.Add(value);
            this._factStatusBuilder.OfSchemaConfigList(this._schemaConfigList);
        }

        /// <summary>
        /// FactStatusModelを生成
        /// </summary>
        /// <returns></returns>
        public FactStatusModel Build() {
            FactStatusConfig factStatusConfig = this._factStatusBuilder.Build();
            return new FactStatusModel(
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
            this._todoConfigList = new List<TodoConfig>();
            this._evidenceConfigList = new List<EvidenceConfig>();
            this._resultConfigList = new List<ResultConfig>();
            this._argumentConfigList = new List<ArgumentConfig>();
            this._recordConfigList = new List<RecordConfig>();
            this._processConfigList = new List<ProcessConfig>();
            this._stepConfigList = new List<StepConfig>();
            this._schemaConfigList = new List<SchemaConfig>();
        }
    }
}
