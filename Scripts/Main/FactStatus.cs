using FactStatusTool.Scripts.Logic;
using FactStatusTool.Scripts.Setup;
using FactStatusTool.Scripts.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Main {
    public class FactStatus (
    FactStatusConfig documentConfig,
    FactStatusPolicy documentPolicy) {
        private FactStatusConfig _DocumentConfig = documentConfig;
        private readonly FactStatusPolicy _DocumentPolicy = documentPolicy;

        /// <summary>
        /// 読み込むファイルパスを設定 
        /// </summary>
        public string? LoadFilePath { get; set; }

        /// <summary>
        /// 保存するファイルパスを設定
        /// </summary>
        public string? SaveFilePath { get; set; }

        /// <summary>
        /// 選択している設定IDを設定
        /// </summary>
        public string? SelectConfigId { get; set; }

        /// <summary>
        /// 設定タイプを設定
        /// </summary>
        public ConfigTypeEnum? ConfigTypeEnum { get; set; }

        /// <summary>
        /// プロパティを設定
        /// </summary>
        public PropertyEnum? PropertyEnum { get; set; }

        /// <summary>
        /// プロパティを編集する際の値を設定
        /// </summary>
        public string? EditValue { get; set; }

        /// <summary>
        /// 移動対象の設定IDを設定
        /// </summary>
        public string? MoveConfigId { get; set; }
        
        /// <summary>
        /// コピー対象の設定IDたちを設定
        /// </summary>
        public string? CopyConfigId { get; set; }

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public void ViewConfigList() {
            try {
                string viewConfigList = this._DocumentPolicy.ViewConfigList(
                this._DocumentConfig,
                SelectConfigId);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 設定タイプ"000100'01'"から設定を作成
        /// </summary>
        public void CreateConfig() {
            try {
                this._DocumentConfig = this._DocumentPolicy.CreateConfig(
                this._DocumentConfig,
                ConfigTypeEnum);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 指定したプロパティ内容を設定
        /// </summary>
        public void SetEditConfig() {
            try { 
                this._DocumentConfig = this._DocumentPolicy.SetEditConfig(
                this._DocumentConfig,
                SelectConfigId,
                PropertyEnum,
                EditValue);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 指定したプロパティ内容を取得
        /// </summary>
        public string? GetEditConfig() {
            try { 
                return this._DocumentPolicy.GetEditConfig(
                this._DocumentConfig,
                SelectConfigId,
                PropertyEnum);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        public void DeleteConfig() {
            try { 
                this._DocumentConfig = this._DocumentPolicy.DeleteConfig(
                this._DocumentConfig,
                SelectConfigId);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        public void MoveConfig() {
            try {
                this._DocumentConfig = this._DocumentPolicy.MoveConfig(
                this._DocumentConfig,
                SelectConfigId,
                MoveConfigId);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 設定IDにコピー
        /// </summary>
        public void CopyConfig() {
            try {
                this._DocumentConfig = this._DocumentPolicy.CopyConfig(
                this._DocumentConfig,
                SelectConfigId,
                CopyConfigId);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            try {
                return this._DocumentPolicy.GetAchievementCount(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            try {
                return this._DocumentPolicy.GetEvidenceCount(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            try {
                return this._DocumentPolicy.GetResultCount(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            try {
                return this._DocumentPolicy.GetSuccessCount(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            try {
                return this._DocumentPolicy.GetFailureCount(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public void GetFailureConfigList() {
            try {
                this._DocumentPolicy.GetFailureConfigList(this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        // # 読み込み書き出し
        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree() {
            try {
                this._DocumentPolicy.LoadJsonByTree(LoadFilePath);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree() {
            try {
                this._DocumentPolicy.SaveJsonByTree(SaveFilePath,this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public void LoadJsonByRelational() {
            try {
                this._DocumentConfig = this._DocumentPolicy.LoadJsonByRelational(LoadFilePath);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational() {
            try {
                this._DocumentPolicy.SaveJsonByRelational(SaveFilePath,this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownBySingle() {
            try {
                this._DocumentPolicy.LoadMarkdownBySingle(LoadFilePath);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownBySingle() {
            try {
                this._DocumentPolicy.SaveMarkdownBySingle(SaveFilePath,this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot() {
            try {
                this._DocumentPolicy.LoadMarkdownByRoot(LoadFilePath);
            }
            catch (AggregateException) { throw; }
        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot() {
            try {
                this._DocumentPolicy.SaveMarkdownByRoot(SaveFilePath,this._DocumentConfig);
            }
            catch (AggregateException) { throw; }
        }
    }
}
