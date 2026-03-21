using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 主題設定クラス
    /// </summary>
    public class SubjectEntity : IEntity {

        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public void ChangePathName(string pathName) {
            PathName.Change(pathName);
        }

        public void ChangeTitle(string title) {
            Title = title ?? "";
        }

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
        public SubjectEntity(
            string id,
            string pathName,
            string title,
            string description) {

            // 
            Id = new IdValue(id);
            PathName = new PathValue(pathName,PathTypeEnum.Directory);
            Title = title ?? "";
            Description = description ?? "";
        }
    }
}
