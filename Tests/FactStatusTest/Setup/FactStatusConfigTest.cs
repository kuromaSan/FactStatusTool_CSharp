using System;
using System.Collections.Generic;
using Domain.Test.TestSupport;
using FactStatus.Domain.Model;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using Xunit;

namespace Domain.Test.Setup {
    public class FactStatusAggregateTest {
        private static FactStatusAggregate CreateAggregateWithSubjectIndices(params int[] indices) {
            var comparer = new FactStatusTestHelper.IdValueByIdComparer();
            var subjectDict = new Dictionary<IdValue, SubjectEntity>(comparer);
            foreach (var index in indices) {
                var id = IdValue.FromString($"{index:0000}0002");
                subjectDict[id] = new SubjectEntity(
                    id,
                    PathValue.PathIsDirectory($"subject{index}"),
                    $"title{index}",
                    "");
            }

            return new FactStatusAggregate(
                new DocumentEntity(""),
                subjectDict,
                new Dictionary<IdValue, AchievementEntity>(comparer),
                new Dictionary<IdValue, EvidenceEntity>(comparer),
                new Dictionary<IdValue, ResultEntity>(comparer),
                new Dictionary<IdValue, RecordEntity>(comparer),
                new Dictionary<IdValue, TodoEntity>(comparer),
                new Dictionary<IdValue, SchemaEntity>(comparer),
                new Dictionary<IdValue, GroupEntity>(comparer),
                new Dictionary<IdValue, ArgumentEntity>(comparer),
                new Dictionary<IdValue, AssertionEntity>(comparer),
                new Dictionary<IdValue, IdValue>(comparer),
                new Dictionary<IdValue, List<IdValue>>(comparer),
                new Dictionary<IdValue, List<IdValue>>(comparer));
        }

        [Fact]
        public void FactStatusAggregate_コンストラクタで各辞書が設定される() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            Assert.NotNull(Aggregate.DocumentEntity);
            Assert.Equal(2, Aggregate.SubjectEntityDict.Count);
            Assert.Single(Aggregate.AchievementEntityDict);
            Assert.Single(Aggregate.EvidenceEntityDict);
            Assert.Single(Aggregate.ResultEntityDict);
            Assert.Single(Aggregate.RecordEntityDict);
            Assert.Single(Aggregate.TodoEntityDict);
            Assert.Single(Aggregate.SchemaEntityDict);
            Assert.Single(Aggregate.GroupEntityDict);
            Assert.Single(Aggregate.ParentLinkDict);
            Assert.Single(Aggregate.ChildrenLinkDict);
            Assert.Single(Aggregate.GroupLinkDict);
        }

        [Fact]
        public void GetSubjectEntity_主題エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00020002");

            var entity = Aggregate.GetSubjectEntity(id);

            Assert.Equal("subject-1", entity.Title);
        }

        [Fact]
        public void GetAchievementEntity_達成エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00030003");

            var entity = Aggregate.GetAchievementEntity(id);

            Assert.Equal("achievement", entity.Title);
        }

        [Fact]
        public void GetEvidenceEntity_証拠エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00040004");

            var entity = Aggregate.GetEvidenceEntity(id);

            Assert.Equal("evidence", entity.Title);
        }

        [Fact]
        public void GetResultEntity_結果エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00050005");

            var entity = Aggregate.GetResultEntity(id);

            Assert.Equal("result", entity.Title);
        }

        [Fact]
        public void GetRecordEntity_記録エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00060006");

            var entity = Aggregate.GetRecordEntity(id);

            Assert.Equal("record", entity.Title);
        }

        [Fact]
        public void GetTodoEntity_実装エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00070007");

            var entity = Aggregate.GetTodoEntity(id);

            Assert.Equal("todo", entity.Title);
        }

        [Fact]
        public void GetSchemaEntity_構想エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00080008");

            var entity = Aggregate.GetSchemaEntity(id);

            Assert.Equal("schema", entity.Title);
        }

        [Fact]
        public void GetGroupEntity_集合エンティティを取得できる() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();
            var id = IdValue.FromString("00090009");

            var entity = Aggregate.GetGroupEntity(id);

            Assert.Equal("group", entity.Title);
        }

        [Fact]
        public void GetSubjectMinId_空の場合は0001を返す() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();

            var minId = Aggregate.GetSubjectMinId();

            Assert.Equal("0001", minId);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, "0006")]
        [InlineData(new[] { 1, 3, 4, 5, 6 }, "0002")]
        public void GetSubjectMinId_欠番の最小Indexを返す(int[] indices, string expected) {
            var Aggregate = CreateAggregateWithSubjectIndices(indices);

            var minId = Aggregate.GetSubjectMinId();

            Assert.Equal(expected, minId);
        }

        [Fact]
        public void GetAchievementMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetAchievementMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetEvidenceMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetEvidenceMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetResultMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetResultMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetRecordMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetRecordMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetTodoMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetTodoMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetSchemaMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetSchemaMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void GetGroupMinId_欠番の最小Indexを返す() {
            var Aggregate = FactStatusTestHelper.CreateSampleAggregate();

            var minId = Aggregate.GetGroupMinId();

            Assert.Equal("0001", minId);
        }

        [Fact]
        public void AddSubjectEntity_主題エンティティを追加しMinIdを更新する() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = SubjectEntity.Create(
                IdValue.FromString("00010002"),
                PathValue.PathIsDirectory("new-subject"),
                "new");

            Aggregate.AddSubjectEntity(entity);

            Assert.Single(Aggregate.SubjectEntityDict);
            Assert.Equal("new", Aggregate.GetSubjectEntity(IdValue.FromString("00010002")).Title);
            Assert.Equal("0002", Aggregate.GetSubjectMinId());
        }

        [Fact]
        public void AddAchievementEntity_達成エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = AchievementEntity.Create(
                IdValue.FromString("00010003"),
                PathValue.PathIsDirectory("achievement"),
                "achievement");

            Aggregate.AddAchievementEntity(entity);

            Assert.Single(Aggregate.AchievementEntityDict);
            Assert.Equal("achievement", Aggregate.GetAchievementEntity(IdValue.FromString("00010003")).Title);
            Assert.Equal("0002", Aggregate.GetAchievementMinId());
        }

        [Fact]
        public void AddEvidenceEntity_証拠エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = EvidenceEntity.Create(
                IdValue.FromString("00010004"),
                PathValue.PathIsDirectory("evidence"),
                "evidence");

            Aggregate.AddEvidenceEntity(entity);

            Assert.Single(Aggregate.EvidenceEntityDict);
            Assert.Equal("evidence", Aggregate.GetEvidenceEntity(IdValue.FromString("00010004")).Title);
        }

        [Fact]
        public void AddResultEntity_結果エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = ResultEntity.Create(
                IdValue.FromString("00010005"),
                PathValue.PathIsDirectory("result"),
                "result");

            Aggregate.AddResultEntity(entity);

            Assert.Single(Aggregate.ResultEntityDict);
            Assert.Equal("result", Aggregate.GetResultEntity(IdValue.FromString("00010005")).Title);
        }

        [Fact]
        public void AddRecordEntity_記録エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = RecordEntity.Build(
                IdValue.FromString("00010006"),
                PathValue.PathIsDirectory("record"),
                "record",
                "desc",
                "reviewer",
                BoolValue.IsTrue());

            Aggregate.AddRecordEntity(entity);

            Assert.Single(Aggregate.RecordEntityDict);
            Assert.Equal("record", Aggregate.GetRecordEntity(IdValue.FromString("00010006")).Title);
        }

        [Fact]
        public void AddTodoEntity_実装エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = TodoEntity.Create(
                IdValue.FromString("00010007"),
                PathValue.PathIsDirectory("todo"),
                "todo");

            Aggregate.AddTodoEntity(entity);

            Assert.Single(Aggregate.TodoEntityDict);
            Assert.Equal("todo", Aggregate.GetTodoEntity(IdValue.FromString("00010007")).Title);
        }

        [Fact]
        public void AddSchemaEntity_構想エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = SchemaEntity.Create(
                IdValue.FromString("00010008"),
                PathValue.PathIsDirectory("schema"),
                "schema");

            Aggregate.AddSchemaEntity(entity);

            Assert.Single(Aggregate.SchemaEntityDict);
            Assert.Equal("schema", Aggregate.GetSchemaEntity(IdValue.FromString("00010008")).Title);
        }

        [Fact]
        public void AddGroupEntity_集合エンティティを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var entity = GroupEntity.Create(
                IdValue.FromString("00010009"),
                PathValue.PathIsDirectory("group"),
                "group");

            Aggregate.AddGroupEntity(entity);

            Assert.Single(Aggregate.GroupEntityDict);
            Assert.Equal("group", Aggregate.GetGroupEntity(IdValue.FromString("00010009")).Title);
        }

        [Fact]
        public void AddParentLink_親子リンクを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var parentId = IdValue.FromString("00010002");
            var childId = IdValue.FromString("00020003");

            Aggregate.AddParentLink(childId, parentId);

            Assert.Equal(parentId, Aggregate.ParentLinkDict[childId]);
        }

        [Fact]
        public void AddChildrenLink_子リンクを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var parentId = IdValue.FromString("00010002");
            var childId = IdValue.FromString("00020003");

            Aggregate.AddChildrenLink(parentId, childId);

            Assert.Single(Aggregate.ChildrenLinkDict[parentId]);
            Assert.Equal(childId, Aggregate.ChildrenLinkDict[parentId][0]);
        }

        [Fact]
        public void AddGroupLink_集合リンクを追加できる() {
            var Aggregate = FactStatusTestHelper.CreateEmptyAggregate();
            var groupId = IdValue.FromString("00010009");
            var memberId = IdValue.FromString("00020002");

            Aggregate.AddGroupLink(groupId, memberId);

            Assert.Single(Aggregate.GroupLinkDict[groupId]);
            Assert.Equal(memberId, Aggregate.GroupLinkDict[groupId][0]);
        }
    }
}
