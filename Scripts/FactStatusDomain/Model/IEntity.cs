using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    public interface IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; }
        public string Title { get; }
    }
}
