using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {

    /// <summary>
    /// 実装クラス
    /// </summary>
    public class TodoEntity : IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public void ChangePathName(string pathName) {
            PathName = PathValue.PathIsDirectory(pathName);
        }

        public void ChangeTitle(string title) {
            Title = title ?? "";
        }

        public void ChangeDescription(string description) {
            Description = description ?? "";
        }

        /// <summary>
        /// エンティティを複製
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public TodoEntity Duplicate(
            IdValue id,
            PathValue path) {

            return new TodoEntity(id, path, Title, Description);
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static TodoEntity Create(
            IdValue id,
            PathValue pathName,
            string title) {

            return new TodoEntity(
                id,
                pathName,
                title,
                "");
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static TodoEntity Build(
            IdValue id,
            PathValue pathName,
            string title,
            string description) {

            return new TodoEntity(
                id,
                pathName,
                title,
                description);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public TodoEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description){

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
        }
    }
}
