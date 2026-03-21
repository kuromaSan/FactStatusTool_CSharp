using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FactStatus.Domain.Setup {
    public class JsonDto {
        public required DocumentConfigJsonDto DocumentConfig { get; set; }
        public required List<SubjectConfigJsonDto> SubjectConfigs { get; set; }
        public required List<AchievementConfigJsonDto> AchievementConfigs { get; set; }
        public required List<EvidenceConfigJsonDto> EvidenceConfigs { get; set; }
        public required List<ResultConfigJsonDto> ResultConfigs { get; set; }
        public required List<RecordConfigJsonDto> RecordConfigs { get; set; }
        public required List<TodoConfigJsonDto> TodoConfigs { get; set; }
        public required List<SchemaConfigJsonDto> SchemaConfigs { get; set; }
        public required List<GroupConfigJsonDto> GroupConfigs { get; set; }
        public required List<ArgumentPropertieJsonDto> ArgumentProperties { get; set; }
        public required List<AssertionPropertieJsonDto> AssertionProperties { get; set; }
        public required List<ParentEdgeJsonDto> ParentEdges { get; set; }
        public required List<GroupEdgeJsonDto> GroupEdges { get; set; }
    }

    public class DocumentConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class SubjectConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class AchievementConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class EvidenceConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("success")]
        public required string Success { get; set; }
    }

    public class ResultConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }

    public class RecordConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("date")]
        public required string Date { get; set; } // "2000-00-00"
        [JsonPropertyName("reviewer")]
        public required string Reviewer { get; set; }
        [JsonPropertyName("success")]
        public required string Success { get; set; }
    }

    public class TodoConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }

    public class SchemaConfigJsonDto {
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
        [JsonPropertyName("hypothesis")]
        public required string Hypothesis { get; set; }
        [JsonPropertyName("abstraction_goal")]
        public required string AbstractionGoal { get; set; }
        [JsonPropertyName("execution_goal")]
        public required string ExecutionGoal { get; set; }
    }

    public class GroupConfigJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("path_name")]
        public required string PathName { get; set; }
        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }

    public class ArgumentPropertieJsonDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("listIndex")]
        public required string ListIndex { get; set; }
        [JsonPropertyName("keyIndex")]
        public required string KeyIndex { get; set; }
        [JsonPropertyName("keyName")]
        public required string KeyName { get; set; }
        [JsonPropertyName("dataType")]
        public required string DataType { get; set; }
        [JsonPropertyName("value")]
        public required string Value { get; set; }
    }

    public class AssertionPropertieJsonDto {
        [JsonPropertyName("parent_id")]
        public required string ParentId { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("assert")]
        public required string Assert { get; set; }
        [JsonPropertyName("target")]
        public required string Target { get; set; }
        [JsonPropertyName("dataType")]
        public required string DataType { get; set; }
        [JsonPropertyName("value")]
        public required string Value { get; set; }
    }

    public class ParentEdgeJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("from_id")]
        public required string FromId { get; set; }
        [JsonPropertyName("to_id")]
        public required string ToId { get; set; }
    }
    
    public class GroupEdgeJsonDto {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("from_id")]
        public required string FromId { get; set; }
        [JsonPropertyName("to_id")]
        public required string ToId { get; set; }
        [JsonPropertyName("sequence")]
        public required string Sequence { get; set; }
    }
}
