using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Internal.Value;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Desktop.Internal.Domain;

namespace FactStatus.Domain.Api.Main {
    public class FactStatusCrafter : IFactStatusDomainCrafter {
        private readonly FactStatusDomainPolicy _factStatusPolicy;
        private FactStatusBuilder _factStatusBuilder;

        /// <summary>
        /// FactStatusオブジェクトを生成(SQLite(.db)ファイル)
        /// </summary>
        /// <returns>FactStatusDomainMain</returns>
        public FactStatusDomainMain LoadFile(string loadFilePath) {
            PathValue pathValue = PathValue.PathIsRootFile(loadFilePath);
            FactStatusDomainAggregate factStatusDomainAggregate = _factStatusBuilder.LoadFile(pathValue);
            return new FactStatusDomainMain(factStatusDomainAggregate, _factStatusPolicy);
        }
        
        /// <summary>
        /// FactStatusオブジェクトを生成(JSONファイル)
        /// </summary>
        /// <returns>FactStatusDomainMain</returns>
        public FactStatusDomainMain LoadJson(string loadFilePath) {
            PathValue pathValue = PathValue.PathIsRootFile(loadFilePath);
            FactStatusDomainAggregate factStatusDomainAggregate = _factStatusBuilder.LoadJson(pathValue);
            return new FactStatusDomainMain(factStatusDomainAggregate, _factStatusPolicy);
        }
        
        /// <summary>
        /// FactStatusオブジェクトを生成(XMLファイル)
        /// </summary>
        /// <returns>FactStatusDomainMain</returns>
        public FactStatusDomainMain LoadXml(string loadFilePath) {
            PathValue pathValue = PathValue.PathIsRootFile(loadFilePath);
            FactStatusDomainAggregate factStatusDomainAggregate = _factStatusBuilder.LoadXml(pathValue);
            return new FactStatusDomainMain(factStatusDomainAggregate, _factStatusPolicy);
        }

        /// <summary>
        /// FactStatusオブジェクトを生成(Markdownルート)
        /// </summary>
        /// <returns>FactStatusDomainMain</returns>
        public FactStatusDomainMain LoadMarkdown(string loadPathDirectory) {
            PathValue pathValue = PathValue.PathIsDirectory(loadPathDirectory);
            FactStatusDomainAggregate factStatusDomainAggregate = _factStatusBuilder.LoadMarkdown(pathValue);
            return new FactStatusDomainMain(factStatusDomainAggregate, _factStatusPolicy);
        }

        /// <summary>
        /// FactStatusCrafterの生成
        /// </summary>
        /// <returns>FactStatusCrafter</returns>
        public static FactStatusCrafter Create() {
            return new FactStatusCrafter();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusCrafter() {
            // FactStatusの生成
            var factStatusRepository = new SQLiteRepository();
            var jsonRepository = new JsonRepository();
            var markdownRepository = new MarkdownRepository();
            var factStatusStrategy = new FactStatusDomainStrategy(factStatusRepository,jsonRepository, markdownRepository);
            this._factStatusPolicy = new FactStatusDomainPolicy(factStatusStrategy);
            this._factStatusBuilder = new FactStatusBuilder();
        }
    }
}
