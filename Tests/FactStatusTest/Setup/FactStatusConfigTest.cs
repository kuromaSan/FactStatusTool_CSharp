using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Model;
using FactStatus.Domain.Value;
using Xunit.Abstractions;

namespace Domain.Test.Setup {
    public class FactStatusConfigTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void FactStatusConfig() {

            // 入力値準備
            var documentEntity = new DocumentEntity(
                "");
            var subjectEntity = new SubjectEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "");
            var achievementEntity = new AchievementEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "");
            var evidenceEntity = new EvidenceEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "",
                BoolValue.IsTrue());
            var resultEntity = new ResultEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                new List<ArgumentEntity> {
                    new ArgumentEntity(
                        IdValue.FromString("00010104"),
                        IdValue.FromString(""),
                        0,
                        0,
                        "testKey",
                        DataTypeEnum.String,
                        "testValue")
                },
                new List<AssertionEntity> {
                    new AssertionEntity(
                        IdValue.FromString("00010204"),
                        IdValue.FromString(""),
                        AssertEnum.Equal,
                        "ClassName.functionName()",
                        DataTypeEnum.Int,
                        "1")
                }
            );
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            var recordEntity = new RecordEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "",
                date,
                "",
                BoolValue.IsTrue());
            var todoEntity = new TodoEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "");
            var schemaEntity = new SchemaEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "",
                "",
                "",
                "",
                "",
                "");
            var groupEntity = new GroupEntity(
                IdValue.FromString(""),
                PathValue.PathIsDirectory(""),
                "");

            // 設定の作成
            var config = new FactStatusConfig(
                documentEntity ,
                new Dictionary<IdValue,SubjectEntity>{{new IdValue(""),subjectEntity}} ,
                new Dictionary<IdValue,AchievementEntity>{{new IdValue(""), achievementEntity }},
                new Dictionary<IdValue,EvidenceEntity>{{new IdValue(""), evidenceEntity }},
                new Dictionary<IdValue,ResultEntity>{{new IdValue(""), resultEntity }},
                new Dictionary<IdValue,RecordEntity>{{new IdValue(""), recordEntity }},
                new Dictionary<IdValue,TodoEntity>{{new IdValue(""), todoEntity }},
                new Dictionary<IdValue,SchemaEntity>{{new IdValue(""), schemaEntity }},
                new Dictionary<IdValue,GroupEntity>{{new IdValue(""), groupEntity}},
                new Dictionary<IdValue,IdValue>{{new IdValue(""), new IdValue("")}},
                new Dictionary<IdValue,List<IdValue>>{{new IdValue(""), new List<IdValue> { new IdValue("") }}},
                new Dictionary<IdValue,List<IdValue>>{{new IdValue(""), new List<IdValue> { new IdValue("") }}}
            );

            // 内容確認
            Assert.NotNull(config.DocumentEntity);
            Assert.Single(config.SubjectEntityDict);
            Assert.Single(config.AchievementEntityDict);
            Assert.Single(config.EvidenceEntityDict);
            Assert.Single(config.ResultEntityDict);
            Assert.Single(config.RecordEntityDict);
            Assert.Single(config.TodoEntityDict);
            Assert.Single(config.SchemaEntityDict);
            Assert.Single(config.GroupEntityDict);
            Assert.Single(config.ParentLinkDict);
            Assert.Single(config.ChildrenLinkDict);
            Assert.Single(config.GroupLinkDict);
        }

        [Fact]
        public void SubjectEntity() {
            // 入力値準備
            string id = "00010001";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var subjectEntity = new SubjectEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                description);

            // 内容確認
            Assert.Equal(id, subjectEntity.Id.GetId());
            Assert.Equal(pathName, subjectEntity.PathName.Path);
            Assert.Equal(title, subjectEntity.Title);
            Assert.Equal(description, subjectEntity.Description);
        }

        [Fact]
        public void AchievementEntity() {
            // 入力値準備
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var achievementEntity = new AchievementEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                description);

            // 内容確認
            output.WriteLine($"achievementEntity.Id:{achievementEntity.Id}");
            Assert.Equal(id, achievementEntity.Id.GetId());
            
            output.WriteLine($"achievementEntity.PathName:{achievementEntity.PathName}");
            Assert.Equal(pathName, achievementEntity.PathName.Path);
            
            output.WriteLine($"achievementEntity.Title:{achievementEntity.Title}");
            Assert.Equal(title, achievementEntity.Title);

            output.WriteLine($"achievementEntity.Description:{achievementEntity.Description}");
            Assert.Equal(description, achievementEntity.Description);
        }
        
        [Fact]
        public void EvidenceEntity() {
            // 入力値準備
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";
            string success = "1";

            // 設定の作成
            var evidenceEntity = new EvidenceEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                description,
                BoolValue.FromString(success));

            // 内容確認
            Assert.Equal(id, evidenceEntity.Id.GetId());
            Assert.Equal(pathName, evidenceEntity.PathName.Path);
            Assert.Equal(title, evidenceEntity.Title);
            Assert.Equal(description, evidenceEntity.Description);
            Assert.Equal(success, evidenceEntity.Success.ToStringOfNumber());
        }
        
        [Fact]
        public void ResultEntity() {
            // 入力値準備
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            var argumentValue = new List<ArgumentEntity> {
                    new ArgumentEntity(
                        IdValue.FromString("00010104"),
                        IdValue.FromString(""),
                        0,
                        0,
                        "testKey",
                        DataTypeEnum.String,
                        "testValue")
            };
            var assertionValue = new List<AssertionEntity> {
                    new AssertionEntity(
                        IdValue.FromString("00010204"),
                        IdValue.FromString(""),
                        AssertEnum.Equal,
                        "ClassName.functionName()",
                        DataTypeEnum.Int,
                        "1")
            };

            // 設定の作成
            var resultEntity = new ResultEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                argumentValue,
                assertionValue);

            // 内容確認
            Assert.Equal(id, resultEntity.Id.GetId());
            Assert.Equal(pathName, resultEntity.PathName.Path);
            Assert.Equal(title, resultEntity.Title);
        }

        [Fact]
        public void RecordEntity() {
            // 入力値準備
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string success = "1";
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            string reviewer = "reviewer";
            string description = "description";

            // 設定の作成
            var recordEntity = new RecordEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                description,
                date,
                reviewer,
                BoolValue.FromString(success));

            // 内容確認
            Assert.Equal(id, recordEntity.Id.GetId());
            Assert.Equal(pathName, recordEntity.PathName.Path);
            Assert.Equal(title, recordEntity.Title);
            Assert.Equal(description, recordEntity.Description);
            Assert.Equal(date, recordEntity.Date);
            Assert.Equal(reviewer, recordEntity.Reviewer);
            Assert.Equal(success,recordEntity.Success.ToStringOfNumber());
        }

        [Fact]
        public void TodoEntity() {
            // 入力値準備
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var todoEntity = new TodoEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                description);

            // 内容確認
            Assert.Equal(id, todoEntity.Id.GetId());
            Assert.Equal(pathName, todoEntity.PathName.Path);
            Assert.Equal(title, todoEntity.Title);
            Assert.Equal(description, todoEntity.Description);
        }

        [Fact]
        public void SchemaEntity() {
            // 入力値準備
            string id = "00010007";
            string pathName = "path";
            string title = "title";
            string experience = "experience";
            string evaluation = "evaluation";
            string hypothesis = "hypothesis";
            string abstractionGoal = "abstractionGoal";
            string executionGoal = "executionGoal";


            // 設定の作成
            var schemaEntity = new SchemaEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title,
                experience,
                evaluation,
                hypothesis,
                abstractionGoal,
                executionGoal);

            // 内容確認
            Assert.Equal(id, schemaEntity.Id.GetId());
            Assert.Equal(pathName, schemaEntity.PathName.Path);
            Assert.Equal(title, schemaEntity.Title);
            Assert.Equal(experience, schemaEntity.Experience);
            Assert.Equal(evaluation, schemaEntity.Evaluation);
            Assert.Equal(hypothesis, schemaEntity.Hypothesis);
            Assert.Equal(abstractionGoal, schemaEntity.AbstractionGoal);
            Assert.Equal(executionGoal, schemaEntity.ExecutionGoal);
        }

        [Fact]
        public void GroupEntity() {
            // 入力値準備
            string id = "00010008";
            string pathName = "path";
            string title = "title";

            // 設定の作成
            var groupEntity = new GroupEntity(
                IdValue.FromString(id),
                PathValue.PathIsDirectory(pathName),
                title);

            // 内容確認
            Assert.Equal(id, groupEntity.Id.GetId());
            Assert.Equal(pathName, groupEntity.PathName.Path);
            Assert.Equal(title, groupEntity.Title);
        }
    }
}
