using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 結果クラス
    /// </summary>
    public class ResultEntity : IEntity {

        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public List<ArgumentEntity> Arguments { get; private set; }
        public List<AssertionEntity> Assertions { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="arguments"></param>
        /// <param name="assertions"></param>
        public ResultEntity(
            string id,
            string pathName,
            string title,
            List<ArgumentEntity> arguments,
            List<AssertionEntity> assertions) {

            Id = new IdValue(id);
            PathName = new PathValue(pathName, PathTypeEnum.Directory);
            Title = title ?? "";
            Arguments = arguments;
            Assertions = assertions;
        }
    }
}
