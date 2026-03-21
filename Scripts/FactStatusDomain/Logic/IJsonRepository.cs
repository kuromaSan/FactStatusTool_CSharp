using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Logic {
    public interface IJsonRepository {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <returns></returns>
        public JsonDto LoadJson(PathValue jsonFilePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="jsonByRelationalDto"></param>
        public void SaveJson(PathValue jsonFilePath, JsonDto jsonByRelationalDto);

    }
}
