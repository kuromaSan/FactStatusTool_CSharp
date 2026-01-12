using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Value {
    public class AssertionValue {
        string Assert { get; }
        string Target { get; }
        string Type { get; }
        string Value { get; }

        public AssertionValue(
            string assert,
            string target,
            string type,
            string value) {

            this.Assert = assert;
            this.Target = target;
            this.Type = type;
            this.Value = value;
        }
    }
}
