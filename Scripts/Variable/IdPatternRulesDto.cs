using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
   public class IdPatternRulesDto {
        [JsonPropertyName("classTypes")]
        public required Dictionary<string, string> ClassTypes { get; set; }
        [JsonPropertyName("propertyTypes")]
        public required Dictionary<string, Dictionary<string, string>> PropertyTypes { get; set; }
    }
}
