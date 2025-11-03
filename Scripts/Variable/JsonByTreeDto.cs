using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
    public class JsonByTreeDtoByTree {
        [JsonPropertyName("Subject")]
        public List<SubjectDtoByTree> Subject { get; set; } = [];
    }

    public class SubjectDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("Todo")]
        public List<TodoDtoByTree>? Todo { get; set; }

        [JsonPropertyName("Schema")]
        public List<SchemaDtoByTree>? Schema { get; set; }
    }

    public class TodoDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("Evidence")]
        public List<EvidenceDtoByTree>? Evidence { get; set; }

        [JsonPropertyName("Process")]
        public List<ProcessDtoByTree>? Process { get; set; }

        [JsonPropertyName("Schema")]
        public List<SchemaDtoByTree>? Schema { get; set; }
    }

    public class EvidenceDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("Result")]
        public List<ResultDtoByTree>? Result { get; set; }

        [JsonPropertyName("Process")]
        public List<ProcessDtoByTree>? Process { get; set; }
    }

    public class ResultDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("expected_value")]
        public object? ExpectedValue { get; set; }

        [JsonPropertyName("expected_type")]
        public string? ExpectedType { get; set; }

        [JsonPropertyName("arguments")]
        public List<ArgumentDtoByTree>? Arguments { get; set; }

        [JsonPropertyName("exceptions")]
        public List<string>? Exceptions { get; set; }

        [JsonPropertyName("Record")]
        public List<RecordDtoByTree>? Record { get; set; }
    }

    public class ArgumentDtoByTree {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class RecordDtoByTree {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }  // "2000-01-01 00:00:00"

        [JsonPropertyName("reviewer")]
        public string? Reviewer { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("expected_value")]
        public object? ExpectedValue { get; set; }

        [JsonPropertyName("expected_type")]
        public string? ExpectedType { get; set; }

        [JsonPropertyName("messege")]
        public string? Messege { get; set; }

        [JsonPropertyName("exceptions")]
        public List<string>? Exceptions { get; set; }
    }

    public class ProcessDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("steps")]
        public List<string>? Steps { get; set; }
    }

    public class SchemaDtoByTree {
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("experience")]
        public string? Experience { get; set; }

        [JsonPropertyName("evaluation")]
        public string? Evaluation { get; set; }

        [JsonPropertyName("hypothesis")]
        public string? Hypothesis { get; set; }

        [JsonPropertyName("abstraction_goal")]
        public string? AbstractionGoal { get; set; }

        [JsonPropertyName("execution_goal")]
        public string? ExecutionGoal { get; set; }
    }
}
