using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Desktop.Internal.Domain;
using FactStatus.Desktop.Api.Struct;

namespace FactStatus.Desktop.Internal.Logic {
    public class FactStatusDesktopPolicy {
        private IFactStatusDomainMain _factStatusDomainMain;
        private FactStatusDesktopStrategy _factStatusDesktopStrategy;

        /// <summary>
        /// IDに紐づくデータの取得
        /// </summary>
        public string GetData(string entityId) {
            string data = this._factStatusDomainMain.GetId(entityId);
            return "";
        }

        /// <summary>
        /// IDに紐づく親データの取得
        /// </summary>
        public string GetParentData() {
            this._factStatusDomainMain.GetParentId();
            return "";
        }

        /// <summary>
        /// IDに紐づくデータの更新
        /// </summary>
        public void UpdateData(string attributeId, string data) {
            this._factStatusDomainMain.UpdateId(attributeId, data);
        }

        /// <summary>
        /// IDに紐づくデータの削除
        /// </summary>
        public void DeleteDatas(List<string> entityIdList) {
            foreach (string entityId in entityIdList) {
                this._factStatusDomainMain.DeleteId(entityId);
            }
        }

        /// <summary>
        /// IDのデータを追加
        /// </summary>
        public void AddDatas(List<AddEntityIdStruct> addEntityStructList) {
            foreach (AddEntityIdStruct addEntityStruct in addEntityStructList) {
                this._factStatusDomainMain.AddId(
                    addEntityStruct.DestinationEntityId,
                    addEntityStruct.IdType,
                    addEntityStruct.Title,
                    addEntityStruct.PathName);
            }
        }

        /// <summary>
        /// IDのデータを移動
        /// </summary>
        public void MoveDatas(List<PairEntityIdStruct> pairEntityStructList) {
            foreach (PairEntityIdStruct pairEntityStruct in pairEntityStructList) {
                this._factStatusDomainMain.MoveId(
                    pairEntityStruct.TargetId,
                    pairEntityStruct.DestinationId);
            }
        }

        /// <summary>
        /// IDのデータをコピー
        /// </summary>
        public void CopyDatas(List<PairEntityIdStruct> pairEntityStructList) {
            foreach (PairEntityIdStruct pairEntityStruct in pairEntityStructList) {
                this._factStatusDomainMain.CopyId(
                    pairEntityStruct.TargetId,
                    pairEntityStruct.DestinationId);
            }
        }

        /// <summary>
        /// 複数のIDをグループ化する
        /// </summary>
        public void GroupData(List<GroupEntityIdStruct> groupEntityStructList) {
            foreach (GroupEntityIdStruct groupEntityStruct in groupEntityStructList) {
                this._factStatusDomainMain.GroupId(
                    groupEntityStruct.parentId,
                    groupEntityStruct.title,
                    groupEntityStruct.entityIdList);
            }
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            return this._factStatusDomainMain.GetAchievementCount();
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return this._factStatusDomainMain.GetEvidenceCount();
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return this._factStatusDomainMain.GetResultCount();
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return this._factStatusDomainMain.GetSuccessCount();
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return this._factStatusDomainMain.GetFailureCount();
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public List<FailureAggregateStruct> GetFailureAggregateList() {
            var failureAggregateList = this._factStatusDomainMain.GetFailureAggregateList();
            return this._factStatusDesktopStrategy.ConvertFailureAggregateStruct(failureAggregateList);
        }

        /// <summary>
        /// jsonファイルの読み込み
        /// </summary>
        public void LoadJson(string loadFilePath) {
            this._factStatusDomainMain.LoadJson(loadFilePath);
        }
        
        /// <summary>
        /// jsonファイルの書き込み
        /// </summary>
        public void SaveJson(string saveFilePath) {
            this._factStatusDomainMain.SaveJson(saveFilePath);
        }

        /// <summary>
        /// xmlファイルの読み込み
        /// </summary>
        public void LoadXml(string loadFilePath) {
            this._factStatusDomainMain.LoadXml(loadFilePath);
        }
        
        /// <summary>
        /// xmlファイルの書き込み
        /// </summary>
        public void SaveXml(string saveFilePath) {
            this._factStatusDomainMain.SaveXml(saveFilePath);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot(string loadFilePath) {
            this._factStatusDomainMain.LoadMarkdownRoot(loadFilePath);
        }

        /// <summary>
        /// Markdownルートの書き込み
        /// </summary>
        public void SaveMarkdownRoot(string saveFilePath) {
            this._factStatusDomainMain.SaveMarkdownRoot(saveFilePath);
        }

        /// <summary>
        /// MarkdownTypeから読み込み
        /// </summary>
        public void LoadMarkdownType(string loadFilePath) {
            this._factStatusDomainMain.LoadMarkdownType(loadFilePath);
        }
        
        /// <summary>
        /// MarkdownTypeの書き込み
        /// </summary>
        public void SaveMarkdownType(string saveFilePath) {
            this._factStatusDomainMain.SaveMarkdownType(saveFilePath);
        }

        /// <summary>
        /// Markdownから読み込み
        /// </summary>
        public void LoadMarkdown(string loadFilePath) {
            this._factStatusDomainMain.LoadMarkdown(loadFilePath);
        }

        /// <summary>
        /// Markdownの書き込み
        /// </summary>
        public void SaveMarkdown(string saveFilePath) {
            this._factStatusDomainMain.SaveMarkdown(saveFilePath);
        }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusDesktopPolicy(
            IFactStatusDomainMain factStatusDomainMain,
            FactStatusDesktopStrategy factStatusDesktopStrategy) {

            this._factStatusDomainMain = factStatusDomainMain;
            this._factStatusDesktopStrategy = factStatusDesktopStrategy;
        }
    }
}
