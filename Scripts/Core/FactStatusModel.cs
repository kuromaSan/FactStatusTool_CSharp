using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Core {
    public class FactStatusModel {
        private FactStatusConfig _DocumentConfig;
        private FactStatusPolicy _DocumentPolicy;

        /// <summary>
        /// 読み込むファイルパスを設定 
        /// </summary>
        public string LoadFilePath { get; set; }

        /// <summary>
        /// 保存するファイルパスを設定
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// 設定タイプ"000100'01'"を設定
        /// </summary>
        public string ConfigType { get; set; }

        /// <summary>
        /// 選択している設定IDを設定
        /// </summary>
        public string SelectConfigId { get; set; }

        /// <summary>
        /// 移動対象の設定IDを設定
        /// </summary>
        public string MoveConfigId { get; set; }
        
        /// <summary>
        /// コピー対象の設定IDたちを設定
        /// </summary>
        public List<string> CopyConfigIdList { get; set; }

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public void ViewConfigList() {
            this._DocumentPolicy.ViewConfigList(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 設定タイプ"000100'01'"から設定を作成
        /// </summary>
        public void CreateConfig() {
            this._DocumentConfig = this._DocumentPolicy.CreateConfig(
                this._DocumentConfig,
                ConfigType);
        }

        /// <summary>
        /// パス名の設定
        /// </summary>
        public void SetPathName() {
            this._DocumentConfig = this._DocumentPolicy.SetPathName(
                this._DocumentConfig,
                SelectConfigId);
        }
        
        /// <summary>
        /// パス名の取得
        /// </summary>
        public string GetPathName() {
            return this._DocumentPolicy.GetPathName(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// タイトルの設定
        /// </summary>
        public void SetTitle() {
            this._DocumentConfig = this._DocumentPolicy.SetTitle(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// タイトルの取得
        /// </summary>
        public string GetTitle() {
            return this._DocumentPolicy.GetTitle(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 説明の設定
        /// </summary>
        public void SetDescription() {
            this._DocumentConfig = this._DocumentPolicy.SetDescription(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 説明の取得
        /// </summary>
        public string GetDescription() {
            return this._DocumentPolicy.GetDescription(
                this._DocumentConfig,
                SelectConfigId);
        }
        
        /// <summary>
        /// 成功、失敗状態の設定
        /// </summary>
        public void SetSuccess() {
            this._DocumentConfig = this._DocumentPolicy.SetSuccess(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 成功、失敗状態の取得
        /// </summary>
        public bool GetSuccess() {
            return this._DocumentPolicy.GetSuccess(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 例外の設定
        /// </summary>
        public void SetException() {
            this._DocumentConfig = this._DocumentPolicy.SetException(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 例外の取得
        /// </summary>
        public string GetException() {
            return this._DocumentPolicy.GetException(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// キーの設定
        /// </summary>
        public void SetKey() {
            this._DocumentConfig = this._DocumentPolicy.SetKey(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// キーの取得
        /// </summary>
        public string GetKey() {
            return this._DocumentPolicy.GetKey(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// データ型の設定
        /// </summary>
        public void SetDataType() {
            this._DocumentConfig = this._DocumentPolicy.SetDataType(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// データ型の取得
        /// </summary>
        public string GetDataType() {
            return this._DocumentPolicy.GetDataType(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        public void SetValue() {
            this._DocumentConfig = this._DocumentPolicy.SetValue(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        public string GetValue() {
            return this._DocumentPolicy.GetValue(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 日付の設定
        /// </summary>
        public void SetDate() {
            this._DocumentConfig = this._DocumentPolicy.SetDate(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 日付の取得
        /// </summary>
        public DateTime GetDate() {
            return this._DocumentPolicy.GetDate(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 確認者の設定
        /// </summary>
        public void SetReviewer() {
            this._DocumentConfig = this._DocumentPolicy.SetReviewer(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 確認者の取得
        /// </summary>
        public string GetReviewer() {
            return this._DocumentPolicy.GetReviewer(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// メッセージの設定
        /// </summary>
        public void SetMessage() {
            this._DocumentConfig = this._DocumentPolicy.SetMessage(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// メッセージの取得
        /// </summary>
        public string GetMessage() {
            return this._DocumentPolicy.GetMessage(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 体験の設定
        /// </summary>
        public void SetExperience() {
            this._DocumentConfig = this._DocumentPolicy.SetExperience(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 体験の取得
        /// </summary>
        public string GetExperience() {
            return this._DocumentPolicy.GetExperience(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 評価の設定
        /// </summary>
        public void SetEvaluation() {
            this._DocumentConfig = this._DocumentPolicy.SetEvaluation(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 評価の取得
        /// </summary>
        public string GetEvaluation() {
            return this._DocumentPolicy.GetEvaluation(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 仮説の設定
        /// </summary>
        public void SetHypothesis() {
            this._DocumentConfig = this._DocumentPolicy.SetHypothesis(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 仮説の取得
        /// </summary>
        public string GetHypothesis() {
            return this._DocumentPolicy.GetHypothesis(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 抽象目標の設定
        /// </summary>
        public void SetAbstractionGoal() {
            this._DocumentConfig = this._DocumentPolicy.SetAbstractionGoal(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 抽象目標の取得
        /// </summary>
        public string GetAbstractionGoal() {
            return this._DocumentPolicy.GetAbstractionGoal(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 具体目標の設定
        /// </summary>
        public void SetExecutionGoal() {
            this._DocumentConfig = this._DocumentPolicy.SetExecutionGoal(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 具体目標の取得
        /// </summary>
        public string GetExecutionGoal() {
            return this._DocumentPolicy.GetExecutionGoal(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        public void DeleteConfig() {
            this._DocumentConfig = this._DocumentPolicy.DeleteConfig(
                this._DocumentConfig,
                SelectConfigId);
        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        public void MoveConfig() {
            this._DocumentConfig = this._DocumentPolicy.MoveConfig(
                this._DocumentConfig,
                SelectConfigId,
                MoveConfigId);
        }

        /// <summary>
        /// 設定IDにコピー
        /// </summary>
        public void CopyConfig() {
            this._DocumentConfig = this._DocumentPolicy.CopyConfig(
                this._DocumentConfig,
                SelectConfigId,
                CopyConfigIdList);
        }

        /// <summary>
        /// 実装数を取得
        /// </summary>
        public int GetTodoCount() {
            return this._DocumentPolicy.GetTodoCount(this._DocumentConfig);
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return this._DocumentPolicy.GetEvidenceCount(this._DocumentConfig);
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return this._DocumentPolicy.GetResultCount(this._DocumentConfig);
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return this._DocumentPolicy.GetSuccessCount(this._DocumentConfig);
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return this._DocumentPolicy.GetFailureCount(this._DocumentConfig);
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public void GetFailureConfigList() {
            this._DocumentPolicy.GetFailureConfigList(this._DocumentConfig);
        }

        // # 読み込み書き出し
        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree() {
            this._DocumentPolicy.LoadJsonByTree(LoadFilePath);
        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree() {
            this._DocumentPolicy.SaveJsonByTree(SaveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public void LoadJsonByRelational() {
            this._DocumentConfig = this._DocumentPolicy.LoadJsonByRelational(LoadFilePath);
        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational() {
            this._DocumentPolicy.SaveJsonByRelational(SaveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownBySingle() {
            this._DocumentPolicy.LoadMarkdownBySingle(LoadFilePath);
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownBySingle() {
            this._DocumentPolicy.SaveMarkdownBySingle(SaveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot() {
            this._DocumentPolicy.LoadMarkdownByRoot(LoadFilePath);
        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot() {
            this._DocumentPolicy.SaveMarkdownByRoot(SaveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusModel(FactStatusConfig documentConfig, FactStatusPolicy documentPolicy) {
            this._DocumentConfig = documentConfig;
            this._DocumentPolicy = documentPolicy;
        }
    }
}
