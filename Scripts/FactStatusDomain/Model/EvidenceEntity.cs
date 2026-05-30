using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 証拠クラス
    /// </summary>
    public class EvidenceEntity : IEntity {

        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public BoolValue Success { get; private set; }

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
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(bool success) {
            Success = new BoolValue(success);
        }
        
        /// <summary>
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(int success) {
            Success = BoolValue.FromInt(success);
        }
        
        /// <summary>
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(string success) {
            Success = BoolValue.FromString(success);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="success"></param>
        public EvidenceEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description,
            BoolValue success) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
            Success = success;
        }
    }
}
