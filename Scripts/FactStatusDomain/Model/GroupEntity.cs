using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 部門クラス
    /// </summary>
    public class GroupEntity : IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        public GroupEntity(
            string id,
            string pathName,
            string title) {

            Id = new IdValue(id);
            PathName = new PathValue(pathName, PathTypeEnum.Directory);
            Title = title ?? "";
        }
    }
}
