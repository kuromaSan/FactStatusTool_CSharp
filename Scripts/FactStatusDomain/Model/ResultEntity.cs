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
        /// パス名の変更
        /// </summary>
        /// <param name="pathName"></param>
        public void ChangePathName(string pathName) {
            PathName = PathValue.PathIsDirectory(pathName);
        }

        /// <summary>
        /// タイトルの変更
        /// </summary>
        /// <param name="title"></param>
        public void ChangeTitle(string title) {
            Title = title ?? "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ArgumentEntity> GetArguments() {
            return Arguments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AssertionEntity> GetAssertions() {
            return Assertions;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="arguments"></param>
        /// <param name="assertions"></param>
        public ResultEntity(
            IdValue id,
            PathValue pathName,
            string title,
            List<ArgumentEntity> arguments,
            List<AssertionEntity> assertions) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Arguments = arguments;
            Assertions = assertions;
        }
    }
}
