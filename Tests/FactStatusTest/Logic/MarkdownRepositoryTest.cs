using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Setup;

namespace Tests.FactStatus.Logic {
    public class MarkdownRepositoryTest {
        private readonly ITestOutputHelper output;

        private FactStatusConfig CreateFactStatusConfig() {

            var factStatusBuilder = new FactStatusBuilder();
            return factStatusBuilder.Build();
        }

        [Fact]
        public void SaveMarkdownByRootTest() {
            // JsonからDocumentConfigを生成
            FactStatusConfig documentConfig = CreateFactStatusConfig();
            // Markdownの保存先ルートディレクトリ
            //string markdownRootDirectory = "D:/Action/FactStatus_CSharp";

            // MarkdownDtoを生成
            var markdownDtoBuilder = new MarkdownDtoBuilder();
            //markdownDtoBuilder.OfFactStatusConfig(documentConfig);
            //MarkdownDto markdownDto = markdownDtoBuilder.ListBuild();

            // Markdownを保存
            var markdownRepository = new MarkdownRepository();
            //markdownRepository.SaveMarkdownByRoot(markdownRootDirectory, markdownDto);
        }

        public MarkdownRepositoryTest(ITestOutputHelper output) {
            this.output = output;
        }
    }
}
