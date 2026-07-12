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
        /// エンティティを複製
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public GroupEntity Duplicate(
            IdValue id,
            PathValue path) {

            return new GroupEntity(id, path, Title);
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static GroupEntity Create(
            IdValue id,
            PathValue pathName,
            string title) {

            return new GroupEntity(
                id,
                pathName,
                title);
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static GroupEntity Build(
            IdValue id,
            string pathName,
            string title) {

            return new GroupEntity(
                id,
                PathValue.PathIsDirectory(pathName),
                title);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        public GroupEntity(
            IdValue id,
            PathValue pathName,
            string title) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
        }
    }
}
