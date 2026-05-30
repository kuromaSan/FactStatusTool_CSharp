using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Model {
    
    /// <summary>
    /// 構想クラス
    /// </summary>
    public class SchemaEntity : IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Experience { get; private set; }
        public string Evaluation { get; private set; }
        public string Hypothesis { get; private set; }
        public string AbstractionGoal { get; private set; }
        public string ExecutionGoal { get; private set; }

        public void ChangePathName(string pathName) {
            PathName = PathValue.PathIsDirectory(pathName);
        }

        public void ChangeTitle(string title) {
            Title = title ?? "";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="experience"></param>
        /// <param name="evaluation"></param>
        /// <param name="hypothesis"></param>
        /// <param name="abstractionGoal"></param>
        /// <param name="executionGoal"></param>
        public SchemaEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string experience,
            string evaluation,
            string hypothesis,
            string abstractionGoal,
            string executionGoal) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Experience = experience ?? "";
            Evaluation = evaluation ?? "";
            Hypothesis = hypothesis ?? "";
            AbstractionGoal = abstractionGoal ?? "";
            ExecutionGoal = executionGoal ?? "";
        }
    }
}
