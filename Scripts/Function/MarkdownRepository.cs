using FactStatusTool.Scripts.Variable;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Function {
    public class MarkdownRepository {
        public string LoadMarkdownBySingle(string markdownRootDirectory, string markdownFilePath) {
            string markdownNode = "";
            return markdownNode;
        }

        public string LoadMarkdownByRoot(string markdownRootDirectory) {

            string markdownNode = "";
            return markdownNode;
        }

        public void SaveMarkdownBySingle(string markdownRootDirectory, MarkdownItemDto markdownItemDto) {
            File.WriteAllText($"{markdownRootDirectory}/{markdownItemDto.Directory}", markdownItemDto.Description);
        }

        public void SaveMarkdownByRoot(string markdownRootDirectory, MarkdownDto markdownDto) {
            foreach (var markdownItemDto in markdownDto.MarkdownItemDtoList) {
                File.WriteAllText($"{markdownRootDirectory}/{markdownItemDto.Directory}", markdownItemDto.Description);
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
