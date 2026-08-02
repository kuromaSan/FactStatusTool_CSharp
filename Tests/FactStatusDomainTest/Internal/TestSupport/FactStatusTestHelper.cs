using System;
using System.Collections.Generic;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Api.Entity;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Api.Value;
using Moq;

namespace FactStatus.Domain.Test.Internal.TestSupport {
    internal static class FactStatusTestHelper {
        internal sealed class IdValueByIdComparer : IEqualityComparer<IdValue> {
            public bool Equals(IdValue? x, IdValue? y) {
                if (ReferenceEquals(x, y)) {
                    return true;
                }

                if (x is null || y is null) {
                    return false;
                }

                return x.GetId() == y.GetId();
            }

            public int GetHashCode(IdValue obj) {
                return obj.GetId().GetHashCode();
            }
        }

        internal static JsonDto CreateEmptyJsonDto() {
            return new JsonDto {
                DocumentAggregate = new DocumentAggregateJsonDto {
                    Id = "00010001",
                    PathName = "Documents",
                    Title = "doc",
                    Description = ""
                },
                SubjectAggregates = [],
                AchievementAggregates = [],
                EvidenceAggregates = [],
                ResultAggregates = [],
                RecordAggregates = [],
                TodoAggregates = [],
                SchemaAggregates = [],
                GroupAggregates = [],
                ArgumentProperties = [],
                AssertionProperties = [],
                ParentEdges = [],
                GroupEdges = []
            };
        }

        internal static FactStatusAggregate CreateEmptyAggregate() {
            var comparer = new IdValueByIdComparer();
            return new FactStatusAggregate(
                new DocumentEntity(""),
                new Dictionary<IdValue, SubjectEntity>(comparer),
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

        internal static FactStatusAggregate CreateSampleAggregate() {
            var subject1 = new SubjectEntity(
                IdValue.FromString("00020002"),
                PathValue.PathIsDirectory("subject1"),
                "subject-1",
                "desc");
            var subject2 = new SubjectEntity(
                IdValue.FromString("00100002"),
                PathValue.PathIsDirectory("subject2"),
                "subject-2",
                "desc");
            var achievement = new AchievementEntity(
                IdValue.FromString("00030003"),
                PathValue.PathIsDirectory("achievement"),
                "achievement",
                "desc");
            var evidence = new EvidenceEntity(
                IdValue.FromString("00040004"),
                PathValue.PathIsDirectory("evidence"),
                "evidence",
                "desc",
                BoolValue.IsTrue());
            var argument = new ArgumentEntity(
                IdValue.FromString("00010010"),
                IdValue.FromString("00050005"),
                0,
                0,
                "arg",
                DataTypeEnum.String,
                "v");
            var assertion = new AssertionEntity(
                IdValue.FromString("00010011"),
                IdValue.FromString("00050005"),
                AssertEnum.Equal,
                "target",
                DataTypeEnum.String,
                "v");
            var result = new ResultEntity(
                IdValue.FromString("00050005"),
                PathValue.PathIsDirectory("result"),
                "result",
                [argument],
                [assertion]);
            var record = new RecordEntity(
                IdValue.FromString("00060006"),
                PathValue.PathIsDirectory("record"),
                "record",
                "desc",
                DateTime.Now.AddMinutes(-1),
                "reviewer",
                BoolValue.IsTrue());
            var todo = new TodoEntity(
                IdValue.FromString("00070007"),
                PathValue.PathIsDirectory("todo"),
                "todo",
                "desc");
            var schema = new SchemaEntity(
                IdValue.FromString("00080008"),
                PathValue.PathIsDirectory("schema"),
                "schema",
                "exp",
                "eva",
                "hyp",
                "abst",
                "exec");
            var group = new GroupEntity(
                IdValue.FromString("00090009"),
                PathValue.PathIsDirectory("group"),
                "group");

            var comparer = new IdValueByIdComparer();
            var parentId = subject1.Id;
            var childId = achievement.Id;

            return new FactStatusAggregate(
                new DocumentEntity("doc"),
                new Dictionary<IdValue, SubjectEntity>(comparer) {
                    [subject1.Id] = subject1,
                    [subject2.Id] = subject2
                },
                new Dictionary<IdValue, AchievementEntity>(comparer) {
                    [achievement.Id] = achievement
                },
                new Dictionary<IdValue, EvidenceEntity>(comparer) {
                    [evidence.Id] = evidence
                },
                new Dictionary<IdValue, ResultEntity>(comparer) {
                    [result.Id] = result
                },
                new Dictionary<IdValue, RecordEntity>(comparer) {
                    [record.Id] = record
                },
                new Dictionary<IdValue, TodoEntity>(comparer) {
                    [todo.Id] = todo
                },
                new Dictionary<IdValue, SchemaEntity>(comparer) {
                    [schema.Id] = schema
                },
                new Dictionary<IdValue, GroupEntity>(comparer) {
                    [group.Id] = group
                },
                new Dictionary<IdValue, ArgumentEntity>(comparer) {
                    [argument.Id] = argument
                },
                new Dictionary<IdValue, AssertionEntity>(comparer) {
                    [assertion.Id] = assertion
                },
                new Dictionary<IdValue, IdValue>(comparer) {
                    [childId] = parentId
                },
                new Dictionary<IdValue, List<IdValue>>(comparer) {
                    [parentId] = [childId]
                },
                new Dictionary<IdValue, List<IdValue>>(comparer) {
                    [group.Id] = [subject1.Id]
                });
        }

        internal static FactStatusStrategy CreateStrategy(
            Mock<IFactStatusRepository>? factStatusRepository = null,
            Mock<IJsonRepository>? jsonRepository = null,
            Mock<IMarkdownRepository>? markdownRepository = null) {

            return new FactStatusStrategy(
                factStatusRepository?.Object ?? new Mock<IFactStatusRepository>().Object,
                jsonRepository?.Object ?? new Mock<IJsonRepository>().Object,
                markdownRepository?.Object ?? new Mock<IMarkdownRepository>().Object);
        }

        internal static FactStatusPolicy CreatePolicy(FactStatusStrategy? strategy = null) {
            strategy ??= CreateStrategy();
            return new FactStatusPolicy(strategy);
        }
    }
}
