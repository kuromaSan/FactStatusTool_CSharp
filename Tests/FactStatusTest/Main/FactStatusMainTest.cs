using System;
using System.Collections.Generic;
using System.IO;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Main;
using FactStatus.Domain.Model;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using Xunit;
using Xunit.Abstractions;

namespace FactStatus.Domain.Test.Main {
    public class FactStatusMainTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="expectedTitle"></param>
        [Theory]
        [InlineData("00010002", "subject-1")]
        [InlineData("00020002", "subject-2")]
        public void GetSubjectEntity_SelectIdEntityで取得できる(string id, string expectedTitle) {
            var factStatus = CreateFactStatus();

            factStatus.SelectIdEntity = id;
            var subjectEntity = factStatus.GetSubjectEntity();

            Assert.Equal(expectedTitle, subjectEntity.Title);
        }

        [Theory]
        [InlineData("x")]
        public void GetDocumentEntity_取得できる(string _) {
            var factStatus = CreateFactStatus();
            Assert.NotNull(factStatus.GetDocumentEntity());
        }

        [Theory]
        [InlineData("00020002", "Subject")]
        [InlineData("00030003", "Achievement")]
        [InlineData("00040004", "Evidence")]
        [InlineData("00050005", "Result")]
        [InlineData("00060006", "Record")]
        [InlineData("00070007", "Todo")]
        [InlineData("00080008", "Schema")]
        [InlineData("00090009", "Group")]
        public void 各Entity取得メソッドを実行できる(string id, string entityType) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = id;

            object? entity = entityType switch {
                "Subject" => factStatus.GetSubjectEntity(),
                "Achievement" => factStatus.GetAchievementEntity(),
                "Evidence" => factStatus.GetEvidenceEntity(),
                "Result" => factStatus.GetResultEntity(),
                "Record" => factStatus.GetRecordEntity(),
                "Todo" => factStatus.GetTodoEntity(),
                "Schema" => factStatus.GetSchemaEntity(),
                "Group" => factStatus.GetGroupEntity(),
                _ => null
            };

            Assert.NotNull(entity);
        }

        [Theory]
        [InlineData("Subject")]
        [InlineData("Achievement")]
        [InlineData("Evidence")]
        [InlineData("Result")]
        [InlineData("Record")]
        [InlineData("Todo")]
        [InlineData("Schema")]
        [InlineData("Group")]
        public void 各Entity辞書取得メソッドを実行できる(string entityType) {
            var factStatus = CreateFactStatus();

            int count = entityType switch {
                "Subject" => factStatus.GetSubjectEntityDict().Count,
                "Achievement" => factStatus.GetAchievementEntityDict(IdTypeEnum.AchievementEntity).Count,
                "Evidence" => factStatus.GetEvidenceEntityDict(IdTypeEnum.EvidenceEntity).Count,
                "Result" => factStatus.GetResultEntityDict(IdTypeEnum.ResultEntity).Count,
                "Record" => factStatus.GetRecordEntityDict(IdTypeEnum.RecordEntity).Count,
                "Todo" => factStatus.GetTodoEntityDict(IdTypeEnum.TodoEntity).Count,
                "Schema" => factStatus.GetSchemaEntityDict(IdTypeEnum.SchemaEntity).Count,
                "Group" => factStatus.GetGroupEntityDict(IdTypeEnum.GroupEntity).Count,
                _ => 0
            };

            Assert.True(count > 0);
        }

        [Theory]
        [InlineData("AchievementCount", 1)]
        [InlineData("EvidenceCount", 1)]
        [InlineData("ResultCount", 1)]
        [InlineData("SuccessCount", 0)]
        [InlineData("FailureCount", 0)]
        public void 集計メソッドを実行できる(string methodName, int expected) {
            var factStatus = CreateFactStatus();

            var actual = methodName switch {
                "AchievementCount" => factStatus.GetAchievementCount(),
                "EvidenceCount" => factStatus.GetEvidenceCount(),
                "ResultCount" => factStatus.GetResultCount(),
                "SuccessCount" => factStatus.GetSuccessCount(),
                "FailureCount" => factStatus.GetFailureCount(),
                _ => -1
            };

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("x")]
        public void GetFailureConfigListを実行できる(string _) {
            var factStatus = CreateFactStatus();
            factStatus.GetFailureConfigList();
        }

        [Theory]
        [InlineData("00020002", IdTypeEnum.SubjectEntity)]
        [InlineData("00020002", IdTypeEnum.AchievementEntity)]
        public void CreateEntityを実行できる(string selectId, IdTypeEnum idTypeEnum) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = selectId;

            factStatus.CreateEntity(idTypeEnum);
        }

        [Theory]
        [InlineData("00020002")]
        public void DeleteEntityを実行できる(string selectId) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = selectId;

            factStatus.DeleteEntity();
        }

        [Theory]
        [InlineData("00020002", "00030003")]
        public void LinkEntityを実行できる(string selectId, string linkId) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = selectId;

            factStatus.LinkEntity(linkId);
        }

        [Theory]
        [InlineData("00020002", "00030003")]
        public void CopyEntityを実行できる(string selectId, string copyId) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = selectId;

            factStatus.CopyEntity(copyId);
        }

        [Theory]
        [InlineData("00020002", "group")]
        public void GroupEntityを実行できる(string selectId, string title) {
            var factStatus = CreateFactStatus();
            factStatus.SelectIdEntity = selectId;

            factStatus.GroupEntity(title, ["00020002", "00030003"]);
        }

        [Theory]
        [InlineData("json")]
        public void SaveLoadJsonを実行できる(string suffix) {
            var factStatus = CreateFactStatus();
            var jsonPath = Path.Combine(Path.GetTempPath(), $"factstatus_{suffix}_{Guid.NewGuid():N}.json");

            try {
                factStatus.SaveFilePath = jsonPath;
                factStatus.SaveJson();
                Assert.True(File.Exists(jsonPath));

                factStatus.LoadFilePath = jsonPath;
                factStatus.LoadJson();
            }
            finally {
                if (File.Exists(jsonPath)) {
                    File.Delete(jsonPath);
                }
            }
        }

        [Theory]
        [InlineData("rel")]
        public void SaveLoadRelationalを実行できる(string suffix) {
            var factStatus = CreateFactStatus();
            var relationalPath = Path.Combine(Path.GetTempPath(), $"factstatus_{suffix}_{Guid.NewGuid():N}.json");

            try {
                factStatus.SaveFilePath = relationalPath;
                factStatus.SaveRelational();
                Assert.True(File.Exists(relationalPath));

                factStatus.LoadFilePath = relationalPath;
                factStatus.LoadRelational();
            }
            finally {
                if (File.Exists(relationalPath)) {
                    File.Delete(relationalPath);
                }
            }
        }

        [Theory]
        [InlineData("single.md")]
        public void LoadMarkdownSelectを実行できる(string path) {
            var factStatus = CreateFactStatus();
            factStatus.LoadFilePath = path;
            factStatus.LoadMarkdownSelect();
        }

        [Theory]
        [InlineData("single.md")]
        public void SaveMarkdownSelectを実行できる(string path) {
            var factStatus = CreateFactStatus();
            factStatus.SaveFilePath = path;
            factStatus.SaveMarkdownSelect();
        }

        [Theory]
        [InlineData("MarkdownRoot")]
        public void LoadMarkdownRootを実行できる(string path) {
            var factStatus = CreateFactStatus();
            factStatus.LoadFilePath = path;
            factStatus.LoadMarkdownRoot();
        }

        [Theory]
        [InlineData("MarkdownRoot")]
        public void SaveMarkdownRootを実行できる(string path) {
            var factStatus = CreateFactStatus();
            factStatus.SaveFilePath = path;
            factStatus.SaveMarkdownRoot();
        }

        private static FactStatusMain CreateFactStatus() {
            var subject1 = new SubjectEntity(IdValue.FromString("00020002"), PathValue.PathIsDirectory("subject1"), "subject-1", "desc");
            var subject2 = new SubjectEntity(IdValue.FromString("00100002"), PathValue.PathIsDirectory("subject2"), "subject-2", "desc");
            var achievement = new AchievementEntity(IdValue.FromString("00030003"), PathValue.PathIsDirectory("achievement"), "achievement", "desc");
            var evidence = new EvidenceEntity(IdValue.FromString("00040004"), PathValue.PathIsDirectory("evidence"), "evidence", "desc", BoolValue.IsTrue());
            var result = new ResultEntity(
                IdValue.FromString("00050005"),
                PathValue.PathIsDirectory("result"),
                "result",
                [new ArgumentEntity(IdValue.FromString("01040104"), IdValue.FromString("00050005"), 0, 0, "arg", DataTypeEnum.String, "v")],
                [new AssertionEntity(IdValue.FromString("02040204"), IdValue.FromString("00050005"), AssertEnum.Equal, "target", DataTypeEnum.String, "v")]);
            var record = new RecordEntity(IdValue.FromString("00060006"), PathValue.PathIsDirectory("record"), "record", "desc", DateTime.Now.AddMinutes(-1), "reviewer", BoolValue.IsTrue());
            var todo = new TodoEntity(IdValue.FromString("00070007"), PathValue.PathIsDirectory("todo"), "todo", "desc");
            var schema = new SchemaEntity(IdValue.FromString("00080008"), PathValue.PathIsDirectory("schema"), "schema", "exp", "eva", "hyp", "abst", "exec");
            var group = new GroupEntity(IdValue.FromString("00090009"), PathValue.PathIsDirectory("group"), "group");

            var comparer = new IdValueByIdComparer();
            var subjectDict = new Dictionary<IdValue, SubjectEntity>(comparer) {
                [subject1.Id] = subject1,
                [subject2.Id] = subject2
            };
            var achievementDict = new Dictionary<IdValue, AchievementEntity>(comparer) {
                [achievement.Id] = achievement
            };
            var evidenceDict = new Dictionary<IdValue, EvidenceEntity>(comparer) {
                [evidence.Id] = evidence
            };
            var resultDict = new Dictionary<IdValue, ResultEntity>(comparer) {
                [result.Id] = result
            };
            var recordDict = new Dictionary<IdValue, RecordEntity>(comparer) {
                [record.Id] = record
            };
            var todoDict = new Dictionary<IdValue, TodoEntity>(comparer) {
                [todo.Id] = todo
            };
            var schemaDict = new Dictionary<IdValue, SchemaEntity>(comparer) {
                [schema.Id] = schema
            };
            var groupDict = new Dictionary<IdValue, GroupEntity>(comparer) {
                [group.Id] = group
            };
            var parentLinkDict = new Dictionary<IdValue, IdValue>(comparer);
            var childrenLinkDict = new Dictionary<IdValue, List<IdValue>>(comparer);
            var groupLinkDict = new Dictionary<IdValue, List<IdValue>>(comparer);

            var factStatusConfig = new FactStatusConfig(
                new DocumentEntity("doc"),
                subjectDict,
                achievementDict,
                evidenceDict,
                resultDict,
                recordDict,
                todoDict,
                schemaDict,
                groupDict,
                parentLinkDict,
                childrenLinkDict,
                groupLinkDict);

            var factStatusPolicy = new FactStatusPolicy(
                new FactStatusStrategy(
                    new FactStatusRepository(),
                    new JsonRepository(),
                    new MarkdownRepository()));

            return new FactStatus.Domain.Main.FactStatusMain(factStatusConfig, factStatusPolicy);
        }

        private sealed class IdValueByIdComparer : IEqualityComparer<IdValue> {
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
    }
}
