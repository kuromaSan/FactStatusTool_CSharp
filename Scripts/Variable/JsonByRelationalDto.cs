using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
    public class JsonByRelationalDto {
        [JsonPropertyName("Subjects")]
        public required List<SubjectJsonByRelationalDto> Subjects { get; set; }
        [JsonPropertyName("Todos")]
        public required List<TodoJsonByRelationalDto> Todos { get; set; }
        [JsonPropertyName("Validates")]
        public required List<ValidateJsonByRelationalDto> Validates { get; set; }
        [JsonPropertyName("Results")]
        public required List<ResultJsonByRelationalDto> Results { get; set; }
        [JsonPropertyName("arguments")]
        public required List<ArgumentJsonByRelationalDto> Arguments { get; set; }
        [JsonPropertyName("Records")]
        public required List<RecordJsonByRelationalDto> Records { get; set; }
        [JsonPropertyName("Processs")]
        public required List<ProcessJsonByRelationalDto> Processs { get; set; }
        [JsonPropertyName("steps")]
        public required List<StepJsonByRelationalDto> Steps { get; set; }
        [JsonPropertyName("Schemas")]
        public required List<SchemaJsonByRelationalDto> Schemas { get; set; }
    }

    public class SubjectJsonByRelationalDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class TodoJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class ValidateJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class ResultJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("success")]
        public required bool Success { get; set; }
        [JsonPropertyName("expected_value")]
        public required string ExpectedValue { get; set; }
        [JsonPropertyName("expected_type")]
        public required string ExpectedType { get; set; }
        [JsonPropertyName("exception_type")]
        public required string ExceptionType { get; set; }
    }

    public class RecordJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("date")]
        public required string Date { get; set; } // "2000-00-00"
        [JsonPropertyName("reviewer")]
        public required string Reviewer { get; set; }
        [JsonPropertyName("success")]
        public required bool Success { get; set; }
        [JsonPropertyName("expected_value")]
        public required string ExpectedValue { get; set; }
        [JsonPropertyName("expected_type")]
        public required string ExpectedType { get; set; }
        [JsonPropertyName("exception_type")]
        public required string ExceptionType { get; set; }
        [JsonPropertyName("message")]
        public required string Message { get; set; }
    }

    public class ProcessJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }

    public class SchemaJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("experience")]
        public required string Experience { get; set; }
        [JsonPropertyName("evaluation")]
        public required string Evaluation { get; set; }
        [JsonPropertyName("abduction")]
        public required string Abduction { get; set; }
        [JsonPropertyName("abstraction_goal")]
        public required string AbstractionGoal { get; set; }
        [JsonPropertyName("execution_goal")]
        public required string ExecutionGoal { get; set; }
    }

    public class ArgumentJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("key")]
        public required string Key { get; set; }
        [JsonPropertyName("type")]
        public required string Type { get; set; }
        [JsonPropertyName("value")]
        public required string Value { get; set; }
    }

    public class StepJsonByRelationalDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("value")]
        public required string Value { get; set; }
    }
}
