using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Logic {
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
        private Dictionary<IdValue,ArgumentValue> _argumentEntityDict;
        private Dictionary<IdValue,AssertionValue> _assertionEntityDict;
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

        public FactStatusBuilder OfDocumentEntity(DocumentAggregateJsonDto value) {
            _documentEntity = new DocumentEntity(value.Description); ;
            return this;
        }

        //
        public FactStatusBuilder OfSubjectEntityDict(List<SubjectAggregateJsonDto> value) {
            foreach (SubjectAggregateJsonDto subjectAggregateDto in value) {
                var subjectEntity = new SubjectEntity(
                    IdValue.FromString(subjectAggregateDto.Id),
                    PathValue.PathIsDirectory(subjectAggregateDto.PathName),
                    subjectAggregateDto.Title,
                    subjectAggregateDto.Description);
                _subjectEntityDict.Add(subjectEntity.Id,subjectEntity);
            }
            return this;
        }

        public FactStatusBuilder OfAchievementEntityDict(List<AchievementAggregateJsonDto> value) {
            foreach (AchievementAggregateJsonDto achievementAggregateDto in value) {
                var achievementEntity = new AchievementEntity(
                    IdValue.FromString(achievementAggregateDto.Id),
                    PathValue.PathIsDirectory(achievementAggregateDto.PathName),
                    achievementAggregateDto.Title,
                    achievementAggregateDto.Description);
                _achievementEntityDict.Add(achievementEntity.Id,achievementEntity);
            }
            return this;
        }

        public FactStatusBuilder OfEvidenceEntityDict(List<EvidenceAggregateJsonDto> value) {
            foreach (EvidenceAggregateJsonDto evidenceAggregateDto in value) {
                var evidenceEntity = new EvidenceEntity(
                    IdValue.FromString(evidenceAggregateDto.Id),
                    PathValue.PathIsDirectory(evidenceAggregateDto.PathName),
                    evidenceAggregateDto.Title,
                    evidenceAggregateDto.Description,
                    BoolValue.FromString(evidenceAggregateDto.Success));
                _evidenceEntityDict.Add(evidenceEntity.Id,evidenceEntity);
            }
            return this;
        }

        public FactStatusBuilder OfResultEntityDict(
            List<ResultAggregateJsonDto> resultAggregateDtos,
            List<ArgumentPropertieJsonDto> argumentDtos,
            List<AssertionPropertieJsonDto> assertionDtos) {

            // 
            var argumentValueDict = new Dictionary<string,List<ArgumentValue>>();
            foreach (ArgumentPropertieJsonDto argumentDto in argumentDtos) {
                var argumentValue = new ArgumentValue(
                    IdValue.FromString(argumentDto.Id),
                    IdValue.FromString(argumentDto.ParentId),
                    convertStringToInt(argumentDto.ListIndex),
                    convertStringToInt(argumentDto.KeyIndex),
                    argumentDto.KeyName,
                    convertDataTypeEnum(argumentDto.DataType),
                    argumentDto.Value);

                // ParentId をキーに List<ArgumentValue> を管理する
                if (!argumentValueDict.TryGetValue(argumentValue.ParentId.GetId(), out var argumentList)) {
                    argumentList = new List<ArgumentValue>();
                    argumentValueDict[argumentValue.ParentId.GetId()] = argumentList;
                }
                argumentList.Add(argumentValue);
                _argumentEntityDict.Add(argumentValue.Id, argumentValue);
            }

            // 
            var assertionValueDict = new Dictionary<string,List<AssertionValue>>();
            foreach (AssertionPropertieJsonDto assertionDto in assertionDtos) {
                var assertionValue = new AssertionValue(
                    IdValue.FromString(assertionDto.Id),
                    IdValue.FromString(assertionDto.ParentId),
                    convertAssertEnum(assertionDto.Assert),
                    assertionDto.Target,
                    convertDataTypeEnum(assertionDto.DataType),
                    assertionDto.Value);

                // ParentId をキーに List<ArgumentValue> を管理する
                if (!assertionValueDict.TryGetValue(assertionValue.ParentId.GetId(), out var assertionList)) {
                    assertionList = new List<AssertionValue>();
                    assertionValueDict[assertionValue.ParentId.GetId()] = assertionList;
                }
                assertionList.Add(assertionValue);
                _assertionEntityDict.Add(assertionValue.Id, assertionValue);
            }

            // 
            foreach (ResultAggregateJsonDto resultAggregateDto in resultAggregateDtos) {
                var argumentValues = argumentValueDict.TryGetValue(resultAggregateDto.Id, out var foundArguments) ? foundArguments : new List<ArgumentValue>();
                var assertionValues = assertionValueDict.TryGetValue(resultAggregateDto.Id, out var foundAssertions) ? foundAssertions : new List<AssertionValue>();

                var resultEntity = new ResultEntity(
                    IdValue.FromString(resultAggregateDto.Id),
                    PathValue.PathIsDirectory(resultAggregateDto.PathName),
                    resultAggregateDto.Title,
                    argumentValues,
                    assertionValues);
                _resultEntityDict.Add(resultEntity.Id,resultEntity);
            }
            return this;
        }

        public FactStatusBuilder OfRecordEntityDict(List<RecordAggregateJsonDto> value) {
            foreach (RecordAggregateJsonDto recordAggregateDto in value) {
                var recordEntity = new RecordEntity(
                    IdValue.FromString(recordAggregateDto.Id),
                    PathValue.PathIsDirectory(recordAggregateDto.PathName),
                    recordAggregateDto.Title,
                    recordAggregateDto.Description,
                    DateTime.ParseExact(recordAggregateDto.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    recordAggregateDto.Reviewer,
                    BoolValue.FromString(recordAggregateDto.Success));
                _recordEntityDict.Add(recordEntity.Id,recordEntity);
            }
            return this;
        }

        public FactStatusBuilder OfTodoEntityDict(List<TodoAggregateJsonDto> value) {
            foreach (TodoAggregateJsonDto todoAggregateDto in value) {
                var todoEntity = new TodoEntity(
                    IdValue.FromString(todoAggregateDto.Id),
                    PathValue.PathIsDirectory(todoAggregateDto.PathName),
                    todoAggregateDto.Title,
                    todoAggregateDto.Description);
                _todoEntityDict.Add(todoEntity.Id,todoEntity);
            }
            return this;
        }


        public FactStatusBuilder OfSchemaEntityDict(List<SchemaAggregateJsonDto> value) {
            // SchemaAggregateに変換して追加
            foreach (SchemaAggregateJsonDto schemaAggregateDto in value) {
                var schemaEntity = new SchemaEntity(
                    IdValue.FromString(schemaAggregateDto.Id),
                    PathValue.PathIsDirectory(schemaAggregateDto.PathName),
                    schemaAggregateDto.Title,
                    schemaAggregateDto.Experience,
                    schemaAggregateDto.Evaluation,
                    schemaAggregateDto.Hypothesis,
                    schemaAggregateDto.AbstractionGoal,
                    schemaAggregateDto.ExecutionGoal);
                _schemaEntityDict.Add(schemaEntity.Id,schemaEntity);
            }
            return this;
        }

        public FactStatusBuilder OfGroupEntityDict(List<GroupAggregateJsonDto> value) {
            // GroupAggregateに変換して追加
            foreach (GroupAggregateJsonDto groupAggregateDto in value) {
                var groupEntity = new GroupEntity(
                    IdValue.FromString(groupAggregateDto.Id),
                    PathValue.PathIsDirectory(groupAggregateDto.PathName),
                    groupAggregateDto.Title);
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
        /// FactStatusAggregateの生成
        /// </summary>
        /// <returns></returns>
        public FactStatusAggregate Build() {

            // FactStatusAggregateの生成
            return new FactStatusAggregate(
                _documentEntity,
                _subjectEntityDict,
                _achievementEntityDict,
                _evidenceEntityDict,
                _resultEntityDict,
                _recordEntityDict,
                _todoEntityDict,
                _schemaEntityDict,
                _groupEntityDict,
                _argumentEntityDict,
                _assertionEntityDict,
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
            _documentEntity = new DocumentEntity("");
            _subjectEntityDict = new Dictionary<IdValue,SubjectEntity>();
            _achievementEntityDict = new Dictionary<IdValue,AchievementEntity>();
            _evidenceEntityDict = new Dictionary<IdValue,EvidenceEntity>();
            _resultEntityDict = new Dictionary<IdValue,ResultEntity>();
            _recordEntityDict = new Dictionary<IdValue,RecordEntity>();
            _todoEntityDict = new Dictionary<IdValue,TodoEntity>();
            _schemaEntityDict = new Dictionary<IdValue,SchemaEntity>();
            _groupEntityDict = new Dictionary<IdValue,GroupEntity>();
            _argumentEntityDict = new Dictionary<IdValue,ArgumentValue>();
            _assertionEntityDict = new Dictionary<IdValue,AssertionValue>();
            _parentLinkDict = new Dictionary<IdValue, IdValue>();
            _childrenLinkDict = new Dictionary<IdValue,List<IdValue>>();
            _groupLinkDict = new Dictionary<IdValue,List<IdValue>>();
        }
    }
}
