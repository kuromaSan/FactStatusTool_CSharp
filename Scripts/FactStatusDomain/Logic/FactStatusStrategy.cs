using FactStatus.Domain.Model;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Logic {
    public class FactStatusStrategy {
        private readonly IFactStatusRepository _factStatusRepository;
        private readonly IJsonRepository _jsonRepository;
        private readonly IMarkdownRepository _markdownRepository;

        /// <summary>
        /// ドキュメントエンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public DocumentEntity GetDocumentEntity(
            FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.DocumentEntity;
        }
        
        /// <summary>
        /// 主題エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public SubjectEntity GetSubjectEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetSubjectEntity(idValue);
        }

        /// <summary>
        /// 達成エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public AchievementEntity GetAchievementEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetAchievementEntity(idValue);
        }

        /// <summary>
        /// 証拠エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public EvidenceEntity GetEvidenceEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetEvidenceEntity(idValue);
        }

        /// <summary>
        /// 結果エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public ResultEntity GetResultEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetResultEntity(idValue);
        }

        /// <summary>
        /// 記録エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public RecordEntity GetRecordEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetRecordEntity(idValue);
        }

        /// <summary>
        /// 実装エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public TodoEntity GetTodoEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetTodoEntity(idValue);
        }

        /// <summary>
        /// 構想エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public SchemaEntity GetSchemaEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetSchemaEntity(idValue);
        }

        /// <summary>
        /// 集合エンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public GroupEntity GetGroupEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {
            return factStatusAggregate.GetGroupEntity(idValue);
        }

        /// <summary>
        /// 主題エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, SubjectEntity> GetSubjectEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.SubjectEntityDict;
        }
        
        /// <summary>
        /// 達成エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.AchievementEntityDict;
        }

        /// <summary>
        /// 証拠エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.EvidenceEntityDict;
        }

        /// <summary>
        /// 結果エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, ResultEntity> GetResultEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.ResultEntityDict;
        }

        /// <summary>
        /// 記録エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.RecordEntityDict;
        }

        /// <summary>
        /// 実装エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.TodoEntityDict;
        }

        /// <summary>
        /// 構想エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.SchemaEntityDict;
        }

        /// <summary>
        /// 集合エンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict(FactStatusAggregate factStatusAggregate) {
            return factStatusAggregate.GroupEntityDict;
        }

        /// <summary>
        /// IDタイプを指定してIDを生成
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idTypeEnum"></param>
        /// <returns></returns>
        public IdValue CreateIdValue(FactStatusAggregate factStatusAggregate, IdTypeEnum idTypeEnum) {
            var entityDict = GetEntityDictByIdTypeEnum(factStatusAggregate, idTypeEnum);
            return GenerateUniqueIdValue(entityDict, idTypeEnum);
        }

        /// <summary>
        /// IDを生成
        /// </summary>
        /// <param name="entityDict"></param>
        /// <param name="idTypeEnum"></param>
        /// <returns></returns>
        private IdValue GenerateUniqueIdValue(Dictionary<IdValue, IEntity> entityDict, IdTypeEnum idTypeEnum) {
            int nextIndex = 1;
            while (true) {
                IdValue candidate = IdValue.FromString($"{nextIndex:0000}{(int)idTypeEnum:0000}");
                if (!entityDict.ContainsKey(candidate)) {
                    return candidate;
                }
                nextIndex++;
            }
        }

        /// <summary>
        /// エンティティを作成
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <param name="title"></param>
        /// <param name="pathValue"></param>
        /// <returns></returns>
        public FactStatusAggregate CreateEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue,
            string title,
            PathValue pathValue) {
            
            // IDタイプからIDタイプ列挙型を取得
            IdTypeEnum idTypeEnum = idValue.Type;

            // エンティティを作成
            switch (idTypeEnum) {
                case IdTypeEnum.Subject:
                    var subjectEntity = SubjectEntity.Create(
                        idValue,
                        pathValue,
                        title);
                    
                    Dictionary<IdValue,SubjectEntity> subjectEntityDict = GetSubjectEntityDict(factStatusAggregate);
                    subjectEntityDict.Add(idValue, subjectEntity);
                    break;
                case IdTypeEnum.Achievement:
                    var achievementEntity = AchievementEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, AchievementEntity> achivementEntityDict = GetAchievementEntityDict(factStatusAggregate);
                    achivementEntityDict.Add(idValue,achievementEntity);
                    break;
                case IdTypeEnum.Evidence:
                    var evidenceEntity = EvidenceEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, EvidenceEntity> evidenceEntityDict = GetEvidenceEntityDict(factStatusAggregate);
                    evidenceEntityDict.Add(idValue, evidenceEntity);
                    break;
                case IdTypeEnum.Result:
                    var resultEntity = ResultEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, ResultEntity> resultEntityDict = GetResultEntityDict(factStatusAggregate);
                    resultEntityDict.Add(idValue, resultEntity);
                    break;
                case IdTypeEnum.Record:
                    var recordEntity = RecordEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, RecordEntity> recordEntityDict = GetRecordEntityDict(factStatusAggregate);
                    recordEntityDict.Add(idValue, recordEntity);
                    break;
                case IdTypeEnum.Todo:
                    var todoEntity = TodoEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, TodoEntity> todoEntityDict = GetTodoEntityDict(factStatusAggregate);
                    todoEntityDict.Add(idValue, todoEntity);
                    break;
                case IdTypeEnum.Schema:
                    var schemaEntity = SchemaEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, SchemaEntity> schemaEntityDict = factStatusAggregate.SchemaEntityDict;
                    schemaEntityDict.Add(idValue, schemaEntity);
                    break;
                case IdTypeEnum.Group:
                    var groupEntity = GroupEntity.Create(
                        idValue,
                        pathValue,
                        title);

                    Dictionary<IdValue, GroupEntity> groupEntityDict = factStatusAggregate.GroupEntityDict;
                    groupEntityDict.Add(idValue, groupEntity);
                    break;
                default:
                    throw new Exception($"Unsupported IdType: {idTypeEnum}");
            }
            return factStatusAggregate;
        }

        /// <summary>
        /// エンティティを削除
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public FactStatusAggregate DeleteEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue idValue) {

            var entityKey = FindDictKey(GetEntityDictByIdTypeEnum(factStatusAggregate, idValue.Type), idValue);
            if (entityKey == null) {
                return factStatusAggregate;
            }

            RemoveEntityLinks(factStatusAggregate, entityKey);
            RemoveEntityFromDict(factStatusAggregate, entityKey);
            factStatusAggregate.RefreshAllMinIds();

            return factStatusAggregate;
        }

        /// <summary>
        /// 元の親子接続を削除
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="childIdValue"></param>
        /// <param name="oldParentIdValue"></param>
        /// <returns></returns>
        public FactStatusAggregate UnConnectEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue childIdValue,
            IdValue oldParentIdValue) {
            
            // 
            RemoveChildFromParentList(factStatusAggregate.ChildrenLinkDict, oldParentIdValue, childIdValue);

            // 
            var childKey = FindDictKey(factStatusAggregate.ParentLinkDict, childIdValue);
            if (childKey != null
                && factStatusAggregate.ParentLinkDict.TryGetValue(childKey, out var currentParent)
                && currentParent.GetId() == oldParentIdValue.GetId()) {
                factStatusAggregate.ParentLinkDict.Remove(childKey);
            }

            return factStatusAggregate;
        }

        /// <summary>
        /// エンティティ同士を接続
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="parentIdValue"></param>
        /// <param name="childIdValue"></param>
        /// <returns></returns>
        public FactStatusAggregate LinkEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue parentIdValue,
            IdValue childIdValue) {

            Dictionary<IdValue, IdValue> parentLinkDict = factStatusAggregate.ParentLinkDict;
            Dictionary<IdValue, List<IdValue>> childrenLinkDict = factStatusAggregate.ChildrenLinkDict;

            var childKey = FindDictKey(parentLinkDict, childIdValue);
            if (childKey != null && parentLinkDict.TryGetValue(childKey, out var oldParent)) {
                RemoveChildFromParentList(childrenLinkDict, oldParent, childIdValue);
            }

            var parentKey = FindDictKey(parentLinkDict, parentIdValue) ?? parentIdValue;
            var resolvedChildKey = childKey ?? childIdValue;

            parentLinkDict[resolvedChildKey] = parentKey;

            if (childrenLinkDict.TryGetValue(parentKey, out var children)) {
                if (!children.Any(child => child.GetId() == resolvedChildKey.GetId())) {
                    children.Add(resolvedChildKey);
                }
            } else {
                childrenLinkDict.Add(parentKey, [resolvedChildKey]);
            }

            return factStatusAggregate;
        }

        private static IdValue? FindDictKey<TValue>(Dictionary<IdValue, TValue> dict, IdValue idValue) {
            foreach (var key in dict.Keys) {
                if (key.GetId() == idValue.GetId()) {
                    return key;
                }
            }

            return null;
        }

        private static void RemoveChildFromParentList(
            Dictionary<IdValue, List<IdValue>> childrenLinkDict,
            IdValue parentIdValue,
            IdValue childIdValue) {

            var parentKey = FindDictKey(childrenLinkDict, parentIdValue);
            if (parentKey == null || !childrenLinkDict.TryGetValue(parentKey, out var children)) {
                return;
            }

            children.RemoveAll(child => child.GetId() == childIdValue.GetId());
            if (children.Count == 0) {
                childrenLinkDict.Remove(parentKey);
            }
        }

        private static void RemoveEntityLinks(FactStatusAggregate factStatusAggregate, IdValue entityKey) {
            var parentLinkDict = factStatusAggregate.ParentLinkDict;
            var childrenLinkDict = factStatusAggregate.ChildrenLinkDict;
            var groupLinkDict = factStatusAggregate.GroupLinkDict;

            if (parentLinkDict.TryGetValue(entityKey, out var parentKey)) {
                RemoveChildFromParentList(childrenLinkDict, parentKey, entityKey);
                parentLinkDict.Remove(entityKey);
            }

            var childrenParentKey = FindDictKey(childrenLinkDict, entityKey);
            if (childrenParentKey != null && childrenLinkDict.TryGetValue(childrenParentKey, out var children)) {
                foreach (var child in children.ToList()) {
                    var childKey = FindDictKey(parentLinkDict, child);
                    if (childKey != null) {
                        parentLinkDict.Remove(childKey);
                    }
                }
                childrenLinkDict.Remove(childrenParentKey);
            }

            var groupKey = FindDictKey(groupLinkDict, entityKey);
            if (groupKey != null) {
                groupLinkDict.Remove(groupKey);
            }

            foreach (var groupEntry in groupLinkDict.ToList()) {
                groupEntry.Value.RemoveAll(member => member.GetId() == entityKey.GetId());
                if (groupEntry.Value.Count == 0) {
                    var entryKey = FindDictKey(groupLinkDict, groupEntry.Key);
                    if (entryKey != null) {
                        groupLinkDict.Remove(entryKey);
                    }
                }
            }
        }

        private static void RemoveEntityFromDict(FactStatusAggregate factStatusAggregate, IdValue entityKey) {
            switch (entityKey.Type) {
                case IdTypeEnum.Subject:
                    factStatusAggregate.SubjectEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Achievement:
                    factStatusAggregate.AchievementEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Evidence:
                    factStatusAggregate.EvidenceEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Result:
                    factStatusAggregate.ResultEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Record:
                    factStatusAggregate.RecordEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Todo:
                    factStatusAggregate.TodoEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Schema:
                    factStatusAggregate.SchemaEntityDict.Remove(entityKey);
                    break;
                case IdTypeEnum.Group:
                    factStatusAggregate.GroupEntityDict.Remove(entityKey);
                    break;
                default:
                    throw new Exception($"Unsupported IdType: {entityKey.Type}");
            }
        }

        /// <summary>
        /// ID一覧を指定してエンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValues"></param>
        /// <returns></returns>
        public List<IEntity> GetEntitiesByIdValues(FactStatusAggregate factStatusAggregate, List<IdValue> idValues) {
            List<IEntity> entities = new List<IEntity>();
            foreach (IdValue idValue in idValues) {
                entities.Add(GetIdEntityByIdValue(factStatusAggregate, idValue));
            }
            return entities;
        }

        /// <summary>
        /// IDを指定してエンティティを取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public IEntity GetIdEntityByIdValue(FactStatusAggregate factStatusAggregate, IdValue idValue) {
            switch (idValue.Type) {
                case IdTypeEnum.Document:
                    return factStatusAggregate.DocumentEntity;
                case IdTypeEnum.Subject:
                    return factStatusAggregate.GetSubjectEntity(idValue);
                case IdTypeEnum.Achievement:
                    return factStatusAggregate.GetAchievementEntity(idValue);
                case IdTypeEnum.Evidence:
                    return factStatusAggregate.GetEvidenceEntity(idValue);
                case IdTypeEnum.Result:
                    return factStatusAggregate.GetResultEntity(idValue);
                case IdTypeEnum.Record:
                    return factStatusAggregate.GetRecordEntity(idValue);
                case IdTypeEnum.Todo:
                    return factStatusAggregate.GetTodoEntity(idValue);
                case IdTypeEnum.Schema:
                    return factStatusAggregate.GetSchemaEntity(idValue);
                case IdTypeEnum.Group:
                    return factStatusAggregate.GetGroupEntity(idValue);
                default:
                    throw new Exception($"Unsupported IdType: {idValue.Type}");
            }
        }

        /// <summary>
        /// IDタイプを指定してエンティティ一覧を取得
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="idTypeEnum"></param>
        /// <returns></returns>
        public Dictionary<IdValue, IEntity> GetEntityDictByIdTypeEnum(FactStatusAggregate factStatusAggregate, IdTypeEnum idTypeEnum) {
            switch (idTypeEnum) {
                case IdTypeEnum.Subject:
                    return factStatusAggregate.SubjectEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Achievement:
                    return factStatusAggregate.AchievementEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Evidence:
                    return factStatusAggregate.EvidenceEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Result:
                    return factStatusAggregate.ResultEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Record:
                    return factStatusAggregate.RecordEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Todo:
                    return factStatusAggregate.TodoEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Schema:
                    return factStatusAggregate.SchemaEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                case IdTypeEnum.Group:
                    return factStatusAggregate.GroupEntityDict.ToDictionary(kv => kv.Key, kv => (IEntity)kv.Value);
                default:
                    throw new Exception($"Unsupported IdType: {idTypeEnum}");
            }
        }

        /// <summary>
        /// エンティティをコピー
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="sourceIdValue"></param>
        /// <param name="destinationIdValue"></param>
        /// <returns></returns>
        public FactStatusAggregate CopyEntity(
            FactStatusAggregate factStatusAggregate,
            IdValue sourceIdValue,
            IdValue destinationIdValue) {

            // エンティティをコピー
            switch (sourceIdValue.Type) {
                case IdTypeEnum.Subject:
                    // エンティティを取得
                    var subjectEntity = factStatusAggregate.GetSubjectEntity(sourceIdValue);
                    var subjectMinId = factStatusAggregate.GetSubjectMinId();

                    // コピー先のパスを生成
                    string newSubjectPathName = subjectEntity.PathName.Path + subjectMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedSubjectEntity = subjectEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newSubjectPathName));

                    // エンティティを追加
                    factStatusAggregate.AddSubjectEntity(copiedSubjectEntity);
                    break;
                case IdTypeEnum.Achievement:
                    // エンティティを取得
                    var achievementEntity = factStatusAggregate.GetAchievementEntity(sourceIdValue);
                    var achievementMinId = factStatusAggregate.GetAchievementMinId();

                    // コピー先のパスを生成
                    string newAchievemenPathName = achievementEntity.PathName.Path + achievementMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedAchievementEntity = achievementEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newAchievemenPathName));

                    // エンティティを追加
                    factStatusAggregate.AddAchievementEntity(copiedAchievementEntity);
                    break;
                case IdTypeEnum.Evidence:
                    // エンティティを取得
                    var evidenceEntity = factStatusAggregate.GetEvidenceEntity(sourceIdValue);
                    var evidenceMinId = factStatusAggregate.GetEvidenceMinId();

                    // コピー先のパスを生成
                    string newEvidencePathName = evidenceEntity.PathName.Path + evidenceMinId;

                    // エンティティをコピー用に加工
                    var copiedEvidenceEntity = evidenceEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newEvidencePathName));

                    // エンティティを追加
                    factStatusAggregate.AddEvidenceEntity(copiedEvidenceEntity);
                    break;
                case IdTypeEnum.Result:
                    // エンティティを取得
                    var resultEntity = factStatusAggregate.GetResultEntity(sourceIdValue);
                    var resultMinId = factStatusAggregate.GetResultMinId();

                    // コピー先のパスを生成
                    string newResultPathName = resultEntity.PathName.Path + resultMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedResultEntity = resultEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newResultPathName));

                    // エンティティを追加
                    factStatusAggregate.AddResultEntity(copiedResultEntity);
                    break;
                case IdTypeEnum.Record:
                    // エンティティを取得
                    var recordEntity = factStatusAggregate.GetRecordEntity(sourceIdValue);
                    var recordMinId = factStatusAggregate.GetRecordMinId();

                    // コピー先のパスを生成
                    string newRecordPathName = recordEntity.PathName.Path + recordMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedRecordEntity = recordEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newRecordPathName));

                    // エンティティを追加
                    factStatusAggregate.AddRecordEntity(copiedRecordEntity);
                    break;
                case IdTypeEnum.Todo:
                    // エンティティを取得
                    var todoEntity = factStatusAggregate.GetTodoEntity(sourceIdValue);
                    var todoMinId = factStatusAggregate.GetTodoMinId();

                    // コピー先のパスを生成
                    string newTodoPathName = todoEntity.PathName.Path + todoMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedTodoEntity = todoEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newTodoPathName));

                    // エンティティを追加
                    factStatusAggregate.AddTodoEntity(copiedTodoEntity);
                    break;
                case IdTypeEnum.Schema:
                    // エンティティを取得
                    var schemaEntity = factStatusAggregate.GetSchemaEntity(sourceIdValue);
                    var schemaMinId = factStatusAggregate.GetSchemaMinId();

                    // コピー先のパスを生成
                    string newSchemaPathName = schemaEntity.PathName.Path + schemaMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedSchemaEntity = schemaEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newSchemaPathName));

                    // エンティティを追加
                    factStatusAggregate.AddSchemaEntity(copiedSchemaEntity);
                    break;
                case IdTypeEnum.Group:
                    // エンティティを取得
                    var groupEntity = factStatusAggregate.GetGroupEntity(sourceIdValue);
                    var groupMinId = factStatusAggregate.GetGroupMinId();

                    // コピー先のパスを生成
                    string newGroupPathName = groupEntity.PathName.Path + groupMinId;
                    
                    // エンティティをコピー用に加工
                    var copiedGroupEntity = groupEntity.Duplicate(
                        destinationIdValue,
                        PathValue.PathIsDirectory(newGroupPathName));

                    // エンティティを追加
                    factStatusAggregate.AddGroupEntity(copiedGroupEntity);
                    break;
                default:
                    throw new Exception($"Unsupported IdType: {sourceIdValue.Type}");
            }

            // エンティティを返す
            return factStatusAggregate;
        }

        /// <summary>
        /// リレーショナル型を読込
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusAggregate LoadRelational(PathValue filePath) {
            // jsonファイルを読み込み
            JsonDto relationalDto = _factStatusRepository.LoadRelational(filePath);

            // factStatusAggregateに変換
            var factStatusBuilder = new FactStatusBuilder();
            factStatusBuilder.OfSubjectEntityDict(relationalDto.SubjectAggregates);
            factStatusBuilder.OfAchievementEntityDict(relationalDto.AchievementAggregates);
            factStatusBuilder.OfEvidenceEntityDict(relationalDto.EvidenceAggregates);
            factStatusBuilder.OfResultEntityDict(relationalDto.ResultAggregates, relationalDto.ArgumentProperties, relationalDto.AssertionProperties);
            factStatusBuilder.OfRecordEntityDict(relationalDto.RecordAggregates);
            factStatusBuilder.OfTodoEntityDict(relationalDto.TodoAggregates);
            factStatusBuilder.OfSchemaEntityDict(relationalDto.SchemaAggregates);
            factStatusBuilder.OfGroupEntityDict(relationalDto.GroupAggregates);
            factStatusBuilder.OfParentLinkDict(relationalDto.ParentEdges);
            factStatusBuilder.OfChildrenLinkDict(relationalDto.ParentEdges);
            factStatusBuilder.OfGroupLinkDict(relationalDto.GroupEdges);
            FactStatusAggregate factStatusAggregate = factStatusBuilder.Build();

            return factStatusAggregate;
        }

        /// <summary>
        /// リレーショナル型を保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="factStatusAggregate"></param>
        public void SaveRelational(PathValue filePath, FactStatusAggregate factStatusAggregate) {
            // factStatusAggregateをRelationalDtoに変換
            var relationalDtoBuilder = new JsonDtoBuilder();
            relationalDtoBuilder.OfDocumentAggregate(factStatusAggregate.DocumentEntity);
            relationalDtoBuilder.OfSubjectAggregates(factStatusAggregate.SubjectEntityDict);
            relationalDtoBuilder.OfAchievementAggregates(factStatusAggregate.AchievementEntityDict);
            relationalDtoBuilder.OfEvidenceAggregates(factStatusAggregate.EvidenceEntityDict);
            relationalDtoBuilder.OfResultAggregates(factStatusAggregate.ResultEntityDict);
            relationalDtoBuilder.OfRecordAggregates(factStatusAggregate.RecordEntityDict);
            relationalDtoBuilder.OfTodoAggregates(factStatusAggregate.TodoEntityDict);
            relationalDtoBuilder.OfSchemaAggregates(factStatusAggregate.SchemaEntityDict);
            relationalDtoBuilder.OfGroupAggregates(factStatusAggregate.GroupEntityDict);
            relationalDtoBuilder.OfArgumentProperties(factStatusAggregate.ResultEntityDict);
            relationalDtoBuilder.OfAssertionProperties(factStatusAggregate.ResultEntityDict);
            relationalDtoBuilder.OfParentEdges(factStatusAggregate.ParentLinkDict);
            relationalDtoBuilder.OfGroupEdges(factStatusAggregate.GroupLinkDict);
            JsonDto relationalDto = relationalDtoBuilder.Build();

            // jsonファイルを保存
            _factStatusRepository.SaveRelational(filePath, relationalDto);
        }

        /// <summary>
        /// JSONファイルを読込
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusAggregate LoadJson(PathValue filePath) {
            // jsonファイルを読み込み
            JsonDto jsonDto = _jsonRepository.LoadJson(filePath);

            // factStatusAggregateに変換
            var factStatusBuilder = new FactStatusBuilder();
            factStatusBuilder.OfSubjectEntityDict(jsonDto.SubjectAggregates);
            factStatusBuilder.OfAchievementEntityDict(jsonDto.AchievementAggregates);
            factStatusBuilder.OfEvidenceEntityDict(jsonDto.EvidenceAggregates);
            factStatusBuilder.OfResultEntityDict(jsonDto.ResultAggregates, jsonDto.ArgumentProperties, jsonDto.AssertionProperties);
            factStatusBuilder.OfRecordEntityDict(jsonDto.RecordAggregates);
            factStatusBuilder.OfTodoEntityDict(jsonDto.TodoAggregates);
            factStatusBuilder.OfSchemaEntityDict(jsonDto.SchemaAggregates);
            factStatusBuilder.OfGroupEntityDict(jsonDto.GroupAggregates);
            factStatusBuilder.OfParentLinkDict(jsonDto.ParentEdges);
            factStatusBuilder.OfChildrenLinkDict(jsonDto.ParentEdges);
            factStatusBuilder.OfGroupLinkDict(jsonDto.GroupEdges);
            FactStatusAggregate factStatusAggregate = factStatusBuilder.Build();

            return factStatusAggregate;
        }

        /// <summary>
        /// JSONファイルを保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="factStatusAggregate"></param>
        public void SaveJson(PathValue filePath, FactStatusAggregate factStatusAggregate) {
            // factStatusAggregateをRelationalDataDtoに変換
            var jsonDtoBuilder = new JsonDtoBuilder();
            jsonDtoBuilder.OfDocumentAggregate(factStatusAggregate.DocumentEntity);
            jsonDtoBuilder.OfSubjectAggregates(factStatusAggregate.SubjectEntityDict);
            jsonDtoBuilder.OfAchievementAggregates(factStatusAggregate.AchievementEntityDict);
            jsonDtoBuilder.OfEvidenceAggregates(factStatusAggregate.EvidenceEntityDict);
            jsonDtoBuilder.OfResultAggregates(factStatusAggregate.ResultEntityDict);
            jsonDtoBuilder.OfRecordAggregates(factStatusAggregate.RecordEntityDict);
            jsonDtoBuilder.OfTodoAggregates(factStatusAggregate.TodoEntityDict);
            jsonDtoBuilder.OfSchemaAggregates(factStatusAggregate.SchemaEntityDict);
            jsonDtoBuilder.OfGroupAggregates(factStatusAggregate.GroupEntityDict);
            jsonDtoBuilder.OfArgumentProperties(factStatusAggregate.ResultEntityDict);
            jsonDtoBuilder.OfAssertionProperties(factStatusAggregate.ResultEntityDict);
            jsonDtoBuilder.OfParentEdges(factStatusAggregate.ParentLinkDict);
            jsonDtoBuilder.OfGroupEdges(factStatusAggregate.GroupLinkDict);
            JsonDto jsonDto = jsonDtoBuilder.Build();

            // jsonファイルを保存
            _jsonRepository.SaveJson(filePath, jsonDto);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="factStatusRepository"></param>
        /// <param name="jsonRepository"></param>
        /// <param name="markdownRepository"></param>
        public FactStatusStrategy(
            IFactStatusRepository factStatusRepository,
            IJsonRepository jsonRepository,
            IMarkdownRepository markdownRepository) {

            _factStatusRepository = factStatusRepository;
            _jsonRepository = jsonRepository;
            _markdownRepository = markdownRepository;
        }
    }
}
