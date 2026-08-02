using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Api.Value;

namespace FactStatus.Domain.Internal.Logic {
    public interface IMarkdownRepository {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="markdownPath"></param>
        /// <returns></returns>
        public string LoadMarkdown(PathValue markdownPath);
        // MarkdownDto

        /// <summary>
        /// 
        /// </summary>
        /// <param name="markdownPath"></param>
        /// <param name="markdownDto"></param>
        public void SaveMarkdown(PathValue markdownPath, MarkdownDto markdownDto);
    }
}
