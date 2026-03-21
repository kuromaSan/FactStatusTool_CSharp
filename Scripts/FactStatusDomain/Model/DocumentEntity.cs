using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// ドキュメントクラス
    /// </summary>
    public class DocumentEntity : IEntity {

        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="description"></param>
        public DocumentEntity(string description) {
            Id = new IdValue("00010000");
            PathName = new PathValue("Documents",PathTypeEnum.Directory);
            Title = "ドキュメント";
            Description = description ?? "";
        }
    }
}
