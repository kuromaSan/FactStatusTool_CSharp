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
        public bool Success { get; private set; } = true;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="success"></param>
        public EvidenceEntity(
            string id,
            string pathName,
            string title,
            string description,
            bool success) {

            Id = new IdValue(id);
            PathName = new PathValue(pathName, PathTypeEnum.Directory);
            Title = title ?? "";
            Description = description ?? "";
            Success = success;
        }
    }
}
