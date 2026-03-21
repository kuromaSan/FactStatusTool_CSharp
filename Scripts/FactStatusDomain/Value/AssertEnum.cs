using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Value {
    public enum AssertEnum {
        None,
        Equal,
        NotEqual,
        True,
        False,
        Null,
        NotNull,
        GreaterThan,
        GreaterOrEqual,
        LessThan,
        LessOrEqual,
        Same,
        NotSame,
        Throws,
        DoesNotThrow,
        InstanceOf,
        Count,
        Contains,
        NotContains,
        Empty,
        NotEmpty,
    }
}
