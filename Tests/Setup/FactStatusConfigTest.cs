using FactStatusTool.Scripts.Setup;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FactStatusTool.Tests.Setup {
    public class FactStatusConfigTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void FactStatusConfig() {
            // 入力値準備
            var subject = new SubjectConfig(
                "",
                "",
                "",
                "");
            var achievement = new AchievementConfig(
                "",
                "",
                "",
                "",
                "");
            var evidence = new EvidenceConfig(
                "",
                "",
                "",
                "",
                "");
            var result = new ResultConfig(
                "",
                "",
                "",
                "",
                true);
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            var record = new RecordConfig(
                "",
                "",
                "",
                "",
                date,
                "",
                true,
                "");
            var todo = new TodoConfig(
                "",
                "",
                "",
                "",
                "");
            var schemaConfig = new SchemaConfig(
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "");
            var argument = new ArgumentConfig(
                "",
                "",
                "",
                "",
                "");
            var assertion = new AssertionConfig(
                "",
                "",
                "",
                "",
                "",
                "");

            // 設定の作成
            var config = new FactStatusConfig(
                new List<SubjectConfig> { subject },
                new List<AchievementConfig> { achievement },
                new List<EvidenceConfig> { evidence },
                new List<ResultConfig> { result },
                new List<ArgumentConfig> { argument },
                new List<AssertionConfig> { assertion },
                new List<RecordConfig> { record },
                new List<TodoConfig> { todo },
                new List<SchemaConfig> { schemaConfig });

            // 内容確認
            Assert.Single(config.SubjectConfigList);
            Assert.Single(config.AchievementConfigList);
            Assert.Single(config.EvidenceConfigList);
            Assert.Single(config.ResultConfigList);
            Assert.Single(config.ArgumentConfigList);
            Assert.Single(config.AssertionConfigList);
            Assert.Single(config.RecordConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.SchemaConfigList);
        }

        [Fact]
        public void SubjectConfig() {
            // 入力値準備
            string id = "00010001";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var subjectConfig = new SubjectConfig(
                id,
                pathName,
                title,
                description);

            // 内容確認
            Assert.Equal(id, subjectConfig.Id);
            Assert.Equal(pathName, subjectConfig.PathName);
            Assert.Equal(title, subjectConfig.Title);
            Assert.Equal(description, subjectConfig.Description);
        }

        [Fact]
        public void AchievementConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var achievementConfig = new AchievementConfig(
                parentId,
                id,
                pathName,
                title,
                description);

            // 内容確認
            output.WriteLine($"achievementConfig.ParentId:{achievementConfig.ParentId}");
            Assert.Equal(parentId, achievementConfig.ParentId);
            
            output.WriteLine($"achievementConfig.Id:{achievementConfig.Id}");
            Assert.Equal(id, achievementConfig.Id);
            
            output.WriteLine($"achievementConfig.PathName:{achievementConfig.PathName}");
            Assert.Equal(pathName, achievementConfig.PathName);
            
            output.WriteLine($"achievementConfig.Title:{achievementConfig.Title}");
            Assert.Equal(title, achievementConfig.Title);

            output.WriteLine($"achievementConfig.Description:{achievementConfig.Description}");
            Assert.Equal(description, achievementConfig.Description);
        }
        
        [Fact]
        public void EvidenceConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var evidenceConfig = new EvidenceConfig(
                parentId,
                id,
                pathName,
                title,
                description);

            // 内容確認
            Assert.Equal(parentId, evidenceConfig.ParentId);
            Assert.Equal(id, evidenceConfig.Id);
            Assert.Equal(pathName, evidenceConfig.PathName);
            Assert.Equal(title, evidenceConfig.Title);
            Assert.Equal(description, evidenceConfig.Description);
        }
        
        [Fact]
        public void ResultConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            bool success = true;

            // 設定の作成
            var resultConfig = new ResultConfig(
                parentId,
                id,
                pathName,
                title,
                success);

            // 内容確認
            Assert.Equal(parentId, resultConfig.ParentId);
            Assert.Equal(id, resultConfig.Id);
            Assert.Equal(pathName, resultConfig.PathName);
            Assert.Equal(title, resultConfig.Title);
            Assert.Equal(success, resultConfig.Success);
        }

        [Fact]
        public void RecordConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            bool success = true;
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            string reviewer = "reviewer";
            string description = "description";

            // 設定の作成
            var recordConfig = new RecordConfig(
                parentId,
                id,
                pathName,
                title,
                date,
                reviewer,
                success,
                description);

            // 内容確認
            Assert.Equal(parentId, recordConfig.ParentId);
            Assert.Equal(id, recordConfig.Id);
            Assert.Equal(pathName, recordConfig.PathName);
            Assert.Equal(title, recordConfig.Title);
            Assert.Equal(date, recordConfig.Date);
            Assert.Equal(reviewer, recordConfig.Reviewer);
            Assert.Equal(success,recordConfig.Success);
            Assert.Equal(description, recordConfig.Description);
        }

        [Fact]
        public void TodoConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // 設定の作成
            var todoConfig = new TodoConfig(
                parentId,
                id,
                pathName,
                title,
                description);

            // 内容確認
            Assert.Equal(parentId, todoConfig.ParentId);
            Assert.Equal(id, todoConfig.Id);
            Assert.Equal(pathName, todoConfig.PathName);
            Assert.Equal(title, todoConfig.Title);
            Assert.Equal(description, todoConfig.Description);
        }

        [Fact]
        public void SchemaConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string experience = "experience";
            string evaluation = "evaluation";
            string hypothesis = "hypothesis";
            string abstractionGoal = "abstractionGoal";
            string executionGoal = "executionGoal";


            // 設定の作成
            var schemaConfig = new SchemaConfig(
                parentId,
                id,
                pathName,
                title,
                experience,
                evaluation,
                hypothesis,
                abstractionGoal,
                executionGoal);

            // 内容確認
            Assert.Equal(parentId, schemaConfig.ParentId);
            Assert.Equal(id, schemaConfig.Id);
            Assert.Equal(pathName, schemaConfig.PathName);
            Assert.Equal(title, schemaConfig.Title);
            Assert.Equal(experience, schemaConfig.Experience);
            Assert.Equal(evaluation, schemaConfig.Evaluation);
            Assert.Equal(hypothesis, schemaConfig.Hypothesis);
            Assert.Equal(abstractionGoal, schemaConfig.AbstractionGoal);
            Assert.Equal(executionGoal, schemaConfig.ExecutionGoal);
        }

        [Fact]
        public void ArgumentConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string key = "key";
            string type = "type";
            string value = "value";

            // 設定の作成
            var argumentConfig = new ArgumentConfig(
                parentId,
                id,
                key,
                type,
                value);

            // 内容確認
            Assert.Equal(parentId, argumentConfig.ParentId);
            Assert.Equal(id, argumentConfig.Id);
            Assert.Equal(key, argumentConfig.Key);
            Assert.Equal(type, argumentConfig.Type);
            Assert.Equal(value, argumentConfig.Value);
        }

        [Fact]
        public void AssertionConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string assert = "assert";
            string target = "target";
            string type = "type";
            string value = "value";

            // 設定の作成
            var assertionConfig = new AssertionConfig(
                parentId,
                id,
                assert,
                target,
                type,
                value);

            // 内容確認
            Assert.Equal(parentId, assertionConfig.ParentId);
            Assert.Equal(id, assertionConfig.Id);
            Assert.Equal(assert, assertionConfig.Assert);
            Assert.Equal(target, assertionConfig.Target);
            Assert.Equal(type, assertionConfig.Type);
            Assert.Equal(value, assertionConfig.Value);
        }

        [Fact]
        public void IParentConfig() {
            // 入力値準備
            string parentId = "00010001";
            string id = "00010002";
            string pathName = "path";
            string title = "title";
            string description = "description";

            // インターフェイスはインスタンス化できないため、テスト用のダミークラスを作成して使用
            var achievementConfig = new AchievementConfig(
                parentId,
                id,
                pathName,
                title,
                description);

            // インターフェイスにキャスト
            IParentConfig parentConfig = (IParentConfig)achievementConfig;
            
            // 内容確認
            Assert.Equal(parentId, parentConfig.ParentId);
        }
    }
}
