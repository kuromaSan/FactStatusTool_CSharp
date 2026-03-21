using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Model;
using FactStatus.Domain.Value;
using FactStatus.Domain.Setup;

namespace FactStatus.Domain.Logic {
    public class FactStatusStrategy {
        private readonly IFactStatusRepository _factStatusRepository;
        private readonly IJsonRepository _jsonRepository;
        private readonly IMarkdownRepository _markdownRepository;

        public DocumentEntity GetDocumentEntity(
            FactStatusConfig factStatusConfig) {
            return factStatusConfig.DocumentEntity;
        }
        
        public SubjectEntity GetSubjectEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetSubjectEntity(idValue);
        }

        public AchievementEntity GetAchievementEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetAchievementEntity(idValue);
        }

        public EvidenceEntity GetEvidenceEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetEvidenceEntity(idValue);
        }

        public ResultEntity GetResultEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetResultEntity(idValue);
        }

        public RecordEntity GetRecordEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetRecordEntity(idValue);
        }

        public TodoEntity GetTodoEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetTodoEntity(idValue);
        }

        public SchemaEntity GetSchemaEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetSchemaEntity(idValue);
        }

        public GroupEntity GetGroupEntity(
            FactStatusConfig factStatusConfig,
            IdValue idValue) {
            return factStatusConfig.GetGroupEntity(idValue);
        }

        public Dictionary<IdValue, SubjectEntity> GetSubjectEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.SubjectEntityDict;
        }
        
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.AchievementEntityDict;
        }

        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.EvidenceEntityDict;
        }

        public Dictionary<IdValue, ResultEntity> GetResultEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.ResultEntityDict;
        }

        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.RecordEntityDict;
        }

        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.TodoEntityDict;
        }

        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.SchemaEntityDict;
        }

        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict(FactStatusConfig factStatusConfig) {
            return factStatusConfig.GroupEntityDict;
        }

        /// <summary>
        /// リレーショナル型を読込
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusConfig LoadRelational(PathValue filePath) {
            // jsonファイルを読み込み
            JsonDto relationalDto = _factStatusRepository.LoadRelational(filePath);

            // factStatusConfigに変換
            var factStatusBuilder = new FactStatusBuilder();
            factStatusBuilder.OfSubjectEntityDict(relationalDto.SubjectConfigs);
            factStatusBuilder.OfAchievementEntityDict(relationalDto.AchievementConfigs);
            factStatusBuilder.OfEvidenceEntityDict(relationalDto.EvidenceConfigs);
            factStatusBuilder.OfResultEntityDict(relationalDto.ResultConfigs, relationalDto.ArgumentProperties, relationalDto.AssertionProperties);
            factStatusBuilder.OfRecordEntityDict(relationalDto.RecordConfigs);
            factStatusBuilder.OfTodoEntityDict(relationalDto.TodoConfigs);
            factStatusBuilder.OfSchemaEntityDict(relationalDto.SchemaConfigs);
            factStatusBuilder.OfGroupEntityDict(relationalDto.GroupConfigs);
            factStatusBuilder.OfParentLinkDict(relationalDto.ParentEdges);
            factStatusBuilder.OfChildrenLinkDict(relationalDto.ParentEdges);
            factStatusBuilder.OfGroupLinkDict(relationalDto.GroupEdges);
            FactStatusConfig factStatusConfig = factStatusBuilder.Build();

            return factStatusConfig;
        }

        /// <summary>
        /// リレーショナル型を保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="factStatusConfig"></param>
        public void SaveRelational(PathValue filePath, FactStatusConfig factStatusConfig) {
            // factStatusConfigをRelationalDtoに変換
            var relationalDtoBuilder = new JsonDtoBuilder();
            relationalDtoBuilder.OfDocumentConfig(factStatusConfig.DocumentEntity);
            relationalDtoBuilder.OfSubjectConfigs(factStatusConfig.SubjectEntityDict);
            relationalDtoBuilder.OfAchievementConfigs(factStatusConfig.AchievementEntityDict);
            relationalDtoBuilder.OfEvidenceConfigs(factStatusConfig.EvidenceEntityDict);
            relationalDtoBuilder.OfResultConfigs(factStatusConfig.ResultEntityDict);
            relationalDtoBuilder.OfRecordConfigs(factStatusConfig.RecordEntityDict);
            relationalDtoBuilder.OfTodoConfigs(factStatusConfig.TodoEntityDict);
            relationalDtoBuilder.OfSchemaConfigs(factStatusConfig.SchemaEntityDict);
            relationalDtoBuilder.OfGroupConfigs(factStatusConfig.GroupEntityDict);
            relationalDtoBuilder.OfArgumentProperties(factStatusConfig.ResultEntityDict);
            relationalDtoBuilder.OfAssertionProperties(factStatusConfig.ResultEntityDict);
            relationalDtoBuilder.OfParentEdges(factStatusConfig.ParentLinkDict);
            relationalDtoBuilder.OfGroupEdges(factStatusConfig.GroupLinkDict);
            JsonDto relationalDto = relationalDtoBuilder.Build();

            // jsonファイルを保存
            _factStatusRepository.SaveRelational(filePath, relationalDto);
        }

        /// <summary>
        /// JSONファイルを読込
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FactStatusConfig LoadJson(PathValue filePath) {
            // jsonファイルを読み込み
            JsonDto jsonDto = _jsonRepository.LoadJson(filePath);

            // factStatusConfigに変換
            var factStatusBuilder = new FactStatusBuilder();
            factStatusBuilder.OfSubjectEntityDict(jsonDto.SubjectConfigs);
            factStatusBuilder.OfAchievementEntityDict(jsonDto.AchievementConfigs);
            factStatusBuilder.OfEvidenceEntityDict(jsonDto.EvidenceConfigs);
            factStatusBuilder.OfResultEntityDict(jsonDto.ResultConfigs, jsonDto.ArgumentProperties, jsonDto.AssertionProperties);
            factStatusBuilder.OfRecordEntityDict(jsonDto.RecordConfigs);
            factStatusBuilder.OfTodoEntityDict(jsonDto.TodoConfigs);
            factStatusBuilder.OfSchemaEntityDict(jsonDto.SchemaConfigs);
            factStatusBuilder.OfGroupEntityDict(jsonDto.GroupConfigs);
            factStatusBuilder.OfParentLinkDict(jsonDto.ParentEdges);
            factStatusBuilder.OfChildrenLinkDict(jsonDto.ParentEdges);
            factStatusBuilder.OfGroupLinkDict(jsonDto.GroupEdges);
            FactStatusConfig factStatusConfig = factStatusBuilder.Build();

            return factStatusConfig;
        }

        /// <summary>
        /// JSONファイルを保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="factStatusConfig"></param>
        public void SaveJson(PathValue filePath, FactStatusConfig factStatusConfig) {
            // factStatusConfigをRelationalDataDtoに変換
            var jsonDtoBuilder = new JsonDtoBuilder();
            jsonDtoBuilder.OfDocumentConfig(factStatusConfig.DocumentEntity);
            jsonDtoBuilder.OfSubjectConfigs(factStatusConfig.SubjectEntityDict);
            jsonDtoBuilder.OfAchievementConfigs(factStatusConfig.AchievementEntityDict);
            jsonDtoBuilder.OfEvidenceConfigs(factStatusConfig.EvidenceEntityDict);
            jsonDtoBuilder.OfResultConfigs(factStatusConfig.ResultEntityDict);
            jsonDtoBuilder.OfRecordConfigs(factStatusConfig.RecordEntityDict);
            jsonDtoBuilder.OfTodoConfigs(factStatusConfig.TodoEntityDict);
            jsonDtoBuilder.OfSchemaConfigs(factStatusConfig.SchemaEntityDict);
            jsonDtoBuilder.OfGroupConfigs(factStatusConfig.GroupEntityDict);
            jsonDtoBuilder.OfArgumentProperties(factStatusConfig.ResultEntityDict);
            jsonDtoBuilder.OfAssertionProperties(factStatusConfig.ResultEntityDict);
            jsonDtoBuilder.OfParentEdges(factStatusConfig.ParentLinkDict);
            jsonDtoBuilder.OfGroupEdges(factStatusConfig.GroupLinkDict);
            JsonDto jsonDto = jsonDtoBuilder.Build();

            // jsonファイルを保存
            _jsonRepository.SaveJson(filePath, jsonDto);
        }

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
