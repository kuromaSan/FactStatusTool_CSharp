using FactStatus.Domain.Internal.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Internal.Entity {
    public interface IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; }
        public string Title { get; }
    }
}
