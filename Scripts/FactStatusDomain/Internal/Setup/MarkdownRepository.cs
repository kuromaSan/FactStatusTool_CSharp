using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Setup {
    public class MarkdownRepository {

        public List<MarkdownItemDto> LoadMarkdownList(PathValue markdownPath) {
            // MarkdownDto
            List<MarkdownItemDto> markdownItemDtoList = new List<MarkdownItemDto>();
            foreach (var filePath in Directory.GetFiles(markdownPath)) {
                string description = File.ReadAllText(filePath);
                string directory = Path.GetFileName(filePath);
                MarkdownItemDto markdownItemDto = new MarkdownItemDto(directory, description);
                markdownItemDtoList.Add(markdownItemDto);
            }
            return markdownItemDtoList;
        }

        public void SaveMarkdownList(PathValue markdownPath, List<MarkdownItemDto> markdownItemDtoList) {
            foreach (var markdownItemDto in markdownItemDtoList) {
                File.WriteAllText($"{markdownPath}/{markdownItemDto.Directory}", markdownItemDto.Description);
            }
        }

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
