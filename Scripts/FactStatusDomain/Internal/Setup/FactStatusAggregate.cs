using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Api.Entity;
using FactStatus.Domain.Api.Value;
using FactStatus.Domain.Internal.Rule;

namespace FactStatus.Domain.Internal.Setup {

    /// <summary>
    /// コアな情報をまとめたクラス
    /// </summary>
    public class FactStatusAggregate{

        // ドキュメントエンティティ 
        public DocumentEntity DocumentEntity { get; private set; }

        // 主題エンティティ
        public Dictionary<IdValue,SubjectEntity> SubjectEntityDict { get; private set; }
        private int SubjectMinId { get; set; }

        // 達成エンティティ
        public Dictionary<IdValue,AchievementEntity> AchievementEntityDict { get; private set; }
        private int AchievementMinId { get; set; }

        // 証拠エンティティ
        public Dictionary<IdValue,EvidenceEntity> EvidenceEntityDict { get; internal set; }
        private int EvidenceMinId { get; set; }

        // 結果エンティティ
        public Dictionary<IdValue,ResultEntity> ResultEntityDict { get; private set; }
        private int ResultMinId { get; set; }

        // 記録エンティティ
        public Dictionary<IdValue,RecordEntity> RecordEntityDict { get; private set; }
        private int RecordMinId { get; set; }

        // 実装エンティティ
        public Dictionary<IdValue,TodoEntity> TodoEntityDict { get; private set; }
        private int TodoMinId { get; set; }

        // 構想エンティティ
        public Dictionary<IdValue,SchemaEntity> SchemaEntityDict { get; private set; }
        private int SchemaMinId { get; set; }

        // 集合エンティティ
        public Dictionary<IdValue,GroupEntity> GroupEntityDict { get; private set; }
        private int GroupMinId { get; set; }

        // 引数エンティティ
        public Dictionary<IdValue,ArgumentEntity> ArgumentEntityDict { get; private set; }
        private int ArgumentMinId { get; set; }

        // 表明エンティティ
        public Dictionary<IdValue,AssertionEntity> AssertionEntityDict { get; private set; }
        private int AssertionMinId { get; set; }

        // 親エンティティ
        public Dictionary<IdValue,IdValue> ParentLinkDict { get; private set; }

        // 子エンティティ リスト
        public Dictionary<IdValue,List<IdValue>> ChildrenLinkDict { get; private set; }
        
        // 集合エンティティ リスト
        public Dictionary<IdValue,List<IdValue>> GroupLinkDict { get; private set; }


        /// <summary>
        /// 主題エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SubjectEntity GetSubjectEntity(IdValue value) {
            Validation.DictionaryEntityFound(SubjectEntityDict, value);
            return SubjectEntityDict[value];
        }

        /// <summary>
        /// 主題エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetSubjectMinId(){
            return $"{SubjectMinId:D4}";
        }

        /// <summary>
        /// 達成エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AchievementEntity GetAchievementEntity(IdValue value) {
            Validation.DictionaryEntityFound(AchievementEntityDict, value);
            return AchievementEntityDict[value];
        }

        /// <summary>
        /// 達成エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetAchievementMinId() {
            return $"{AchievementMinId:D4}";
        }

        /// <summary>
        /// 証拠エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EvidenceEntity GetEvidenceEntity(IdValue value) {
            Validation.DictionaryEntityFound(EvidenceEntityDict, value);
            return EvidenceEntityDict[value];
        }

        /// <summary>
        /// 証拠エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetEvidenceMinId() {
            return $"{EvidenceMinId:D4}";
        }

        /// <summary>
        /// 結果エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResultEntity GetResultEntity(IdValue value) {
            Validation.DictionaryEntityFound(ResultEntityDict, value);
            return ResultEntityDict[value];
        }

        /// <summary>
        /// 結果エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetResultMinId() {
            return $"{ResultMinId:D4}";
        }

        /// <summary>
        /// 記録エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public RecordEntity GetRecordEntity(IdValue value) {
            Validation.DictionaryEntityFound(RecordEntityDict, value);
            return RecordEntityDict[value];
        }

        /// <summary>
        /// 記録エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetRecordMinId() {
            return $"{RecordMinId:D4}";
        }

        /// <summary>
        /// 実装エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TodoEntity GetTodoEntity(IdValue value) {
            Validation.DictionaryEntityFound(TodoEntityDict, value);
            return TodoEntityDict[value];
        }

        /// <summary>
        /// 実装エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetTodoMinId() {
            return $"{TodoMinId:D4}";
        }

        /// <summary>
        /// 構想エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SchemaEntity GetSchemaEntity(IdValue value) {
            Validation.DictionaryEntityFound(SchemaEntityDict, value);
            return SchemaEntityDict[value];
        }

        /// <summary>
        /// 構想エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetSchemaMinId() {
            return $"{SchemaMinId:D4}";
        }

        /// <summary>
        /// 集合エンティティを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public GroupEntity GetGroupEntity(IdValue value) {
            Validation.DictionaryEntityFound(GroupEntityDict, value);
            return GroupEntityDict[value];
        }

        /// <summary>
        /// 集合エンティティの最小IDを4桁0埋め取得
        /// </summary>
        /// <returns></returns>
        public string GetGroupMinId() {
            return $"{GroupMinId:D4}";
        }

        /// <summary>
        /// 主題エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddSubjectEntity(SubjectEntity entity) {
            //Validation.Entity(entity);
            SubjectEntityDict.Add(entity.Id, entity);
            SubjectMinId = FindMinAvailableId(SubjectEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 達成エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddAchievementEntity(AchievementEntity entity) {
            //Validation.Entity(entity);
            AchievementEntityDict.Add(entity.Id, entity);
            AchievementMinId = FindMinAvailableId(AchievementEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 証拠エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddEvidenceEntity(EvidenceEntity entity) {
            //Validation.Entity(entity);
            EvidenceEntityDict.Add(entity.Id, entity);
            EvidenceMinId = FindMinAvailableId(EvidenceEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 結果エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddResultEntity(ResultEntity entity) {
            //Validation.Entity(entity);
            ResultEntityDict.Add(entity.Id, entity);
            ResultMinId = FindMinAvailableId(ResultEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 記録エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddRecordEntity(RecordEntity entity) {
            //Validation.Entity(entity);
            RecordEntityDict.Add(entity.Id, entity);
            RecordMinId = FindMinAvailableId(RecordEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 実装エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddTodoEntity(TodoEntity entity) {
            //Validation.Entity(entity);
            TodoEntityDict.Add(entity.Id, entity);
            TodoMinId = FindMinAvailableId(TodoEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 構想エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddSchemaEntity(SchemaEntity entity) {
            //Validation.Entity(entity);
            SchemaEntityDict.Add(entity.Id, entity);
            SchemaMinId = FindMinAvailableId(SchemaEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 集合エンティティを追加
        /// </summary>
        /// <param name="entity"></param>
        public void AddGroupEntity(GroupEntity entity) {
            //Validation.Entity(entity);
            GroupEntityDict.Add(entity.Id, entity);
            GroupMinId = FindMinAvailableId(GroupEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// 親エンティティを追加
        /// </summary>
        /// <param name="childId"></param>
        /// <param name="parentId"></param>
        public void AddParentLink(IdValue childId, IdValue parentId) {
            //Validation.ParentLink(childId, parentId);
            ParentLinkDict.Add(childId, parentId);
        }

        /// <summary>
        /// 子エンティティを追加
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="childId"></param>
        public void AddChildrenLink(IdValue parentId, IdValue childId) {
            //Validation.ChildrenLink(parentId, childId);
            if (!ChildrenLinkDict.ContainsKey(parentId)) {
                ChildrenLinkDict.Add(parentId, new List<IdValue>());
            }
            ChildrenLinkDict[parentId].Add(childId);
        }

        /// <summary>
        /// 集合エンティティを追加
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="memberId"></param>
        public void AddGroupLink(IdValue groupId, IdValue memberId) {
            //Validation.GroupLink(groupId, memberId);
            if (!GroupLinkDict.ContainsKey(groupId)) {
                GroupLinkDict.Add(groupId, new List<IdValue>());
            }
            GroupLinkDict[groupId].Add(memberId);
        }


        /// <summary>
        /// 未使用の最小Indexを取得
        /// </summary>
        /// <param name="usedIndices"></param>
        /// <returns></returns>
        private static int FindMinAvailableId(IEnumerable<int> usedIndices) {
            var used = usedIndices.ToHashSet();
            int id = 1;
            while (used.Contains(id)) {
                id++;
            }
            return id;
        }

        /// <summary>
        /// 各エンティティの最小IDを更新
        /// </summary>
        internal void RefreshAllMinIds() {
            UpdateAllMinIds();
        }

        /// <summary>
        /// 各エンティティの最小IDを更新
        /// </summary>
        private void UpdateAllMinIds() {
            SubjectMinId = FindMinAvailableId(SubjectEntityDict.Keys.Select(k => k.Index));
            AchievementMinId = FindMinAvailableId(AchievementEntityDict.Keys.Select(k => k.Index));
            EvidenceMinId = FindMinAvailableId(EvidenceEntityDict.Keys.Select(k => k.Index));
            ResultMinId = FindMinAvailableId(ResultEntityDict.Keys.Select(k => k.Index));
            RecordMinId = FindMinAvailableId(RecordEntityDict.Keys.Select(k => k.Index));
            TodoMinId = FindMinAvailableId(TodoEntityDict.Keys.Select(k => k.Index));
            SchemaMinId = FindMinAvailableId(SchemaEntityDict.Keys.Select(k => k.Index));
            GroupMinId = FindMinAvailableId(GroupEntityDict.Keys.Select(k => k.Index));
        }

        /// <summary>
        /// ディレクトリをマージ
        /// </summary>
        /// <returns></returns>
        private Dictionary<IdValue,IEntity> MargeDirectory() {
            return SubjectEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value)
                .Concat(AchievementEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(EvidenceEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(ResultEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(RecordEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(TodoEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(SchemaEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .Concat(GroupEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="documentEntity"></param>
        /// <param name="subjectEntityDict"></param>
        /// <param name="achievementEntityDict"></param>
        /// <param name="evidenceEntityDict"></param>
        /// <param name="resultEntityDict"></param>
        /// <param name="recordEntityDict"></param>
        /// <param name="todoEntityDict"></param>
        /// <param name="schemaEntityDict"></param>
        /// <param name="groupEntityDict"></param>
        /// <param name="parentLinkDict"></param>
        /// <param name="childrenLinkDict"></param>
        /// <param name="groupLinkDict"></param>
        public FactStatusAggregate(
            DocumentEntity documentEntity,
            Dictionary<IdValue,SubjectEntity> subjectEntityDict,
            Dictionary<IdValue,AchievementEntity> achievementEntityDict,
            Dictionary<IdValue,EvidenceEntity> evidenceEntityDict,
            Dictionary<IdValue,ResultEntity> resultEntityDict,
            Dictionary<IdValue,RecordEntity> recordEntityDict,
            Dictionary<IdValue,TodoEntity> todoEntityDict,
            Dictionary<IdValue,SchemaEntity> schemaEntityDict,
            Dictionary<IdValue,GroupEntity> groupEntityDict,
            Dictionary<IdValue,ArgumentEntity> argumentEntityDict,
            Dictionary<IdValue,AssertionEntity> assertionEntityDict,
            Dictionary<IdValue,IdValue> parentLinkDict,
            Dictionary<IdValue,List<IdValue>> childrenLinkDict,
            Dictionary<IdValue,List<IdValue>> groupLinkDict) {

            DocumentEntity = documentEntity;
            SubjectEntityDict = subjectEntityDict;
            AchievementEntityDict = achievementEntityDict;
            EvidenceEntityDict = evidenceEntityDict;
            ResultEntityDict = resultEntityDict;
            RecordEntityDict = recordEntityDict;
            TodoEntityDict = todoEntityDict;
            SchemaEntityDict = schemaEntityDict;
            GroupEntityDict = groupEntityDict;
            ArgumentEntityDict = argumentEntityDict;
            AssertionEntityDict = assertionEntityDict;
            ParentLinkDict = parentLinkDict;
            ChildrenLinkDict = childrenLinkDict;
            GroupLinkDict = groupLinkDict;
            UpdateAllMinIds();
        }
    }
}
