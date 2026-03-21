using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Model;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Main {
    public class FactStatusCrafter {
        private readonly FactStatusPolicy _factStatusPolicy;
        private FactStatusBuilder _factStatusBuilder;
        private DocumentEntity _documentEntity;
        private Dictionary<IdValue,SubjectEntity> _subjectEntityDict;
        private Dictionary<IdValue,AchievementEntity> _achievementEntityDict;
        private Dictionary<IdValue,EvidenceEntity> _evidenceEntityDict;
        private Dictionary<IdValue,ResultEntity> _resultEntityDict;
        private Dictionary<IdValue,RecordEntity> _recordEntityDict;
        private Dictionary<IdValue,TodoEntity> _todoEntityDict;
        private Dictionary<IdValue,SchemaEntity> _schemaEntityDict;
        private Dictionary<IdValue,GroupEntity> _groupEntityDict;
        private Dictionary<IdValue,IdValue> _parentLinkDict;
        private Dictionary<IdValue,List<IdValue>> _childrenLinkDict;
        private Dictionary<IdValue,List<IdValue>> _groupLinkDict;

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public void LoadJson(string loadFilePath) {
            try {
                FactStatusConfig factStatusConfig = _factStatusPolicy.LoadJson(loadFilePath);
                _factStatusBuilder.OfDocumentEntity(factStatusConfig.DocumentEntity);
                _factStatusBuilder.OfSubjectEntityDict(factStatusConfig.SubjectEntityDict);
                _factStatusBuilder.OfAchievementEntityDict(factStatusConfig.AchievementEntityDict);
                _factStatusBuilder.OfEvidenceEntityDict(factStatusConfig.EvidenceEntityDict);
                _factStatusBuilder.OfResultEntityDict(factStatusConfig.ResultEntityDict);
                _factStatusBuilder.OfRecordEntityDict(factStatusConfig.RecordEntityDict);
                _factStatusBuilder.OfTodoEntityDict(factStatusConfig.TodoEntityDict);
                _factStatusBuilder.OfSchemaEntityDict(factStatusConfig.SchemaEntityDict);
                _factStatusBuilder.OfGroupEntityDict(factStatusConfig.GroupEntityDict);
                _factStatusBuilder.OfParentLinkDict(factStatusConfig.ParentLinkDict);
                _factStatusBuilder.OfChildrenLinkDict(factStatusConfig.ChildrenLinkDict);
                _factStatusBuilder.OfGroupLinkDict(factStatusConfig.GroupLinkDict);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot(string loadFilePath) {
            try {
                this._factStatusPolicy.LoadMarkdownRoot(loadFilePath);
            }
            catch (AggregateException) { throw; }
        }

        public void EditDocumentEntity(DocumentEntity value) {
            this._documentEntity = value;
            _factStatusBuilder.OfDocumentEntity(this._documentEntity);
        }
        
        public void AddSubjectEntity(SubjectEntity value) {
            this._subjectEntityDict.Add(value.Id,value);
            this._factStatusBuilder.OfSubjectEntityDict(this._subjectEntityDict);
        }
        
        public void AddAchievementEntity(AchievementEntity value) {
            this._achievementEntityDict.Add(value.Id,value);
            this._factStatusBuilder.OfAchievementEntityDict(this._achievementEntityDict);
        }

        public void AddEvidenceEntity(EvidenceEntity value) {
            this._evidenceEntityDict.Add(value.Id,value);
            this._factStatusBuilder.OfEvidenceEntityDict(this._evidenceEntityDict);
        }

        public void AddResultEntity(ResultEntity value) {
            this._resultEntityDict.Add(value.Id,value);
            this._factStatusBuilder.OfResultEntityDict(this._resultEntityDict);
        }

        public void AddRecordEntity(RecordEntity value) {
            _recordEntityDict.Add(value.Id,value);
            _factStatusBuilder.OfRecordEntityDict(_recordEntityDict);
        }

        public void AddTodoEntity(TodoEntity value) {
            _todoEntityDict.Add(value.Id,value);
            _factStatusBuilder.OfTodoEntityDict(_todoEntityDict);
        }

        public void AddSchemaEntity(SchemaEntity value) {
            _schemaEntityDict.Add(value.Id,value);
            _factStatusBuilder.OfSchemaEntityDict(_schemaEntityDict);
        }
        
        public void AddGroupEntity(GroupEntity value) {
            _groupEntityDict.Add(value.Id,value);
            _factStatusBuilder.OfGroupEntityDict(_groupEntityDict);
        }

        public void AddParentLink(string child, string parent) {
            _parentLinkDict.Add(new IdValue(child), new IdValue(parent));
            _factStatusBuilder.OfParentLinkDict(_parentLinkDict);
        }
        
        public void AddChildrenLink(string parent, List<string> children) {
            List<IdValue> childrenList = new List<IdValue>();
            _childrenLinkDict.Add(new IdValue(parent), childrenList);
            _factStatusBuilder.OfChildrenLinkDict(_childrenLinkDict);
        }
        
        public void AddGroupLink(string group, List<string> entityList) {
            List<IdValue> entityValueList = new List<IdValue>();
            _groupLinkDict.Add(new IdValue(group), entityValueList);
            _factStatusBuilder.OfGroupLinkDict(_groupLinkDict);
        }

        /// <summary>
        /// FactStatusオブジェクトを生成
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
            var factStatusRepository = new FactStatusRepository();
            var jsonRepository = new JsonRepository();
            var markdownRepository = new MarkdownRepository();
            var factStatusStrategy = new FactStatusStrategy(factStatusRepository,jsonRepository, markdownRepository);
            this._factStatusPolicy = new FactStatusPolicy(factStatusStrategy);

            // FactStatusBuilderの生成
            this._factStatusBuilder = new FactStatusBuilder();

            // ConfigListの生成
            this._documentEntity = new DocumentEntity("");
            this._subjectEntityDict = new Dictionary<IdValue,SubjectEntity>();
            this._achievementEntityDict = new Dictionary<IdValue,AchievementEntity>();
            this._evidenceEntityDict = new Dictionary<IdValue,EvidenceEntity>();
            this._resultEntityDict = new Dictionary<IdValue,ResultEntity>();
            this._recordEntityDict = new Dictionary<IdValue,RecordEntity>();
            this._todoEntityDict = new Dictionary<IdValue,TodoEntity>();
            this._schemaEntityDict = new Dictionary<IdValue,SchemaEntity>();
            this._groupEntityDict = new Dictionary<IdValue,GroupEntity>();
            this._parentLinkDict = new Dictionary<IdValue,IdValue>();
            this._childrenLinkDict = new Dictionary<IdValue,List<IdValue>>();
            this._groupLinkDict = new Dictionary<IdValue,List<IdValue>>();
        }
    }
}
