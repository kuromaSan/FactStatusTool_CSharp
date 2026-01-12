using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Value {
    public class ArgumentValue {
        string Key { get; }
        string Type { get; }
        string Value { get; }

        public ArgumentValue(
            string key,
            string type,
            string value) {

            this.Key = key;
            this.Type = type;
            this.Value = value;
        }
    }
}
