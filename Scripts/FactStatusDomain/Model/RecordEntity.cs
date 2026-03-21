using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FactStatus.Domain.Rule;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 記録クラス
    /// </summary>
    public class RecordEntity : IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Reviewer { get; private set; }
        public bool Success { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="reviewer"></param>
        /// <param name="success"></param>
        public RecordEntity(
            string id,
            string pathName,
            string title,
            string description,
            DateTime date,
            string reviewer,
            bool success){

            Id = new IdValue(id);
            PathName = new PathValue(pathName, PathTypeEnum.Directory);
            Title = title ?? "";
            Description = description ?? "";
            
            Validation.DateTimeNotDefault(date);
            Validation.DateTimeNotFuture(date,DateTime.Now);
            Date = date;

            Validation.NullOfString(reviewer);
            Reviewer = reviewer;

            Success = success;
        }
    }
}
