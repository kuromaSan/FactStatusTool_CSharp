using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Setup {
    public class MarkdownRepository : IMarkdownRepository {

        public string LoadMarkdown(PathValue markdownPath) {
            // MarkdownDto
            string markdownDto = "";
            return markdownDto;
        }

        public void SaveMarkdown(PathValue markdownPath, MarkdownDto markdownDto) {
            foreach (var markdownItemDto in markdownDto.MarkdownItemDtoList) {
                File.WriteAllText($"{markdownPath}/{markdownItemDto.Directory}", markdownItemDto.Description);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MarkdownRepository() {
            // 処理なし
        }
    }
}
