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

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public void ViewConfigList(
            FactStatusConfig documentConfig,
            string configId) {

        }

        /// <summary>
        /// タイプ指定で設定を作成
        /// </summary>
        public FactStatusConfig CreateConfig(
            FactStatusConfig documentConfig,
            string configType) {
            
            return documentConfig;
        }

        /// <summary>
        /// パス名の設定
        /// </summary>
        public FactStatusConfig SetPathName(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }
        
        /// <summary>
        /// パス名の取得
        /// </summary>
        public string GetPathName(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// タイトルの設定
        /// </summary>
        public FactStatusConfig SetTitle(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// タイトルの取得
        /// </summary>
        public string GetTitle(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 説明の設定
        /// </summary>
        public FactStatusConfig SetDescription(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 説明の取得
        /// </summary>
        public string GetDescription(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 成功、失敗の設定
        /// </summary>
        public FactStatusConfig SetSuccess(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 成功、失敗状態の取得
        /// </summary>
        public bool GetSuccess(
            FactStatusConfig documentConfig,
            string configId) {

            return true;
        }

        /// <summary>
        /// 例外の設定
        /// </summary>
        public FactStatusConfig SetException(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 例外の取得
        /// </summary>
        public string GetException(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// キーの設定
        /// </summary>
        public FactStatusConfig SetKey(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// キーの取得
        /// </summary>
        public string GetKey(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// データ型の設定
        /// </summary>
        public FactStatusConfig SetDataType(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// データ型の取得
        /// </summary>
        public string GetDataType(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        public FactStatusConfig SetValue(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        public string GetValue(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 日付の設定
        /// </summary>
        public FactStatusConfig SetDate(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 日付の取得
        /// </summary>
        public DateTime GetDate(
            FactStatusConfig documentConfig,
            string configId) {

            return DateTime.Now;
        }

        /// <summary>
        /// 確認者の設定
        /// </summary>
        public FactStatusConfig SetReviewer(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 確認者の取得
        /// </summary>
        public string GetReviewer(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// メッセージの設定
        /// </summary>
        public FactStatusConfig SetMessage(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// メッセージの取得
        /// </summary>
        public string GetMessage(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 体験の設定
        /// </summary>
        public FactStatusConfig SetExperience(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 体験の取得
        /// </summary>
        public string GetExperience(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 評価の設定
        /// </summary>
        public FactStatusConfig SetEvaluation(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 評価の取得
        /// </summary>
        public string GetEvaluation(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 仮説の設定
        /// </summary>
        public FactStatusConfig SetHypothesis(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 仮説の取得
        /// </summary>
        public string GetHypothesis(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 抽象目標の設定
        /// </summary>
        public FactStatusConfig SetAbstractionGoal(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 抽象目標の取得
        /// </summary>
        public string GetAbstractionGoal(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 具体目標の設定
        /// </summary>
        public FactStatusConfig SetExecutionGoal(
            FactStatusConfig documentConfig,
            string configId) {

            return documentConfig;
        }

        /// <summary>
        /// 具体目標の取得
        /// </summary>
        public string GetExecutionGoal(
            FactStatusConfig documentConfig,
            string configId) {

            return "";
        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        /// <param name="configId"></param>
        public FactStatusConfig DeleteConfig(
            FactStatusConfig documentConfig,
            string configId) {
            

            return documentConfig;
        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        /// <param name="configId"></param>
        public FactStatusConfig MoveConfig(
            FactStatusConfig documentConfig,
            string sourceId,
            string destinationId) {


            return documentConfig;
        }

        /// <summary>
        /// 設定IDにコピー
        /// </summary>
        /// <param name="documentConfig"></param>
        /// <param name="sourceId"></param>
        /// <param name="destinationIdList"></param>
        /// <returns></returns>
        public FactStatusConfig CopyConfig(
            FactStatusConfig documentConfig,
            string sourceId,
            List<string> destinationIdList) {


            return documentConfig;
        }

        /// <summary>
        /// 実装数を取得
        /// </summary>
        public int GetTodoCount(FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount(FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount(FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount(FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public int GetFailureCount(FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureConfigList(FactStatusConfig documentConfig) {

        }

        // # 読み込み書き出し
        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree(string loadFilePath) {

        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree(
            string saveFilePath,
            FactStatusConfig documentConfig) {

        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public FactStatusConfig LoadJsonByRelational(string loadFilePath) {
            FactStatusConfig loadDocumentConfig = this._DocumentStrategy.LoadJsonByRelational(loadFilePath);
            return loadDocumentConfig;
        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational(
            string saveFilePath,
            FactStatusConfig documentConfig) {

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
        public void SaveMarkdownBySingle(string saveFilePath,FactStatusConfig documentConfig) {

        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot(string loadFilePath) {

        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot(string saveFilePath,FactStatusConfig documentConfig) {

        }


        public FactStatusPolicy(FactStatusStrategy documentStrategy) {
            this._DocumentStrategy = documentStrategy;
        }
    }
}
