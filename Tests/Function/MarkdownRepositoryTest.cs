using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FactStatusTool.Tests.Function {
    public class MarkdownRepositoryTest {
        private readonly ITestOutputHelper output;

        private FactStatusConfig CreateDocumentConfig() {
            var documentStrategy = new FactStatusStrategy(new JsonRepository(), new MarkdownRepository());
            FactStatusConfig documentConfig = documentStrategy.LoadJsonByRelational("D:/Action/__CoreTemplateIDCM/Document/RelationalData.json");
            return documentConfig;
        }

        [Fact]
        public void SaveMarkdownByRootTest() {
            // JsonからDocumentConfigを生成
            FactStatusConfig documentConfig = CreateDocumentConfig();
            // Markdownの保存先ルートディレクトリ
            string markdownRootDirectory = "D:/Action/FactStatus_CSharp";

            // MarkdownDtoを生成
            var markdownDtoBuilder = new MarkdownDtoBuilder();
            markdownDtoBuilder.OfFactStatusConfig(documentConfig);
            MarkdownDto markdownDto = markdownDtoBuilder.ListBuild();

            // Markdownを保存
            var markdownRepository = new MarkdownRepository();
            markdownRepository.SaveMarkdownByRoot(markdownRootDirectory, markdownDto);
        }

        public MarkdownRepositoryTest(ITestOutputHelper output) {
            this.output = output;
        }
    }
}
