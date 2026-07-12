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

namespace Domain.Test.Logic {
    public class MarkdownRepositoryTest {
        private readonly ITestOutputHelper output;

        private FactStatusAggregate CreateFactStatusAggregate() {

            var factStatusBuilder = new FactStatusBuilder();
            return factStatusBuilder.Build();
        }

        [Fact]
        public void SaveMarkdownByRootTest() {
            // JsonからDocumentAggregateを生成
            FactStatusAggregate documentAggregate = CreateFactStatusAggregate();
            // Markdownの保存先ルートディレクトリ
            //string markdownRootDirectory = "D:/Action/FactStatus_CSharp";

            // MarkdownDtoを生成
            var markdownDtoBuilder = new MarkdownDtoBuilder();
            //markdownDtoBuilder.OfFactStatusAggregate(documentAggregate);
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
