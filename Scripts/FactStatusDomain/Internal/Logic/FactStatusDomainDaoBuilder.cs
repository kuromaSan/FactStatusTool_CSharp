using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Logic {
    public class FactStatusDomainDaoBuilder {
        private DocumentAggregateJsonDto _documentAggregateDto;
        private List<SubjectAggregateJsonDto> _subjectAggregateDtos;
        private List<AchievementAggregateJsonDto> _achievementAggregateDtos;
        private List<EvidenceAggregateJsonDto> _evidenceAggregateDtos;
        private List<ResultAggregateJsonDto> _resultAggregateDtos;
        private List<RecordAggregateJsonDto> _recordAggregateDtos;
        private List<TodoAggregateJsonDto> _todoAggregateDtos;
        private List<SchemaAggregateJsonDto> _schemaAggregateDtos;
        private List<GroupAggregateJsonDto> _groupAggregateDtos;
        private List<ArgumentPropertieJsonDto> _argumentPropertieDtos;
        private List<AssertionPropertieJsonDto> _assertionPropertieDtos;
        private List<ParentEdgeJsonDto> _parentEdgeDtos;
        private List<GroupEdgeJsonDto> _groupEdgeDtos;

        public FactStatusDomainDaoBuilder OfDocumentAggregate(DocumentEntity value) {
            _documentAggregateDto = new DocumentAggregateJsonDto() {
                Id = value.Id.GetId(),
                PathName = value.PathName.Path,
                Title = value.Title,
                Description = value.Description
            };
            return this;
        }

        public FactStatusDomainDaoBuilder OfSubjectAggregates(List<SubjectEntity> value) {
            foreach (SubjectEntity subjectEntity in value) {
                SubjectAggregateJsonDto subjectDto = new() {
                    Id = subjectEntity.Id.GetId(),
                    PathName = subjectEntity.PathName.Path,
                    Title = subjectEntity.Title,
                    Description = subjectEntity.Description
                };
                _subjectAggregateDtos.Add(subjectDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfAchievementAggregates(List<AchievementEntity> value) {
            foreach (AchievementEntity achievementAggregate in value) {
                AchievementAggregateJsonDto achievementDto = new() {
                    Id = achievementAggregate.Id.GetId(),
                    PathName = achievementAggregate.PathName.Path,
                    Title = achievementAggregate.Title,
                    Description = achievementAggregate.Description
                };
                _achievementAggregateDtos.Add(achievementDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfEvidenceAggregates(List<EvidenceEntity> value) {
            foreach (EvidenceEntity evidenceAggregate in value) {
                EvidenceAggregateJsonDto evidenceDto = new() {
                    Id = evidenceAggregate.Id.GetId(),
                    PathName = evidenceAggregate.PathName.Path,
                    Title = evidenceAggregate.Title,
                    Description = evidenceAggregate.Description,
                    Success = evidenceAggregate.Success.ToStringOfNumber()
                };
                _evidenceAggregateDtos.Add(evidenceDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfResultAggregates(List<ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value) {
                ResultAggregateJsonDto resultDto = new() {
                    Id = resultAggregate.Id.GetId(),
                    PathName = resultAggregate.PathName.Path,
                    Title = resultAggregate.Title
                };
                _resultAggregateDtos.Add(resultDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfRecordAggregates(List<RecordEntity> value) {
            foreach (RecordEntity recordAggregate in value) {
                RecordAggregateJsonDto recordDto = new() {
                    Id = recordAggregate.Id.GetId(),
                    PathName = recordAggregate.PathName.Path,
                    Title = recordAggregate.Title,
                    Description = recordAggregate.Description,
                    Date = recordAggregate.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    Reviewer = recordAggregate.Reviewer,
                    Success = recordAggregate.Success.ToStringOfNumber()
                };
                _recordAggregateDtos.Add(recordDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfTodoAggregates(List<TodoEntity> value) {
            foreach (TodoEntity todoAggregate in value) {
                TodoAggregateJsonDto todoDto = new() {
                    Id = todoAggregate.Id.GetId(),
                    PathName = todoAggregate.PathName.Path,
                    Title = todoAggregate.Title,
                    Description = todoAggregate.Description
                };
                _todoAggregateDtos.Add(todoDto);
            }
            return this;
        }


        public FactStatusDomainDaoBuilder OfSchemaAggregates(List<SchemaEntity> value) {
            // SchemaAggregateに変換して追加
            foreach (SchemaEntity schemaAggregate in value) {
                SchemaAggregateJsonDto schemaDto = new() {
                    Id = schemaAggregate.Id.GetId(),
                    PathName = schemaAggregate.PathName.Path,
                    Title = schemaAggregate.Title,
                    Experience = schemaAggregate.Experience,
                    Evaluation = schemaAggregate.Evaluation,
                    Hypothesis = schemaAggregate.Hypothesis,
                    AbstractionGoal = schemaAggregate.AbstractionGoal,
                    ExecutionGoal = schemaAggregate.ExecutionGoal
                };
                _schemaAggregateDtos.Add(schemaDto);
            }
            return this;
        }
        
        public FactStatusDomainDaoBuilder OfGroupAggregates(List<GroupEntity> value) {
            // SchemaAggregateに変換して追加
            foreach (GroupEntity schemaAggregate in value) {
                GroupAggregateJsonDto groupAggregateDto = new() {
                    Id = schemaAggregate.Id.GetId(),
                    PathName = schemaAggregate.PathName.Path,
                    Title = schemaAggregate.Title
                };
                _groupAggregateDtos.Add(groupAggregateDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfArgumentProperties(List<ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value) {
                foreach (ArgumentValue argumentValue in resultAggregate.Arguments) {
                    ArgumentPropertieJsonDto argumentDto = new() {
                        ParentId = resultAggregate.Id.GetId(),
                        Id = argumentValue.Id.GetId(),
                        ListIndex = argumentValue.ListIndex.ToString(),
                        KeyIndex = argumentValue.KeyIndex.ToString(),
                        KeyName = argumentValue.KeyName,
                        DataType = argumentValue.DataType.ToString(),
                        Value = argumentValue.Value
                    };
                    _argumentPropertieDtos.Add(argumentDto);
                }
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfAssertionProperties(List<ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value) {
                foreach (AssertionValue assertionValue in resultAggregate.Assertions) {
                    AssertionPropertieJsonDto assertionDto = new() {
                        ParentId = resultAggregate.Id.GetId(),
                        Id = assertionValue.Id.GetId(),
                        Assert = assertionValue.Assert.ToString(),
                        Target = assertionValue.Target,
                        DataType = assertionValue.DataType.ToString(),
                        Value = assertionValue.Value
                    };
                    _assertionPropertieDtos.Add(assertionDto);
                }
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfParentEdges(Dictionary<string, string> dict) {
            // ParentEdgeDtoに変換して追加
            int index = 0;
            
            foreach (var kvp in dict) {

                string id = (index + 1).ToString("D4");
                string parentId = kvp.Value;
                string childId = kvp.Key;

                ParentEdgeJsonDto parentEdgeDto = new() {
                    Id = $"{id}0080",
                    FromId = parentId,
                    ToId = childId
                };
                _parentEdgeDtos.Add(parentEdgeDto);
            }
            return this;
        }
        
        public FactStatusDomainDaoBuilder OfGroupEdges(Dictionary<string, List<string>> dict) {
            // GroupEdgeDtoに変換して追加
            int index = 0;

            foreach (var kvp in dict) {
                string groupId = kvp.Key;
                List<string> entityIds = kvp.Value;

                for (int j = 0; j < entityIds.Count; j++) {
                    
                    index++;
                    string id = index.ToString("D4");
                    GroupEdgeJsonDto groupEdgeDto = new() {
                        Id = $"{id}0081",
                        FromId = groupId,
                        ToId = entityIds[j],
                        Sequence = j.ToString()
                    };
                    _groupEdgeDtos.Add(groupEdgeDto);
                }
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfSubjectAggregates(Dictionary<IdValue,SubjectEntity> value) {
            foreach (SubjectEntity subjectEntity in value.Values) {
                SubjectAggregateJsonDto subjectDto = new() {
                    Id = subjectEntity.Id.GetId(),
                    PathName = subjectEntity.PathName.Path,
                    Title = subjectEntity.Title,
                    Description = subjectEntity.Description
                };
                _subjectAggregateDtos.Add(subjectDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfAchievementAggregates(Dictionary<IdValue,AchievementEntity> value) {
            foreach (AchievementEntity achievementAggregate in value.Values) {
                AchievementAggregateJsonDto achievementDto = new() {
                    Id = achievementAggregate.Id.GetId(),
                    PathName = achievementAggregate.PathName.Path,
                    Title = achievementAggregate.Title,
                    Description = achievementAggregate.Description
                };
                _achievementAggregateDtos.Add(achievementDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfEvidenceAggregates(Dictionary<IdValue,EvidenceEntity> value) {
            foreach (EvidenceEntity evidenceAggregate in value.Values) {
                EvidenceAggregateJsonDto evidenceDto = new() {
                    Id = evidenceAggregate.Id.GetId(),
                    PathName = evidenceAggregate.PathName.Path,
                    Title = evidenceAggregate.Title,
                    Description = evidenceAggregate.Description,
                    Success = evidenceAggregate.Success.ToStringOfNumber()
                };
                _evidenceAggregateDtos.Add(evidenceDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfResultAggregates(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value.Values) {
                ResultAggregateJsonDto resultDto = new() {
                    Id = resultAggregate.Id.GetId(),
                    PathName = resultAggregate.PathName.Path,
                    Title = resultAggregate.Title
                };
                _resultAggregateDtos.Add(resultDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfRecordAggregates(Dictionary<IdValue,RecordEntity> value) {
            foreach (RecordEntity recordAggregate in value.Values) {
                RecordAggregateJsonDto recordDto = new() {
                    Id = recordAggregate.Id.GetId(),
                    PathName = recordAggregate.PathName.Path,
                    Title = recordAggregate.Title,
                    Description = recordAggregate.Description,
                    Date = recordAggregate.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    Reviewer = recordAggregate.Reviewer,
                    Success = recordAggregate.Success.ToStringOfNumber()
                };
                _recordAggregateDtos.Add(recordDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfTodoAggregates(Dictionary<IdValue,TodoEntity> value) {
            foreach (TodoEntity todoAggregate in value.Values) {
                TodoAggregateJsonDto todoDto = new() {
                    Id = todoAggregate.Id.GetId(),
                    PathName = todoAggregate.PathName.Path,
                    Title = todoAggregate.Title,
                    Description = todoAggregate.Description
                };
                _todoAggregateDtos.Add(todoDto);
            }
            return this;
        }


        public FactStatusDomainDaoBuilder OfSchemaAggregates(Dictionary<IdValue,SchemaEntity> value) {
            // SchemaAggregateに変換して追加
            foreach (SchemaEntity schemaAggregate in value.Values) {
                SchemaAggregateJsonDto schemaDto = new() {
                    Id = schemaAggregate.Id.GetId(),
                    PathName = schemaAggregate.PathName.Path,
                    Title = schemaAggregate.Title,
                    Experience = schemaAggregate.Experience,
                    Evaluation = schemaAggregate.Evaluation,
                    Hypothesis = schemaAggregate.Hypothesis,
                    AbstractionGoal = schemaAggregate.AbstractionGoal,
                    ExecutionGoal = schemaAggregate.ExecutionGoal
                };
                _schemaAggregateDtos.Add(schemaDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfGroupAggregates(Dictionary<IdValue,GroupEntity> value) {
            // SchemaAggregateに変換して追加
            foreach (GroupEntity schemaAggregate in value.Values) {
                GroupAggregateJsonDto groupAggregateDto = new() {
                    Id = schemaAggregate.Id.GetId(),
                    PathName = schemaAggregate.PathName.Path,
                    Title = schemaAggregate.Title
                };
                _groupAggregateDtos.Add(groupAggregateDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfArgumentProperties(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value.Values) {
                foreach (ArgumentValue argumentValue in resultAggregate.Arguments) {
                    ArgumentPropertieJsonDto argumentDto = new() {
                        ParentId = resultAggregate.Id.GetId(),
                        Id = argumentValue.Id.GetId(),
                        ListIndex = argumentValue.ListIndex.ToString(),
                        KeyIndex = argumentValue.KeyIndex.ToString(),
                        KeyName = argumentValue.KeyName,
                        DataType = argumentValue.DataType.ToString(),
                        Value = argumentValue.Value
                    };
                    _argumentPropertieDtos.Add(argumentDto);
                }
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfAssertionProperties(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultAggregate in value.Values) {
                foreach (AssertionValue assertionValue in resultAggregate.Assertions) {
                    AssertionPropertieJsonDto assertionDto = new() {
                        ParentId = resultAggregate.Id.GetId(),
                        Id = assertionValue.Id.GetId(),
                        Assert = assertionValue.Assert.ToString(),
                        Target = assertionValue.Target,
                        DataType = assertionValue.DataType.ToString(),
                        Value = assertionValue.Value
                    };
                    _assertionPropertieDtos.Add(assertionDto);
                }
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfParentEdges(Dictionary<IdValue, IdValue> value) {
            // ParentEdgeDtoに変換して追加
            int index = 0;

            foreach (var kvp in value) {

                string id = (index + 1).ToString("D4");
                string parentId = kvp.Value.GetId();
                string childId = kvp.Key.GetId();

                ParentEdgeJsonDto parentEdgeDto = new() {
                    Id = $"{id}0080",
                    FromId = parentId,
                    ToId = childId
                };
                _parentEdgeDtos.Add(parentEdgeDto);
            }
            return this;
        }

        public FactStatusDomainDaoBuilder OfGroupEdges(Dictionary<IdValue, List<IdValue>> dict) {
            // GroupEdgeDtoに変換して追加
            int index = 0;

            foreach (var kvp in dict) {
                string groupId = kvp.Key.GetId();
                List<IdValue> entityIdValues = kvp.Value;
                List<string> entityIds = entityIdValues.Select(idValue => idValue.GetId()).ToList();


                for (int j = 0; j < entityIds.Count; j++) {

                    index++;
                    string id = index.ToString("D4");
                    GroupEdgeJsonDto groupEdgeDto = new() {
                        Id = $"{id}0081",
                        FromId = groupId,
                        ToId = entityIds[j],
                        Sequence = j.ToString()
                    };
                    _groupEdgeDtos.Add(groupEdgeDto);
                }
            }
            return this;
        }

        /// <summary>
        /// JsonDtoの生成
        /// </summary>
        /// <returns></returns>
        public FactStatusDomainDao Build() {
            FactStatusDomainDao jsonByRelationalDto = new() {
                DocumentAggregate = _documentAggregateDto,
                SubjectAggregates = _subjectAggregateDtos,
                AchievementAggregates = _achievementAggregateDtos,
                EvidenceAggregates = _evidenceAggregateDtos,
                ResultAggregates = _resultAggregateDtos,
                RecordAggregates = _recordAggregateDtos,
                TodoAggregates = _todoAggregateDtos,
                SchemaAggregates = _schemaAggregateDtos,
                GroupAggregates = _groupAggregateDtos,
                ArgumentProperties = _argumentPropertieDtos,
                AssertionProperties = _assertionPropertieDtos,
                ParentEdges = _parentEdgeDtos,
                GroupEdges = _groupEdgeDtos
            };
            return jsonByRelationalDto;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusDomainDaoBuilder() {
            _documentAggregateDto = new DocumentAggregateJsonDto {
                Id = "00010000",
                PathName = "Documents",
                Title = "ドキュメント",
                Description = ""
            };
            _subjectAggregateDtos = new List<SubjectAggregateJsonDto>();
            _achievementAggregateDtos = new List<AchievementAggregateJsonDto>();
            _evidenceAggregateDtos = new List<EvidenceAggregateJsonDto>();
            _resultAggregateDtos = new List<ResultAggregateJsonDto>();
            _recordAggregateDtos = new List<RecordAggregateJsonDto>();
            _todoAggregateDtos = new List<TodoAggregateJsonDto>();
            _schemaAggregateDtos = new List<SchemaAggregateJsonDto>();
            _groupAggregateDtos = new List<GroupAggregateJsonDto>();
            _argumentPropertieDtos = new List<ArgumentPropertieJsonDto>();
            _assertionPropertieDtos = new List<AssertionPropertieJsonDto>();
            _parentEdgeDtos = new List<ParentEdgeJsonDto>();
            _groupEdgeDtos = new List<GroupEdgeJsonDto>();
        }
    }
}
