using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Model;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Setup {
    /// <summary>
    /// 
    /// </summary>
    public class FactStatusBuilder {
        // フィールド
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

        public FactStatusBuilder OfDocumentEntity(DocumentEntity value) {
            _documentEntity = value;
            return this;
        }

        public FactStatusBuilder OfSubjectEntityDict(Dictionary<IdValue,SubjectEntity> value) {
            _subjectEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfAchievementEntityDict(Dictionary<IdValue,AchievementEntity> value) {
            _achievementEntityDict = value;
            return this;
        }
        
        public FactStatusBuilder OfEvidenceEntityDict(Dictionary<IdValue,EvidenceEntity> value) {
            _evidenceEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfResultEntityDict(Dictionary<IdValue,ResultEntity> value) {
            _resultEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfRecordEntityDict(Dictionary<IdValue,RecordEntity> value) {
            _recordEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfTodoEntityDict(Dictionary<IdValue,TodoEntity> value) {
            _todoEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfSchemaEntityDict(Dictionary<IdValue,SchemaEntity> value) {
            _schemaEntityDict = value;
            return this;
        }
        
        public FactStatusBuilder OfGroupEntityDict(Dictionary<IdValue,GroupEntity> value) {
            _groupEntityDict = value;
            return this;
        }

        public FactStatusBuilder OfParentLinkDict(Dictionary<IdValue,IdValue> value) {
            _parentLinkDict = value;
            return this;
        }
        
        public FactStatusBuilder OfChildrenLinkDict(Dictionary<IdValue,List<IdValue>> value) {
            _childrenLinkDict = value;
            return this;
        }
        
        public FactStatusBuilder OfGroupLinkDict(Dictionary<IdValue,List<IdValue>> value) {
            _groupLinkDict = value;
            return this;
        }

        public FactStatusBuilder OfDocumentEntity(DocumentConfigJsonDto value) {
            _documentEntity = new DocumentEntity(value.Description); ;
            return this;
        }

        //
        public FactStatusBuilder OfSubjectEntityDict(List<SubjectConfigJsonDto> value) {
            foreach (SubjectConfigJsonDto subjectConfigDto in value) {
                var subjectEntity = new SubjectEntity(
                    IdValue.FromString(subjectConfigDto.Id),
                    PathValue.PathIsDirectory(subjectConfigDto.PathName),
                    subjectConfigDto.Title,
                    subjectConfigDto.Description);
                _subjectEntityDict.Add(subjectEntity.Id,subjectEntity);
            }
            return this;
        }

        public FactStatusBuilder OfAchievementEntityDict(List<AchievementConfigJsonDto> value) {
            foreach (AchievementConfigJsonDto achievementConfigDto in value) {
                var achievementEntity = new AchievementEntity(
                    IdValue.FromString(achievementConfigDto.Id),
                    PathValue.PathIsDirectory(achievementConfigDto.PathName),
                    achievementConfigDto.Title,
                    achievementConfigDto.Description);
                _achievementEntityDict.Add(achievementEntity.Id,achievementEntity);
            }
            return this;
        }

        public FactStatusBuilder OfEvidenceEntityDict(List<EvidenceConfigJsonDto> value) {
            foreach (EvidenceConfigJsonDto evidenceConfigDto in value) {
                var evidenceEntity = new EvidenceEntity(
                    IdValue.FromString(evidenceConfigDto.Id),
                    PathValue.PathIsDirectory(evidenceConfigDto.PathName),
                    evidenceConfigDto.Title,
                    evidenceConfigDto.Description,
                    BoolValue.FromString(evidenceConfigDto.Success));
                _evidenceEntityDict.Add(evidenceEntity.Id,evidenceEntity);
            }
            return this;
        }

        public FactStatusBuilder OfResultEntityDict(
            List<ResultConfigJsonDto> resultConfigDtos,
            List<ArgumentPropertieJsonDto> argumentDtos,
            List<AssertionPropertieJsonDto> assertionDtos) {

            // 
            var argumentValueDict = new Dictionary<string,List<ArgumentEntity>>();
            foreach (ArgumentPropertieJsonDto argumentDto in argumentDtos) {
                var argumentValue = new ArgumentEntity(
                    IdValue.FromString(argumentDto.Id),
                    IdValue.FromString(argumentDto.ParentId),
                    this.convertStringToInt(argumentDto.ListIndex),
                    this.convertStringToInt(argumentDto.KeyIndex),
                    argumentDto.KeyName,
                    this.convertDataTypeEnum(argumentDto.DataType),
                    argumentDto.Value);

                // ParentId をキーに List<ArgumentValue> を管理する
                if (!argumentValueDict.TryGetValue(argumentValue.ParentId.GetId(), out var argumentList)) {
                    argumentList = new List<ArgumentEntity>();
                    argumentValueDict[argumentValue.ParentId.GetId()] = argumentList;
                }
                argumentList.Add(argumentValue);
            }

            // 
            var assertionValueDict = new Dictionary<string,List<AssertionEntity>>();
            foreach (AssertionPropertieJsonDto assertionDto in assertionDtos) {
                var assertionValue = new AssertionEntity(
                    IdValue.FromString(assertionDto.Id),
                    IdValue.FromString(assertionDto.ParentId),
                    this.convertAssertEnum(assertionDto.Assert),
                    assertionDto.Target,
                    this.convertDataTypeEnum(assertionDto.DataType),
                    assertionDto.Value);

                // ParentId をキーに List<ArgumentValue> を管理する
                if (!assertionValueDict.TryGetValue(assertionValue.ParentId.GetId(), out var assertionList)) {
                    assertionList = new List<AssertionEntity>();
                    assertionValueDict[assertionValue.ParentId.GetId()] = assertionList;
                }
                assertionList.Add(assertionValue);
            }

            // 
            foreach (ResultConfigJsonDto resultConfigDto in resultConfigDtos) {
                var argumentValues = argumentValueDict.TryGetValue(resultConfigDto.Id, out var foundArguments) ? foundArguments : new List<ArgumentEntity>();
                var assertionValues = assertionValueDict.TryGetValue(resultConfigDto.Id, out var foundAssertions) ? foundAssertions : new List<AssertionEntity>();

                var resultEntity = new ResultEntity(
                    IdValue.FromString(resultConfigDto.Id),
                    PathValue.PathIsDirectory(resultConfigDto.PathName),
                    resultConfigDto.Title,
                    argumentValues,
                    assertionValues);
                _resultEntityDict.Add(resultEntity.Id,resultEntity);
            }
            return this;
        }

        public FactStatusBuilder OfRecordEntityDict(List<RecordConfigJsonDto> value) {
            foreach (RecordConfigJsonDto recordConfigDto in value) {
                var recordEntity = new RecordEntity(
                    IdValue.FromString(recordConfigDto.Id),
                    PathValue.PathIsDirectory(recordConfigDto.PathName),
                    recordConfigDto.Title,
                    recordConfigDto.Description,
                    DateTime.ParseExact(recordConfigDto.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    recordConfigDto.Reviewer,
                    BoolValue.FromString(recordConfigDto.Success));
                _recordEntityDict.Add(recordEntity.Id,recordEntity);
            }
            return this;
        }

        public FactStatusBuilder OfTodoEntityDict(List<TodoConfigJsonDto> value) {
            foreach (TodoConfigJsonDto todoConfigDto in value) {
                var todoEntity = new TodoEntity(
                    IdValue.FromString(todoConfigDto.Id),
                    PathValue.PathIsDirectory(todoConfigDto.PathName),
                    todoConfigDto.Title,
                    todoConfigDto.Description);
                _todoEntityDict.Add(todoEntity.Id,todoEntity);
            }
            return this;
        }


        public FactStatusBuilder OfSchemaEntityDict(List<SchemaConfigJsonDto> value) {
            // SchemaConfigに変換して追加
            foreach (SchemaConfigJsonDto schemaConfigDto in value) {
                var schemaEntity = new SchemaEntity(
                    IdValue.FromString(schemaConfigDto.Id),
                    PathValue.PathIsDirectory(schemaConfigDto.PathName),
                    schemaConfigDto.Title,
                    schemaConfigDto.Experience,
                    schemaConfigDto.Evaluation,
                    schemaConfigDto.Hypothesis,
                    schemaConfigDto.AbstractionGoal,
                    schemaConfigDto.ExecutionGoal);
                _schemaEntityDict.Add(schemaEntity.Id,schemaEntity);
            }
            return this;
        }

        public FactStatusBuilder OfGroupEntityDict(List<GroupConfigJsonDto> value) {
            // GroupConfigに変換して追加
            foreach (GroupConfigJsonDto groupConfigDto in value) {
                var groupEntity = new GroupEntity(
                    IdValue.FromString(groupConfigDto.Id),
                    PathValue.PathIsDirectory(groupConfigDto.PathName),
                    groupConfigDto.Title);
                _groupEntityDict.Add(groupEntity.Id,groupEntity);
            }
            return this;
        }

        public FactStatusBuilder OfParentLinkDict(List<ParentEdgeJsonDto> value) {
            // ParentEdgeに変換して追加
            foreach (ParentEdgeJsonDto parentEdgeDto in value) {
                _parentLinkDict.Add(new IdValue(parentEdgeDto.ToId), new IdValue(parentEdgeDto.FromId));
            }
            return this;
        }

        public FactStatusBuilder OfChildrenLinkDict(List<ParentEdgeJsonDto> value) {
            // ParentEdgeに変換して追加
            foreach (ParentEdgeJsonDto parentEdgeDto in value) {
                // ParentId をキーに List<ArgumentValue> を管理する
                if (!_childrenLinkDict.TryGetValue(new IdValue(parentEdgeDto.FromId), out var list)) {
                    list = new List<IdValue>();
                    _childrenLinkDict[new IdValue(parentEdgeDto.FromId)] = list;
                }
                list.Add(new IdValue(parentEdgeDto.ToId));
            }
            return this;
        }

        public FactStatusBuilder OfGroupLinkDict(List<GroupEdgeJsonDto> value) {
            // GroupEdgeに変換して追加
            foreach (GroupEdgeJsonDto groupEdgeDto in value) {
                // ParentId をキーに List<ArgumentValue> を管理する
                if (!_groupLinkDict.TryGetValue(new IdValue(groupEdgeDto.FromId), out var list)) {
                    list = new List<IdValue>();
                    _groupLinkDict[new IdValue(groupEdgeDto.FromId)] = list;
                }
                list.Add(new IdValue(groupEdgeDto.ToId)); 
            }
            return this;
        }

        /// <summary>
        /// FactStatusConfigの生成
        /// </summary>
        /// <returns></returns>
        public FactStatusConfig Build() {

            // FactStatusConfigの生成
            return new FactStatusConfig(
                _documentEntity,
                _subjectEntityDict,
                _achievementEntityDict,
                _evidenceEntityDict,
                _resultEntityDict,
                _recordEntityDict,
                _todoEntityDict,
                _schemaEntityDict,
                _groupEntityDict,
                _parentLinkDict,
                _childrenLinkDict,
                _groupLinkDict);
        }

        private int convertStringToInt(string s) {
            if (int.TryParse(s, out int result)) {
                return result;
            }
            else {
                throw new ArgumentException($"Invalid Int value: {s}");
            }
        }

        private DataTypeEnum convertDataTypeEnum(string dataType) {
            try {
                return (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), dataType, true);
            }
            catch (ArgumentException) {
                throw new ArgumentException($"Invalid DataType value: {dataType}");
            }
        }

        private AssertEnum convertAssertEnum(string assert) {
            try {
                return (AssertEnum)Enum.Parse(typeof(AssertEnum), assert, true);
            }
            catch (ArgumentException) {
                throw new ArgumentException($"Invalid Assert value: {assert}");
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusBuilder() {
            this._documentEntity = new DocumentEntity("");
            this._subjectEntityDict = new Dictionary<IdValue,SubjectEntity>();
            this._achievementEntityDict = new Dictionary<IdValue,AchievementEntity>();
            this._evidenceEntityDict = new Dictionary<IdValue,EvidenceEntity>();
            this._resultEntityDict = new Dictionary<IdValue,ResultEntity>();
            this._recordEntityDict = new Dictionary<IdValue,RecordEntity>();
            this._todoEntityDict = new Dictionary<IdValue,TodoEntity>();
            this._schemaEntityDict = new Dictionary<IdValue,SchemaEntity>();
            this._groupEntityDict = new Dictionary<IdValue,GroupEntity>();
            this._parentLinkDict = new Dictionary<IdValue, IdValue>();
            this._childrenLinkDict = new Dictionary<IdValue,List<IdValue>>();
            this._groupLinkDict = new Dictionary<IdValue,List<IdValue>>();
        }
    }
}
