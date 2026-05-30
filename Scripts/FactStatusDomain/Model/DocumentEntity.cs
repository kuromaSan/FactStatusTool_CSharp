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
        /// パス名の変更
        /// </summary>
        /// <param name="pathName"></param>
        private void ChangePathName(string pathName) {
            PathName = PathValue.PathIsDirectory(pathName);
        }

        /// <summary>
        /// タイトルの変更
        /// </summary>
        /// <param name="title"></param>
        private void ChangeTitle(string title) {
            Title = title;
        }

        /// <summary>
        /// 内容の変更
        /// </summary>
        /// <param name="description"></param>
        public void ChangeDiscription(string description) {
            Description = description ?? "";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="description"></param>
        public DocumentEntity(string description) {
            Id = new IdValue("00010001");
            PathName = new PathValue("Documents",PathTypeEnum.Directory);
            Title = "ドキュメント";
            Description = description ?? "";
        }
    }
}
