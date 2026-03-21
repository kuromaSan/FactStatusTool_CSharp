using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Xunit.Abstractions;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Value;

namespace Tests.FactStatus.Logic {
    public class FactStatusStrategyTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void StringIdToIdTypeEnumTest() {
            var mockFactStatusRepo = new Mock<FactStatusRepository>();
            var mockJsonRepo = new Mock<JsonRepository>();
            var mockMarkdownRepo = new Mock<MarkdownRepository>();

            var factStatusStrategy = new FactStatusStrategy(mockFactStatusRepo.Object, mockJsonRepo.Object, mockMarkdownRepo.Object);
            
            Assert.Equal(IdTypeEnum.SubjectEntity, IdTypeEnum.DocumentEntity);
        }
    }
}
