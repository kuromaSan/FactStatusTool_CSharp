using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Desktop.Internal.Domain {
    public interface IFactStatusDomainMain {
        /// <summary>
        /// IDに紐づくデータの取得
        /// </summary>
        string GetId(string entityId);

        /// <summary>
        /// IDに紐づく親データの取得
        /// </summary>
        string GetParentId();

        /// <summary>
        /// IDに紐づくデータの更新
        /// </summary>
        void UpdateId(string attributeId, string data);

        /// <summary>
        /// IDに紐づくデータの削除
        /// </summary>
        void DeleteId(string entityId);

        /// <summary>
        /// IDのデータを追加
        /// </summary>
        void AddId(string destinationEntityId, string idType, string title, string pathName);

        /// <summary>
        /// IDのデータを移動
        /// </summary>
        void MoveId(string sourceEntityId, string destinationEntityId);

        /// <summary>
        /// IDのデータをコピー
        /// </summary>
        void CopyId(string sourceEntityId, string destinationEntityId);

        /// <summary>
        /// 複数のIDをグループ化する
        /// </summary>
        void GroupId(string parentId, string title, List<string> entityIdList);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetAchievementCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetEvidenceCount();

        int GetResultCount();

        int GetSuccessCount();

        int GetFailureCount();

        List<IFactStatusDomainFailureAggregate> GetFailureAggregateList();

        void LoadJson(string loadFilePath);

        void SaveJson(string loadFilePath);

        void LoadXml(string loadFilePath);

        void SaveXml(string loadFilePath);

        void LoadMarkdownRoot(string loadFilePath);

        void SaveMarkdownRoot(string loadFilePath);

        void LoadMarkdownType(string loadFilePath);

        void SaveMarkdownType(string loadFilePath);

        void LoadMarkdown(string loadFilePath);

        void SaveMarkdown(string loadFilePath);
    }
}
