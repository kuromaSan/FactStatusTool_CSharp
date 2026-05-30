using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Model;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Setup {
    public class JsonDtoBuilder {
        private DocumentConfigJsonDto _documentConfigDto;
        private List<SubjectConfigJsonDto> _subjectConfigDtos;
        private List<AchievementConfigJsonDto> _achievementConfigDtos;
        private List<EvidenceConfigJsonDto> _evidenceConfigDtos;
        private List<ResultConfigJsonDto> _resultConfigDtos;
        private List<RecordConfigJsonDto> _recordConfigDtos;
        private List<TodoConfigJsonDto> _todoConfigDtos;
        private List<SchemaConfigJsonDto> _schemaConfigDtos;
        private List<GroupConfigJsonDto> _groupConfigDtos;
        private List<ArgumentPropertieJsonDto> _argumentPropertieDtos;
        private List<AssertionPropertieJsonDto> _assertionPropertieDtos;
        private List<ParentEdgeJsonDto> _parentEdgeDtos;
        private List<GroupEdgeJsonDto> _groupEdgeDtos;

        public JsonDtoBuilder OfDocumentConfig(DocumentEntity value) {
            _documentConfigDto = new DocumentConfigJsonDto() {
                Id = value.Id.GetId(),
                PathName = value.PathName.Path,
                Title = value.Title,
                Description = value.Description
            };
            return this;
        }

        public JsonDtoBuilder OfSubjectConfigs(List<SubjectEntity> value) {
            foreach (SubjectEntity subjectEntity in value) {
                SubjectConfigJsonDto subjectDto = new() {
                    Id = subjectEntity.Id.GetId(),
                    PathName = subjectEntity.PathName.Path,
                    Title = subjectEntity.Title,
                    Description = subjectEntity.Description
                };
                _subjectConfigDtos.Add(subjectDto);
            }
            return this;
        }

        public JsonDtoBuilder OfAchievementConfigs(List<AchievementEntity> value) {
            foreach (AchievementEntity achievementConfig in value) {
                AchievementConfigJsonDto achievementDto = new() {
                    Id = achievementConfig.Id.GetId(),
                    PathName = achievementConfig.PathName.Path,
                    Title = achievementConfig.Title,
                    Description = achievementConfig.Description
                };
                _achievementConfigDtos.Add(achievementDto);
            }
            return this;
        }

        public JsonDtoBuilder OfEvidenceConfigs(List<EvidenceEntity> value) {
            foreach (EvidenceEntity evidenceConfig in value) {
                EvidenceConfigJsonDto evidenceDto = new() {
                    Id = evidenceConfig.Id.GetId(),
                    PathName = evidenceConfig.PathName.Path,
                    Title = evidenceConfig.Title,
                    Description = evidenceConfig.Description,
                    Success = evidenceConfig.Success.ToStringOfNumber()
                };
                _evidenceConfigDtos.Add(evidenceDto);
            }
            return this;
        }

        public JsonDtoBuilder OfResultConfigs(List<ResultEntity> value) {
            foreach (ResultEntity resultConfig in value) {
                ResultConfigJsonDto resultDto = new() {
                    Id = resultConfig.Id.GetId(),
                    PathName = resultConfig.PathName.Path,
                    Title = resultConfig.Title
                };
                _resultConfigDtos.Add(resultDto);
            }
            return this;
        }

        public JsonDtoBuilder OfRecordConfigs(List<RecordEntity> value) {
            foreach (RecordEntity recordConfig in value) {
                RecordConfigJsonDto recordDto = new() {
                    Id = recordConfig.Id.GetId(),
                    PathName = recordConfig.PathName.Path,
                    Title = recordConfig.Title,
                    Description = recordConfig.Description,
                    Date = recordConfig.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    Reviewer = recordConfig.Reviewer,
                    Success = recordConfig.Success.ToStringOfNumber()
                };
                _recordConfigDtos.Add(recordDto);
            }
            return this;
        }

        public JsonDtoBuilder OfTodoConfigs(List<TodoEntity> value) {
            foreach (TodoEntity todoConfig in value) {
                TodoConfigJsonDto todoDto = new() {
                    Id = todoConfig.Id.GetId(),
                    PathName = todoConfig.PathName.Path,
                    Title = todoConfig.Title,
                    Description = todoConfig.Description
                };
                _todoConfigDtos.Add(todoDto);
            }
            return this;
        }


        public JsonDtoBuilder OfSchemaConfigs(List<SchemaEntity> value) {
            // SchemaConfigに変換して追加
            foreach (SchemaEntity schemaConfig in value) {
                SchemaConfigJsonDto schemaDto = new() {
                    Id = schemaConfig.Id.GetId(),
                    PathName = schemaConfig.PathName.Path,
                    Title = schemaConfig.Title,
                    Experience = schemaConfig.Experience,
                    Evaluation = schemaConfig.Evaluation,
                    Hypothesis = schemaConfig.Hypothesis,
                    AbstractionGoal = schemaConfig.AbstractionGoal,
                    ExecutionGoal = schemaConfig.ExecutionGoal
                };
                _schemaConfigDtos.Add(schemaDto);
            }
            return this;
        }
        
        public JsonDtoBuilder OfGroupConfigs(List<GroupEntity> value) {
            // SchemaConfigに変換して追加
            foreach (GroupEntity schemaConfig in value) {
                GroupConfigJsonDto groupConfigDto = new() {
                    Id = schemaConfig.Id.GetId(),
                    PathName = schemaConfig.PathName.Path,
                    Title = schemaConfig.Title
                };
                _groupConfigDtos.Add(groupConfigDto);
            }
            return this;
        }

        public JsonDtoBuilder OfArgumentProperties(List<ResultEntity> value) {
            foreach (ResultEntity resultConfig in value) {
                foreach (ArgumentEntity argumentValue in resultConfig.Arguments) {
                    ArgumentPropertieJsonDto argumentDto = new() {
                        ParentId = resultConfig.Id.GetId(),
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

        public JsonDtoBuilder OfAssertionProperties(List<ResultEntity> value) {
            foreach (ResultEntity resultConfig in value) {
                foreach (AssertionEntity assertionValue in resultConfig.Assertions) {
                    AssertionPropertieJsonDto assertionDto = new() {
                        ParentId = resultConfig.Id.GetId(),
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

        public JsonDtoBuilder OfParentEdges(Dictionary<string, string> dict) {
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
        
        public JsonDtoBuilder OfGroupEdges(Dictionary<string, List<string>> dict) {
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

        public JsonDtoBuilder OfSubjectConfigs(Dictionary<IdValue,SubjectEntity> value) {
            foreach (SubjectEntity subjectEntity in value.Values) {
                SubjectConfigJsonDto subjectDto = new() {
                    Id = subjectEntity.Id.GetId(),
                    PathName = subjectEntity.PathName.Path,
                    Title = subjectEntity.Title,
                    Description = subjectEntity.Description
                };
                _subjectConfigDtos.Add(subjectDto);
            }
            return this;
        }

        public JsonDtoBuilder OfAchievementConfigs(Dictionary<IdValue,AchievementEntity> value) {
            foreach (AchievementEntity achievementConfig in value.Values) {
                AchievementConfigJsonDto achievementDto = new() {
                    Id = achievementConfig.Id.GetId(),
                    PathName = achievementConfig.PathName.Path,
                    Title = achievementConfig.Title,
                    Description = achievementConfig.Description
                };
                _achievementConfigDtos.Add(achievementDto);
            }
            return this;
        }

        public JsonDtoBuilder OfEvidenceConfigs(Dictionary<IdValue,EvidenceEntity> value) {
            foreach (EvidenceEntity evidenceConfig in value.Values) {
                EvidenceConfigJsonDto evidenceDto = new() {
                    Id = evidenceConfig.Id.GetId(),
                    PathName = evidenceConfig.PathName.Path,
                    Title = evidenceConfig.Title,
                    Description = evidenceConfig.Description,
                    Success = evidenceConfig.Success.ToStringOfNumber()
                };
                _evidenceConfigDtos.Add(evidenceDto);
            }
            return this;
        }

        public JsonDtoBuilder OfResultConfigs(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultConfig in value.Values) {
                ResultConfigJsonDto resultDto = new() {
                    Id = resultConfig.Id.GetId(),
                    PathName = resultConfig.PathName.Path,
                    Title = resultConfig.Title
                };
                _resultConfigDtos.Add(resultDto);
            }
            return this;
        }

        public JsonDtoBuilder OfRecordConfigs(Dictionary<IdValue,RecordEntity> value) {
            foreach (RecordEntity recordConfig in value.Values) {
                RecordConfigJsonDto recordDto = new() {
                    Id = recordConfig.Id.GetId(),
                    PathName = recordConfig.PathName.Path,
                    Title = recordConfig.Title,
                    Description = recordConfig.Description,
                    Date = recordConfig.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    Reviewer = recordConfig.Reviewer,
                    Success = recordConfig.Success.ToStringOfNumber()
                };
                _recordConfigDtos.Add(recordDto);
            }
            return this;
        }

        public JsonDtoBuilder OfTodoConfigs(Dictionary<IdValue,TodoEntity> value) {
            foreach (TodoEntity todoConfig in value.Values) {
                TodoConfigJsonDto todoDto = new() {
                    Id = todoConfig.Id.GetId(),
                    PathName = todoConfig.PathName.Path,
                    Title = todoConfig.Title,
                    Description = todoConfig.Description
                };
                _todoConfigDtos.Add(todoDto);
            }
            return this;
        }


        public JsonDtoBuilder OfSchemaConfigs(Dictionary<IdValue,SchemaEntity> value) {
            // SchemaConfigに変換して追加
            foreach (SchemaEntity schemaConfig in value.Values) {
                SchemaConfigJsonDto schemaDto = new() {
                    Id = schemaConfig.Id.GetId(),
                    PathName = schemaConfig.PathName.Path,
                    Title = schemaConfig.Title,
                    Experience = schemaConfig.Experience,
                    Evaluation = schemaConfig.Evaluation,
                    Hypothesis = schemaConfig.Hypothesis,
                    AbstractionGoal = schemaConfig.AbstractionGoal,
                    ExecutionGoal = schemaConfig.ExecutionGoal
                };
                _schemaConfigDtos.Add(schemaDto);
            }
            return this;
        }

        public JsonDtoBuilder OfGroupConfigs(Dictionary<IdValue,GroupEntity> value) {
            // SchemaConfigに変換して追加
            foreach (GroupEntity schemaConfig in value.Values) {
                GroupConfigJsonDto groupConfigDto = new() {
                    Id = schemaConfig.Id.GetId(),
                    PathName = schemaConfig.PathName.Path,
                    Title = schemaConfig.Title
                };
                _groupConfigDtos.Add(groupConfigDto);
            }
            return this;
        }

        public JsonDtoBuilder OfArgumentProperties(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultConfig in value.Values) {
                foreach (ArgumentEntity argumentValue in resultConfig.Arguments) {
                    ArgumentPropertieJsonDto argumentDto = new() {
                        ParentId = resultConfig.Id.GetId(),
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

        public JsonDtoBuilder OfAssertionProperties(Dictionary<IdValue,ResultEntity> value) {
            foreach (ResultEntity resultConfig in value.Values) {
                foreach (AssertionEntity assertionValue in resultConfig.Assertions) {
                    AssertionPropertieJsonDto assertionDto = new() {
                        ParentId = resultConfig.Id.GetId(),
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

        public JsonDtoBuilder OfParentEdges(Dictionary<IdValue, IdValue> value) {
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

        public JsonDtoBuilder OfGroupEdges(Dictionary<IdValue, List<IdValue>> dict) {
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
        public JsonDto Build() {
            JsonDto jsonByRelationalDto = new() {
                DocumentConfig = _documentConfigDto,
                SubjectConfigs = _subjectConfigDtos,
                AchievementConfigs = _achievementConfigDtos,
                EvidenceConfigs = _evidenceConfigDtos,
                ResultConfigs = _resultConfigDtos,
                RecordConfigs = _recordConfigDtos,
                TodoConfigs = _todoConfigDtos,
                SchemaConfigs = _schemaConfigDtos,
                GroupConfigs = _groupConfigDtos,
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
        public JsonDtoBuilder() {
            _documentConfigDto = new DocumentConfigJsonDto {
                Id = "00010000",
                PathName = "Documents",
                Title = "ドキュメント",
                Description = ""
            };
            _subjectConfigDtos = new List<SubjectConfigJsonDto>();
            _achievementConfigDtos = new List<AchievementConfigJsonDto>();
            _evidenceConfigDtos = new List<EvidenceConfigJsonDto>();
            _resultConfigDtos = new List<ResultConfigJsonDto>();
            _recordConfigDtos = new List<RecordConfigJsonDto>();
            _todoConfigDtos = new List<TodoConfigJsonDto>();
            _schemaConfigDtos = new List<SchemaConfigJsonDto>();
            _groupConfigDtos = new List<GroupConfigJsonDto>();
            _argumentPropertieDtos = new List<ArgumentPropertieJsonDto>();
            _assertionPropertieDtos = new List<AssertionPropertieJsonDto>();
            _parentEdgeDtos = new List<ParentEdgeJsonDto>();
            _groupEdgeDtos = new List<GroupEdgeJsonDto>();
        }
    }
}
