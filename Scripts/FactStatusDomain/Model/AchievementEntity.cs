using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 達成設定クラス
    /// </summary>
    public class AchievementEntity : IEntity {
        
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// パス名の変更
        /// </summary>
        /// <param name="pathName"></param>
        public void ChangePathName(PathValue pathName) {
            PathName = pathName;
        }
        
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
        /// 内容の変更
        /// </summary>
        /// <param name="description"></param>
        public void ChangeDescription(string description) {
            Description = description ?? "";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public AchievementEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
        }
    }
}
