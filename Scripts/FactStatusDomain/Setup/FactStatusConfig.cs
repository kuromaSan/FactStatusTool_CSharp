using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Model;
using FactStatus.Domain.Value;
using FactStatus.Domain.Rule;

namespace FactStatus.Domain.Setup {

    /// <summary>
    /// コアな情報をまとめたクラス
    /// </summary>
    public class FactStatusConfig{

        public DocumentEntity DocumentEntity { get; private set; }

        public Dictionary<IdValue,SubjectEntity> SubjectEntityDict { get; private set; }

        public Dictionary<IdValue,AchievementEntity> AchievementEntityDict { get; private set; }

        public Dictionary<IdValue,EvidenceEntity> EvidenceEntityDict { get; internal set; }

        public Dictionary<IdValue,ResultEntity> ResultEntityDict { get; private set; }

        public Dictionary<IdValue,RecordEntity> RecordEntityDict { get; private set; }

        public Dictionary<IdValue,TodoEntity> TodoEntityDict { get; private set; }

        public Dictionary<IdValue,SchemaEntity> SchemaEntityDict { get; private set; }

        public Dictionary<IdValue,GroupEntity> GroupEntityDict { get; private set; }

        public Dictionary<IdValue,IdValue> ParentLinkDict { get; private set; }
        
        public Dictionary<IdValue,List<IdValue>> ChildrenLinkDict { get; private set; }
        
        public Dictionary<IdValue,List<IdValue>> GroupLinkDict { get; private set; }



        public SubjectEntity GetSubjectEntity(IdValue value) {
            Validation.DictionaryEntityFound(SubjectEntityDict, value);
            return SubjectEntityDict[value];
        }

        public AchievementEntity GetAchievementEntity(IdValue value) {
            Validation.DictionaryEntityFound(AchievementEntityDict, value);
            return AchievementEntityDict[value];
        }

        public EvidenceEntity GetEvidenceEntity(IdValue value) {
            Validation.DictionaryEntityFound(EvidenceEntityDict, value);
            return EvidenceEntityDict[value];
        }

        public ResultEntity GetResultEntity(IdValue value) {
            Validation.DictionaryEntityFound(ResultEntityDict, value);
            return ResultEntityDict[value];
        }

        public RecordEntity GetRecordEntity(IdValue value) {
            Validation.DictionaryEntityFound(RecordEntityDict, value);
            return RecordEntityDict[value];
        }

        public TodoEntity GetTodoEntity(IdValue value) {
            Validation.DictionaryEntityFound(TodoEntityDict, value);
            return TodoEntityDict[value];
        }

        public SchemaEntity GetSchemaEntity(IdValue value) {
            Validation.DictionaryEntityFound(SchemaEntityDict, value);
            return SchemaEntityDict[value];
        }

        public GroupEntity GetGroupEntity(IdValue value) {
            Validation.DictionaryEntityFound(GroupEntityDict, value);
            return GroupEntityDict[value];
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
        public FactStatusConfig(
            DocumentEntity documentEntity,
            Dictionary<IdValue,SubjectEntity> subjectEntityDict,
            Dictionary<IdValue,AchievementEntity> achievementEntityDict,
            Dictionary<IdValue,EvidenceEntity> evidenceEntityDict,
            Dictionary<IdValue,ResultEntity> resultEntityDict,
            Dictionary<IdValue,RecordEntity> recordEntityDict,
            Dictionary<IdValue,TodoEntity> todoEntityDict,
            Dictionary<IdValue,SchemaEntity> schemaEntityDict,
            Dictionary<IdValue,GroupEntity> groupEntityDict,
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
            ParentLinkDict = parentLinkDict;
            ChildrenLinkDict = childrenLinkDict;
            GroupLinkDict = groupLinkDict;
        }
    }
}
