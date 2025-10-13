using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Core {
    public class FactStatusModel {
        private string _loadFilePath = string.Empty;
        private string _saveFilePath = string.Empty;
        private FacutStatusConfig _DocumentConfig;
        private FactStatusPolicy _DocumentPolicy;

        /// <summary>
        /// 現在の設定を表示
        /// </summary>
        public void IsGetConfig() {
            
        }

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public void ViewConfigList() {

        }

        /// <summary>
        /// 設定タイプ"000100'01'"を設定
        /// </summary>
        /// <param name="configType"></param>
        public void SetConfigType(string configType) {

        }

        /// <summary>
        /// 設定タイプ"000100'01'"を取得
        /// </summary>
        public void GetConfigType() {

        }

        /// <summary>
        /// 設定をIDから選択
        /// </summary>
        /// <param name="configId"></param>
        public void SelectConfig(string configId) {

        }

        /// <summary>
        /// 実装設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(TodoConfig config) {

        }

        /// <summary>
        /// 検証設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(ValidateConfig config) {

        }

        /// <summary>
        /// 結果設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(ResultConfig resultConfig, ArgumentConfig argumentConfig) {

        }

        /// <summary>
        /// 記録設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(RecordConfig recordConfig) {

        }

        /// <summary>
        /// 手順設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(ProcessConfig config, StepConfig stepConfig) {

        }

        /// <summary>
        /// 構想設定の追加
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(SchemaConfig config) {

        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        /// <param name="configId"></param>
        public void DeleteConfig(string configId) {

        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        /// <param name="configId"></param>
        public void MoveConfig(string configId) {

        }

        /// <summary>
        /// 設定IDにコピー
        /// </summary>
        /// <param name="configId"></param>
        public void CopyConfig(string configId) {

        }

        /// <summary>
        /// 実装数を取得
        /// </summary>
        public void GetTodoCount() {

        }

        /// <summary>
        /// 検証数を取得 
        /// </summary>
        public void GetValidateCount() {

        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public void GetResultCount() {

        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public void GetSuccessCount() {

        }

        /// <summary>
        /// 成功内容数を取得
        /// </summary>
        public void GetSuccessConfigList() {

        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public void GetFailureCount() {

        }
        
        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureConfigList() {

        }

        // # 読み込み書き出し

        /// <summary>
        /// ファイルパスを設定 
        /// </summary>
        /// <param name="filePath"></param>
        public void SetLoadFilePath(string loadFilePath) {
            this._loadFilePath = loadFilePath;
        }

        /// <summary>
        /// ファイル名を設定
        /// </summary>
        /// <param name="fileName"></param>
        public void SetSaveFilePath(string saveFilePath) {
            this._saveFilePath = saveFilePath;
        }

        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree() {
            this._DocumentPolicy.LoadJsonByTree(this._loadFilePath);
        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public void LoadJsonByRelational() {
            this._DocumentConfig = this._DocumentPolicy.LoadJsonByRelational(this._loadFilePath);
        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree() {
            this._DocumentPolicy.SaveJsonByTree(this._saveFilePath);
        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational() {
            this._DocumentPolicy.SaveJsonByRelational(this._saveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownBySingle() {
            this._DocumentPolicy.LoadMarkdownBySingle(this._loadFilePath);
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownBySingle() {
            this._DocumentPolicy.SaveMarkdownBySingle(this._saveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot() {
            this._DocumentPolicy.LoadMarkdownByRoot(this._loadFilePath);
        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot() {
            this._DocumentPolicy.SaveMarkdownByRoot(this._saveFilePath,this._DocumentConfig);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FactStatusModel(FacutStatusConfig documentConfig, FactStatusPolicy documentPolicy) {
            this._DocumentConfig = documentConfig;
            this._DocumentPolicy = documentPolicy;
        }
    }
}
