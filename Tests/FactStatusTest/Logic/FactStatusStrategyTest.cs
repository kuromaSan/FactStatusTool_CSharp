using System.Collections.Generic;
using System.Linq;
using Domain.Test.TestSupport;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Model;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using Moq;
using Xunit;

namespace Domain.Test.Logic {
    public class FactStatusStrategyTest {
        [Fact]
        public void GetDocumentEntity_ドキュメントエンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetDocumentEntity(Aggregate);

            Assert.Equal("doc", entity.Description);
        }

        [Fact]
        public void GetSubjectEntity_主題エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00020002");

            var entity = strategy.GetSubjectEntity(Aggregate, id);

            Assert.Equal("subject-1", entity.Title);
        }

        [Fact]
        public void GetAchievementEntity_達成エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetAchievementEntity(Aggregate, IdValue.FromString("00030003"));

            Assert.Equal("achievement", entity.Title);
        }

        [Fact]
        public void GetEvidenceEntity_証拠エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetEvidenceEntity(Aggregate, IdValue.FromString("00040004"));

            Assert.Equal("evidence", entity.Title);
        }

        [Fact]
        public void GetResultEntity_結果エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetResultEntity(Aggregate, IdValue.FromString("00050005"));

            Assert.Equal("result", entity.Title);
        }

        [Fact]
        public void GetRecordEntity_記録エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetRecordEntity(Aggregate, IdValue.FromString("00060006"));

            Assert.Equal("record", entity.Title);
        }

        [Fact]
        public void GetTodoEntity_実装エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetTodoEntity(Aggregate, IdValue.FromString("00070007"));

            Assert.Equal("todo", entity.Title);
        }

        [Fact]
        public void GetSchemaEntity_構想エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetSchemaEntity(Aggregate, IdValue.FromString("00080008"));

            Assert.Equal("schema", entity.Title);
        }

        [Fact]
        public void GetGroupEntity_集合エンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetGroupEntity(Aggregate, IdValue.FromString("00090009"));

            Assert.Equal("group", entity.Title);
        }

        [Fact]
        public void GetSubjectEntityDict_主題エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetSubjectEntityDict(Aggregate);

            Assert.Equal(2, dict.Count);
        }

        [Fact]
        public void GetAchievementEntityDict_達成エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetAchievementEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetEvidenceEntityDict_証拠エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetEvidenceEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetResultEntityDict_結果エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetResultEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetRecordEntityDict_記録エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetRecordEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetTodoEntityDict_実装エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetTodoEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetSchemaEntityDict_構想エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetSchemaEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetGroupEntityDict_集合エンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetGroupEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void CreateIdValue_未使用のIDを生成できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var id = strategy.CreateIdValue(Aggregate, IdTypeEnum.Achievement);

            Assert.Equal("00010003", id.GetId());
        }

        [Fact]
        public void CreateEntity_主題エンティティを作成できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var id = IdValue.FromString("00020002");
            var path = PathValue.PathIsDirectory("created-subject");

            var result = strategy.CreateEntity(Aggregate, id, "created", path);

            Assert.Single(result.SubjectEntityDict);
            Assert.Equal("created", result.GetSubjectEntity(id).Title);
        }

        [Fact]
        public void DeleteEntity_主題エンティティを削除できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00020002");

            var result = strategy.DeleteEntity(Aggregate, id);

            Assert.Single(result.SubjectEntityDict);
            Assert.DoesNotContain(result.SubjectEntityDict, kv => kv.Key.GetId() == id.GetId());
            Assert.DoesNotContain(result.ParentLinkDict.Keys, key => key.GetId() == "00030003");
        }

        [Fact]
        public void DeleteEntity_元の親子接続を削除できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var childId = IdValue.FromString("00030003");
            var oldParentId = IdValue.FromString("00020002");
            var newParentId = IdValue.FromString("00100002");
            var linked = strategy.LinkEntity(Aggregate, newParentId, childId);

            var result = strategy.DeleteEntity(linked, childId);

            var oldParentChildren = result.ChildrenLinkDict
                .Where(kv => kv.Key.GetId() == oldParentId.GetId())
                .SelectMany(kv => kv.Value);
            Assert.DoesNotContain(oldParentChildren, child => child.GetId() == childId.GetId());
        }

        [Fact]
        public void LinkEntity_親子リンクを追加できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var parentId = IdValue.FromString("00010002");
            var childId = IdValue.FromString("00020003");

            var result = strategy.LinkEntity(Aggregate, parentId, childId);

            Assert.Equal(parentId, result.ParentLinkDict[childId]);
            Assert.Single(result.ChildrenLinkDict[parentId]);
        }

        [Fact]
        public void GetEntitiesByIdValues_ID一覧からエンティティ一覧を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var ids = new List<IdValue> {
                IdValue.FromString("00030003"),
                IdValue.FromString("00040004")
            };

            var entities = strategy.GetEntitiesByIdValues(Aggregate, ids);

            Assert.Equal(2, entities.Count);
            Assert.Equal("achievement", entities[0].Title);
            Assert.Equal("evidence", entities[1].Title);
        }

        [Fact]
        public void GetIdEntityByIdValue_IDからエンティティを取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = strategy.GetIdEntityByIdValue(Aggregate, IdValue.FromString("00030003"));

            Assert.Equal("achievement", entity.Title);
        }

        [Fact]
        public void GetEntityDictByIdTypeEnum_IDタイプからエンティティ辞書を取得できる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = strategy.GetEntityDictByIdTypeEnum(Aggregate, IdTypeEnum.Evidence);

            Assert.Single(dict);
            Assert.Equal("evidence", dict.Values.First().Title);
        }

        [Fact]
        public void CopyEntity_主題エンティティをコピーできる() {
            var strategy = FactStatusTestHelper.CreateStrategy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var sourceId = IdValue.FromString("00020002");
            var destinationId = IdValue.FromString("00110002");

            var result = strategy.CopyEntity(Aggregate, sourceId, destinationId);

            Assert.Equal(3, result.SubjectEntityDict.Count);
            Assert.Equal("subject-1", result.GetSubjectEntity(destinationId).Title);
            Assert.Equal("subject10001", result.GetSubjectEntity(destinationId).PathName.Path);
        }

        [Fact]
        public void LoadRelational_リレーショナル型を読込できる() {
            var jsonDto = FactStatusTestHelper.CreateEmptyJsonDto();
            var mockRepo = new Mock<IFactStatusRepository>();
            mockRepo.Setup(r => r.LoadRelational(It.IsAny<PathValue>())).Returns(jsonDto);
            var strategy = FactStatusTestHelper.CreateStrategy(factStatusRepository: mockRepo);

            var Aggregate = strategy.LoadRelational(new PathValue("data.json", PathTypeEnum.RootFile));

            Assert.NotNull(Aggregate);
            Assert.Empty(Aggregate.SubjectEntityDict);
        }

        [Fact]
        public void SaveRelational_リレーショナル型を保存できる() {
            var mockRepo = new Mock<IFactStatusRepository>();
            var strategy = FactStatusTestHelper.CreateStrategy(factStatusRepository: mockRepo);
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var path = new PathValue("data.json", PathTypeEnum.RootFile);

            strategy.SaveRelational(path, Aggregate);

            mockRepo.Verify(r => r.SaveRelational(path, It.IsAny<JsonDto>()), Times.Once);
        }

        [Fact]
        public void LoadJson_JSONを読込できる() {
            var jsonDto = FactStatusTestHelper.CreateEmptyJsonDto();
            var mockRepo = new Mock<IJsonRepository>();
            mockRepo.Setup(r => r.LoadJson(It.IsAny<PathValue>())).Returns(jsonDto);
            var strategy = FactStatusTestHelper.CreateStrategy(jsonRepository: mockRepo);

            var Aggregate = strategy.LoadJson(new PathValue("data.json", PathTypeEnum.RootFile));

            Assert.NotNull(Aggregate);
            Assert.Empty(Aggregate.AchievementEntityDict);
        }

        [Fact]
        public void SaveJson_JSONを保存できる() {
            var mockRepo = new Mock<IJsonRepository>();
            var strategy = FactStatusTestHelper.CreateStrategy(jsonRepository: mockRepo);
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var path = new PathValue("data.json", PathTypeEnum.RootFile);

            strategy.SaveJson(path, Aggregate);

            mockRepo.Verify(r => r.SaveJson(path, It.IsAny<JsonDto>()), Times.Once);
        }
    }
}
