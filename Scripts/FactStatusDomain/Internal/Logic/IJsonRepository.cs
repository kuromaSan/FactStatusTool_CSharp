using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Api.Value;

namespace FactStatus.Domain.Internal.Logic {
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
