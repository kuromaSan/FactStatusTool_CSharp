using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Function {
    public class FactStatusPolicy {
        private readonly FactStatusStrategy _DocumentStrategy;

        public void IsGetConfig(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public void ViewConfigList(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 設定をIDから選択
        /// </summary>
        /// <param name="configId"></param>
        public void SelectConfig(FacutStatusConfig documentConfig, string configId) {

        }

        /// <summary>
        /// 実装設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            TodoConfig config) {


        }

        /// <summary>
        /// 検証設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            ValidateConfig config) {

        }

        /// <summary>
        /// 結果設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            ResultConfig config) {

        }

        /// <summary>
        /// 記録設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            RecordConfig config) {

        }

        /// <summary>
        /// 手順設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            ProcessConfig config) {

        }

        /// <summary>
        /// 構想設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(
            FacutStatusConfig documentConfig,
            SchemaConfig config) {

        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        /// <param name="configId"></param>
        public void DeleteConfig(
            FacutStatusConfig documentConfig,
            string configId) {

        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        /// <param name="configId"></param>
        public void MoveConfig(
            FacutStatusConfig documentConfig,
            string sourceId,
            string distId) {

        }

        /// <summary>
        /// 設定IDにコピー
        /// </summary>
        /// <param name="configId"></param>
        public void CopyConfig(
            FacutStatusConfig documentConfig,
            string sourceId,
            string distId) {

        }

        /// <summary>
        /// 実装数を取得
        /// </summary>
        public void GetTodoCount(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 検証数を取得 
        /// </summary>
        public void GetValidateCount(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public void GetResultCount(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public void GetSuccessCount(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 成功内容数を取得
        /// </summary>
        public void GetSuccessConfigList(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public void GetFailureCount(FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureConfigList(FacutStatusConfig documentConfig) {

        }

        // # 読み込み書き出し

        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree(string loadFilePath) {

        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public FacutStatusConfig LoadJsonByRelational(string loadFilePath) {
            FacutStatusConfig loadDocumentConfig = this._DocumentStrategy.LoadJsonByRelational(loadFilePath);
            return loadDocumentConfig;
        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree(string saveFilePath) {

        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational(string saveFilePath,FacutStatusConfig documentConfig) {
            this._DocumentStrategy.SaveJsonByRelational(saveFilePath,documentConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownBySingle(string loadFilePath) {

        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownBySingle(string saveFilePath,FacutStatusConfig documentConfig) {

        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot(string loadFilePath) {

        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot(string saveFilePath,FacutStatusConfig documentConfig) {

        }


        public FactStatusPolicy(FactStatusStrategy documentStrategy) {
            this._DocumentStrategy = documentStrategy;
        }
    }
}
