using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FactStatusTool.Tests.Variable {
    public class FactStatusConfigTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void FactStatusConfig() {
            var subject = new SubjectConfig(
                "001",
                "pathA",
                "subjectA",
                "descA");
            var todo = new TodoConfig(
                "001",
                "002",
                "pathB",
                "todoB",
                "descB");
            var evidence = new EvidenceConfig(
                "P1",
                "V1",
                "pathV",
                "valA",
                "descV");
            var result = new ResultConfig(
                "P2",
                "R1",
                "pathR",
                "resA",
                true,
                "exp",
                "string",
                "none");
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            var record = new RecordConfig(
                "P4",
                "R2",
                "pathRec",
                "recordA",
                date,
                "rev",
                true,
                "expVal",
                "bool",
                "none",
                "message");
            var process = new ProcessConfig(
                "P5",
                "PR1",
                "pathProc",
                "processA");
            var schema = new SchemaConfig(
                "P7",
                "SC1",
                "pathSchema",
                "schemaA",
                "exp",
                "eval",
                "abd",
                "absGoal",
                "execGoal");
            var arg = new ArgumentConfig(
                "P3",
                "A1",
                "key1",
                "int",
                "10");
            var step = new StepConfig(
                "P6",
                "S1",
                "doSomething");

            var config = new FactStatusConfig(
                new List<SubjectConfig> { subject },
                new List<TodoConfig> { todo },
                new List<EvidenceConfig> { evidence },
                new List<ResultConfig> { result },
                new List<ArgumentConfig> { arg },
                new List<RecordConfig> { record },
                new List<ProcessConfig> { process },
                new List<StepConfig> { step },
                new List<SchemaConfig> { schema });

            Assert.Single(config.SubjectConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.TodoConfigList);
            Assert.Single(config.TodoConfigList);
        }

        [Fact]
        public void SubjectConfig() {
            var subject = new SubjectConfig("001", "pathA", "subjectA", "descA");
            Assert.Equal("001", subject.Id);
            Assert.Equal("pathA", subject.PathName);
            Assert.Equal("subjectA", subject.Title);
            Assert.Equal("descA", subject.Description);
        }

        [Fact]
        public void TodoConfig() {
            var todo = new TodoConfig("001", "002", "pathB", "todoB", "descB");

            Assert.Equal("001", todo.ParentId);
            Assert.Equal("002", todo.Id);
            Assert.Equal("pathB", todo.PathName);
            Assert.Equal("todoB", todo.Title);
            Assert.Equal("descB", todo.Description);
        }
        
        [Fact]
        public void EvidenceConfig() {
            var evidence = new EvidenceConfig("P1", "V1", "pathV", "valA", "descV");

            Assert.Equal("P1", evidence.ParentId);
            Assert.Equal("V1", evidence.Id);
            Assert.Equal("pathV", evidence.PathName);
            Assert.Equal("valA", evidence.Title);
            Assert.Equal("descV", evidence.Description);
        }
        
        [Fact]
        public void ResultConfig() {
            var result = new ResultConfig("P2", "R1", "pathR", "resA", true, "exp", "string", "none");

            Assert.True(result.Success);
            Assert.Equal("exp", result.ExpectedValue);
            Assert.Equal("string", result.ExpectedType);
            Assert.Equal("none", result.ExceptionType);
        }

        [Fact]
        public void RecordConfig() {
            var date = DateTime.ParseExact(
                "2000-10-10 10:10:10",
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
            var record = new RecordConfig("P4", "R2", "pathRec", "recordA",
                date, "rev", true, "expVal", "bool", "none", "message");

            Assert.Equal("rev", record.Reviewer);
            Assert.True(record.Success);
            Assert.Equal("bool", record.ExpectedType);
            Assert.Equal(date, record.Date);
            Assert.Equal("message", record.Message);
        }

        [Fact]
        public void ProcessConfig() {
            var process = new ProcessConfig("P5", "PR1", "pathProc", "processA");

            Assert.Equal("processA", process.Title);
            Assert.Equal("pathProc", process.PathName);
        }

        [Fact]
        public void SchemaConfig() {
            var schema = new SchemaConfig("P7", "SC1", "pathSchema", "schemaA",
                "exp", "eval", "abd", "absGoal", "execGoal");

            Assert.Equal("schemaA", schema.Title);
            Assert.Equal("exp", schema.Experience);
            Assert.Equal("eval", schema.Evaluation);
            Assert.Equal("absGoal", schema.AbstractGoal);
            Assert.Equal("execGoal", schema.ExecutionGoal);
        }

        [Fact]
        public void ArgumentConfig() {
            var arg = new ArgumentConfig("P3", "A1", "key1", "int", "10");

            Assert.Equal("key1", arg.Key);
            Assert.Equal("int", arg.Type);
            Assert.Equal("10", arg.Value);
        }

        [Fact]
        public void StepConfig() {
            var step = new StepConfig("P6", "S1", "doSomething");

            Assert.Equal("doSomething", step.Value);
            Assert.Equal("S1", step.Id);
        }

        [Fact]
        public void IParentConfig() {
        }
    }
}
