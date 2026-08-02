using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Api.Main;
using FactStatus.Domain.Api.Entity;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Api.Value;
using Xunit;
using Xunit.Abstractions;

namespace FactStatus.Domain.Test.Api.Main {
    public class FactStatusCrafterTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        /// <summary>
        /// 初期状態のFactStatusMainがビルドできること
        /// </summary>
        [Fact]
        public void InitFactStatusCrafterTest() {
            var factStatusCrafter = new FactStatusCrafter();
            FactStatusMain factStatusMain = factStatusCrafter.Build();
        }
        
        /// <summary>
        /// Jsonファイルを読み込んでビルドができること
        /// </summary>
        [Fact]
        public void CrafterForJsonTest() {
            var factStatusCrafter = new FactStatusCrafter();
            FactStatusMain factStatusMain = factStatusCrafter.Build();
        }
        
        /// <summary>
        /// Jsonファイルを読み込んでビルドができること
        /// </summary>
        [Fact]
        public void CrafterTest() {
            var factStatusCrafter = new FactStatusCrafter();
            FactStatusMain factStatusMain = factStatusCrafter.Build();
        }
    }
}
