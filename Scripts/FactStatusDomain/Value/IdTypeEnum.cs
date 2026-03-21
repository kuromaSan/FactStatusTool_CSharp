using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Value {
    public enum IdTypeEnum {
        None = 0,
        DocumentEntity = 1,
        SubjectEntity = 2,
        AchievementEntity = 3,
        EvidenceEntity = 4,
        ResultEntity = 5,
        RecordEntity = 6,
        TodoEntity = 7,
        SchemaEntity = 8,
        GroupEntity = 9,
        ArgumentEntity = 104,
        AssertionEntity = 204
    }
}
