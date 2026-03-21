using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Logic {
    public interface IFactStatusRepository {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public JsonDto LoadRelational(PathValue filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="relationalDto"></param>
        public void SaveRelational(PathValue filePath, JsonDto relationalDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IdPatternRulesDto LoadIdPatternRules(PathValue filePath);
    }
}
