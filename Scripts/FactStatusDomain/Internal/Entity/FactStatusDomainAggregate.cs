using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Entity {

    /// <summary>
    /// メモリでアクセスするのに必要な情報をまとめたクラス
    /// </summary>
    public class FactStatusDomainAggregate{
        // 保存ファイル名
        public PathValue SaveFileName { get; set; }

        // 選択エンティティ
        public IEntity SelectedEntity { get; set; }

        // 親のエンティティ
        public IEntity ParentEntity { get; set; }

        // 各エンティティ一覧
        public Dictionary<IdTypeEnum, List<IEntity>> AllEntityList { get; set; }

        // 検索結果のエンティティ一覧
        public List<IEntity> SearchedEntityList { get; set; }

        // 達成数
        public int AchievementCount { get; private set; }

        // 証拠数
        public int EvidenceCount { get; private set; }

        // 結果数
        public int ResultCount { get; private set; }

        // 成功数
        public int SuccessCount { get; private set; }

        // 失敗数
        public int FailureCount { get; private set; }

        // 失敗内容一覧
        public List<string> FailureContentList { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="saveFileName"></param>
        /// <param name="selectedEntity"></param>
        /// <param name="parentIdValue"></param>
        /// <param name="childrenIdValueList"></param>
        /// <param name="allIdValueList"></param>
        /// <param name="achievementCount"></param>
        /// <param name="evidenceCount"></param>
        /// <param name="resultCount"></param>
        /// <param name="successCount"></param>
        /// <param name="failureCount"></param>
        /// <param name="failureContentList"></param>
        public FactStatusDomainAggregate(
            PathValue saveFileName,
            IEntity selectedEntity,
            IEntity parentEntity,
            List<IEntity> allEntityList,
            List<IEntity> searchedEntityList,
            int achievementCount,
            int evidenceCount,
            int resultCount,
            int successCount,
            int failureCount,
            List<string> failureContentList) {

            this.SaveFileName = saveFileName;
            this.SelectedEntity = selectedEntity;
            this.ParentEntity = parentEntity;
            this.AllEntityList = allEntityList;
            this.SearchedEntityList = searchedEntityList;
            this.AchievementCount = achievementCount;
            this.EvidenceCount = evidenceCount;
            this.ResultCount = resultCount;
            this.SuccessCount = successCount;
            this.FailureCount = failureCount;
            this.FailureContentList = failureContentList;
        }
    }
}
