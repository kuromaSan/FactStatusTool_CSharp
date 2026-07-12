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
    public class FactStatusPolicyTest {
        [Fact]
        public void GetParentIdEntity_親エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetParentIdEntity(Aggregate, "00030003");

            Assert.Equal("subject-1", entity.Title);
        }

        [Fact]
        public void GetChildrenIdEntityList_子エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entities = policy.GetChildrenIdEntityList(Aggregate, "00020002");

            Assert.Single(entities);
            Assert.Equal("achievement", entities[0].Title);
        }

        [Fact]
        public void GetDocumentEntity_ドキュメントエンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetDocumentEntity(Aggregate);

            Assert.Equal("doc", entity.Description);
        }

        [Fact]
        public void GetSubjectEntity_主題エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetSubjectEntity(Aggregate, "00020002");

            Assert.Equal("subject-1", entity.Title);
        }

        [Fact]
        public void GetAchievementEntity_達成エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetAchievementEntity(Aggregate, "00030003");

            Assert.Equal("achievement", entity.Title);
        }

        [Fact]
        public void GetEvidenceEntity_証拠エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetEvidenceEntity(Aggregate, "00040004");

            Assert.Equal("evidence", entity.Title);
        }

        [Fact]
        public void GetResultEntity_結果エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetResultEntity(Aggregate, "00050005");

            Assert.Equal("result", entity.Title);
        }

        [Fact]
        public void GetRecordEntity_記録エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetRecordEntity(Aggregate, "00060006");

            Assert.Equal("record", entity.Title);
        }

        [Fact]
        public void GetTodoEntity_実装エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetTodoEntity(Aggregate, "00070007");

            Assert.Equal("todo", entity.Title);
        }

        [Fact]
        public void GetSchemaEntity_構想エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetSchemaEntity(Aggregate, "00080008");

            Assert.Equal("schema", entity.Title);
        }

        [Fact]
        public void GetGroupEntity_集合エンティティを取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var entity = policy.GetGroupEntity(Aggregate, "00090009");

            Assert.Equal("group", entity.Title);
        }

        [Fact]
        public void GetSubjectEntityDict_主題エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetSubjectEntityDict(Aggregate);

            Assert.Equal(2, dict.Count);
        }

        [Fact]
        public void GetAchievementEntityDict_達成エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetAchievementEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetEvidenceEntityDict_証拠エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetEvidenceEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetResultEntityDict_結果エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetResultEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetRecordEntityDict_記録エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetRecordEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetTodoEntityDict_実装エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetTodoEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetSchemaEntityDict_構想エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetSchemaEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void GetGroupEntityDict_集合エンティティ一覧を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var dict = policy.GetGroupEntityDict(Aggregate);

            Assert.Single(dict);
        }

        [Fact]
        public void CreateEntity_エンティティを作成して接続できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var result = policy.CreateEntity(
                Aggregate,
                "00020002",
                "4",
                "new-evidence",
                "evidence-path");

            Assert.Equal(2, result.EvidenceEntityDict.Count);
            Assert.Equal(2, result.ParentLinkDict.Count);
            Assert.Equal(2, result.ChildrenLinkDict[IdValue.FromString("00020002")].Count);
        }

        [Fact]
        public void DeleteEntity_エンティティを削除できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var result = policy.DeleteEntity(Aggregate, "00030003");

            Assert.Empty(result.AchievementEntityDict);
        }

        [Fact]
        public void LinkEntity_エンティティ同士を接続できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var parentId = "00020002";
            var childId = "00040004";

            var result = policy.LinkEntity(Aggregate, parentId, childId);

            Assert.Equal(
                IdValue.FromString(parentId).GetId(),
                result.ParentLinkDict[IdValue.FromString(childId)].GetId());
            Assert.Contains(
                result.ChildrenLinkDict[IdValue.FromString(parentId)],
                child => child.GetId() == childId);
        }

        [Fact]
        public void MoveEntity_接続を新しい親へ移動できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var newParentId = "00100002";
            var childId = "00030003";

            var result = policy.MoveEntity(Aggregate, newParentId, childId);

            Assert.Equal(
                IdValue.FromString(newParentId).GetId(),
                result.ParentLinkDict[IdValue.FromString(childId)].GetId());
            Assert.Contains(
                result.ChildrenLinkDict[IdValue.FromString(newParentId)],
                child => child.GetId() == childId);
            var oldParentChildren = result.ChildrenLinkDict
                .Where(kv => kv.Key.GetId() == "00020002")
                .SelectMany(kv => kv.Value);
            Assert.DoesNotContain(oldParentChildren, child => child.GetId() == childId);
        }

        [Fact]
        public void CopyEntity_エンティティをコピーできる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var result = policy.CopyEntity(
                Aggregate,
                "00030003",
                "00120003");

            Assert.Equal(2, result.AchievementEntityDict.Count);
            Assert.Equal("achievement", result.GetAchievementEntity(IdValue.FromString("00120003")).Title);
        }

        [Fact]
        public void GroupEntity_設定をそのまま返す() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var result = policy.GroupEntity(
                Aggregate,
                "00020002",
                "group-title",
                ["00030003"]);

            Assert.Same(Aggregate, result);
        }

        [Fact]
        public void GetAchievementCount_達成数を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var count = policy.GetAchievementCount(Aggregate);

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetEvidenceCount_証拠数を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var count = policy.GetEvidenceCount(Aggregate);

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetResultCount_結果数を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var count = policy.GetResultCount(Aggregate);

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetSuccessCount_成功数を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var count = policy.GetSuccessCount(Aggregate);

            Assert.Equal(0, count);
        }

        [Fact]
        public void GetFailureCount_失敗数を取得できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var count = policy.GetFailureCount(Aggregate);

            Assert.Equal(0, count);
        }

        [Fact]
        public void GetFailureAggregateList_失敗内容一覧を実行できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            policy.GetFailureAggregateList(Aggregate);
        }

        [Fact]
        public void LoadRelational_リレーショナル型を読込できる() {
            var jsonDto = FactStatusTestHelper.CreateEmptyJsonDto();
            var mockRepo = new Mock<IFactStatusRepository>();
            mockRepo.Setup(r => r.LoadRelational(It.IsAny<PathValue>())).Returns(jsonDto);
            var strategy = FactStatusTestHelper.CreateStrategy(factStatusRepository: mockRepo);
            var policy = FactStatusTestHelper.CreatePolicy(strategy);

            var Aggregate = policy.LoadRelational("data.json");

            Assert.NotNull(Aggregate);
            Assert.Empty(Aggregate.SubjectEntityDict);
        }

        [Fact]
        public void SaveRelational_リレーショナル型を保存できる() {
            var mockRepo = new Mock<IFactStatusRepository>();
            var strategy = FactStatusTestHelper.CreateStrategy(factStatusRepository: mockRepo);
            var policy = FactStatusTestHelper.CreatePolicy(strategy);
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            policy.SaveRelational("data.json", Aggregate);

            mockRepo.Verify(r => r.SaveRelational(It.IsAny<PathValue>(), It.IsAny<JsonDto>()), Times.Once);
        }

        [Fact]
        public void LoadJson_JSONを読込できる() {
            var jsonDto = FactStatusTestHelper.CreateEmptyJsonDto();
            var mockRepo = new Mock<IJsonRepository>();
            mockRepo.Setup(r => r.LoadJson(It.IsAny<PathValue>())).Returns(jsonDto);
            var strategy = FactStatusTestHelper.CreateStrategy(jsonRepository: mockRepo);
            var policy = FactStatusTestHelper.CreatePolicy(strategy);

            var Aggregate = policy.LoadJson("data.json");

            Assert.NotNull(Aggregate);
            Assert.Empty(Aggregate.TodoEntityDict);
        }

        [Fact]
        public void SaveJson_JSONを保存できる() {
            var mockRepo = new Mock<IJsonRepository>();
            var strategy = FactStatusTestHelper.CreateStrategy(jsonRepository: mockRepo);
            var policy = FactStatusTestHelper.CreatePolicy(strategy);
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            policy.SaveJson("data.json", Aggregate);

            mockRepo.Verify(r => r.SaveJson(It.IsAny<PathValue>(), It.IsAny<JsonDto>()), Times.Once);
        }

        [Fact]
        public void LoadMarkdownSelect_Markdown単体読込を実行できる() {
            var policy = FactStatusTestHelper.CreatePolicy();

            policy.LoadMarkdownSelect("single.md");
        }

        [Fact]
        public void SaveMarkdownSelect_Markdown単体保存を実行できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            policy.SaveMarkdownSelect("single.md", Aggregate);
        }

        [Fact]
        public void LoadMarkdownRoot_Markdownルート読込を実行できる() {
            var policy = FactStatusTestHelper.CreatePolicy();

            policy.LoadMarkdownRoot("MarkdownRoot");
        }

        [Fact]
        public void SaveMarkdownRoot_Markdownルート保存を実行できる() {
            var policy = FactStatusTestHelper.CreatePolicy();
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            policy.SaveMarkdownRoot("MarkdownRoot", Aggregate);
        }
    }
}
