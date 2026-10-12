using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Desktop.Api.Struct;
using FactStatus.Desktop.Internal.Logic;

namespace FactStatus.Desktop.Api.Main {
    public class FactStatusDesktopMain {
        private FactStatusDesktopPolicy _factStatusDesktopPolicy;

        /// <summary>
        /// IDに紐づくデータの取得
        /// </summary>
        public string GetData(string entityId) {
            return this._factStatusDesktopPolicy.GetData(entityId);
        }

        public string GetParentData() {
            return this._factStatusDesktopPolicy.GetParentData();
        }

        /// <summary>
        /// IDに紐づくデータの更新
        /// </summary>
        public void UpdateData(string attributeId, string data) {
            this._factStatusDesktopPolicy.UpdateData(attributeId, data);
        }

        /// <summary>
        /// IDに紐づくデータの削除
        /// </summary>
        public void DeleteDatas(List<string> entityIdList) {
            this._factStatusDesktopPolicy.DeleteDatas(entityIdList);
        }

        /// <summary>
        /// IDのデータを追加
        /// </summary>
        public void AddDatas(List<AddEntityIdStruct> addEntityStructList) {
            this._factStatusDesktopPolicy.AddDatas(addEntityStructList);
        }

        /// <summary>
        /// IDのデータを移動
        /// </summary>
        public void MoveDatas(List<PairEntityIdStruct> pairEntityStructList) {
            this._factStatusDesktopPolicy.MoveDatas(pairEntityStructList);
        }

        /// <summary>
        /// IDのデータをコピー
        /// </summary>
        public void CopyDatas(List<PairEntityIdStruct> pairEntityStructList) {
            this._factStatusDesktopPolicy.CopyDatas(pairEntityStructList);
        }

        /// <summary>
        /// 複数のIDをグループ化する
        /// </summary>
        public void GroupData(List<GroupEntityIdStruct> groupEntityStructList) {
            this._factStatusDesktopPolicy.GroupData(groupEntityStructList);
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            return this._factStatusDesktopPolicy.GetAchievementCount();
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return this._factStatusDesktopPolicy.GetEvidenceCount();
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return this._factStatusDesktopPolicy.GetResultCount();
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return this._factStatusDesktopPolicy.GetSuccessCount();
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return this._factStatusDesktopPolicy.GetFailureCount();
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public List<FailureAggregateStruct> GetFailureAggregateList() {
            return this._factStatusDesktopPolicy.GetFailureAggregateList();
        }

        /// <summary>
        /// jsonファイルの読み込み
        /// </summary>
        public void LoadJson(string loadFilePath) {
            this._factStatusDesktopPolicy.LoadJson(loadFilePath);
        }
        
        /// <summary>
        /// jsonファイルの書き込み
        /// </summary>
        public void SaveJson(string saveFilePath) {
            this._factStatusDesktopPolicy.SaveJson(saveFilePath);
        }

        /// <summary>
        /// xmlファイルの読み込み
        /// </summary>
        public void LoadXml(string loadFilePath) {
            this._factStatusDesktopPolicy.LoadXml(loadFilePath);
        }
        
        /// <summary>
        /// xmlファイルの書き込み
        /// </summary>
        public void SaveXml(string saveFilePath) {
            this._factStatusDesktopPolicy.SaveXml(saveFilePath);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot(string loadFilePath) {
            this._factStatusDesktopPolicy.LoadMarkdownRoot(loadFilePath);
        }

        /// <summary>
        /// Markdownルートの書き込み
        /// </summary>
        public void SaveMarkdownRoot(string saveFilePath) {
            this._factStatusDesktopPolicy.SaveMarkdownRoot(saveFilePath);
        }

        /// <summary>
        /// MarkdownTypeから読み込み
        /// </summary>
        public void LoadMarkdownType(string loadFilePath) {
            this._factStatusDesktopPolicy.LoadMarkdownType(loadFilePath);
        }
        
        /// <summary>
        /// MarkdownTypeの書き込み
        /// </summary>
        public void SaveMarkdownType(string saveFilePath) {
            this._factStatusDesktopPolicy.SaveMarkdownType(saveFilePath);
        }

        /// <summary>
        /// Markdownから読み込み
        /// </summary>
        public void LoadMarkdown(string loadFilePath) {
            this._factStatusDesktopPolicy.LoadMarkdown(loadFilePath);
        }

        /// <summary>
        /// Markdownの書き込み
        /// </summary>
        public void SaveMarkdown(string saveFilePath) {
            this._factStatusDesktopPolicy.SaveMarkdown(saveFilePath);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusDesktopMain(FactStatusDesktopPolicy factStatusDesktopPolicy) {
            _factStatusDesktopPolicy = factStatusDesktopPolicy;
        }
    }
}
