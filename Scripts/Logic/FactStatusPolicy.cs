using FactStatusTool.Scripts.Setup;
using FactStatusTool.Scripts.Value;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Logic {
    public class FactStatusPolicy(
    FactStatusStrategy factStatusStrategy) {
        private readonly FactStatusStrategy _FactStatusStrategy = factStatusStrategy;

        // Exception管理用リスト。いつか専用のクラスを用意したい
        private readonly List<Exception> _ExceptionList = [];
        private const string LOADFILEPATH_EXCEPTION = "LoadFilePathにファイルパスを設定してください。\nFactStatus.LoadFilePath = \"ファイルパス\"";
        private const string SAVEFILEPATH_EXCEPTION = "SaveFilePathにファイルパスを設定してください。\nFactStatus.SaveFilePath = \"ファイルパス\"";
        private const string CONFIGTYPE_EXCEPTION = "ConfigTypeに\"IDの後ろ2桁\"の文字列を設定してください。\nFactStatus.ConfigType = \"IDの後ろ2桁\"";
        private const string CONFIGID_EXCEPTION = "SelectConfigIdに\"選択対象のID\"の文字列を設定してください。\nFactStatus.SelectConfigId = \"選択対象のID\"";
        private const string PROPERTYNAME_EXCEPTION = "SelectPropertyNameに\"IDに含まれるプロパティ\"の文字列を設定してください。\nFactStatus.SelectPropertyName = \"IDに含まれるプロパティ\"";
        private const string EDITVALUE_EXCEPTION = "EditValueに\"変更内容\"の文字列を設定してください。\nFactStatus.EditValue = \"変更内容\"";
        private const string MOVECONFIGID_EXCEPTION = "MoveConfigIdに\"移動先のID\"の文字列を設定してください。\nFactStatus.MoveConfigId = \"移動先のID\"";
        private const string COPYCONFIGIDLIST_EXCEPTION = "CopyConfigIdListに\"コピー先のID\"の配列[文字列]を設定してください。\nFactStatus.CopyConfigIdList = [\"コピー先のID\",\"複数コピーする場合のID\"]";

        /// <summary>
        /// 設定一覧を表示
        /// </summary>
        public string ViewConfigList(
        FactStatusConfig documentConfig,
        string? configId) {
            // 引数チェック
            if (string.IsNullOrEmpty( configId )) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }
            return configId!;
        }

        /// <summary>
        /// タイプ指定で設定を作成
        /// </summary>
        public FactStatusConfig CreateConfig(
        FactStatusConfig documentConfig,
        ConfigTypeEnum? configTypeEnum) {
            // 引数チェック
            if (configTypeEnum == null) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGTYPE_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            return documentConfig;
        }

        /// <summary>
        /// 指定したプロパティ内容を設定
        /// </summary>
        /// <param name="documentConfig"></param>
        /// <param name="configId"></param>
        /// <param name="propertyEnum"></param>
        /// <param name="editValue"></param>
        /// <returns></returns>
        public FactStatusConfig SetEditConfig(
        FactStatusConfig documentConfig,
        string? configId,
        PropertyEnum? propertyEnum,
        string? editValue) {
            // 引数チェック
            if (string.IsNullOrEmpty( configId )) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (propertyEnum == null) {
                this._ExceptionList.Add(new ArgumentNullException(PROPERTYNAME_EXCEPTION));
            }
            if (string.IsNullOrEmpty( editValue )) {
                this._ExceptionList.Add(new ArgumentNullException(EDITVALUE_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            return documentConfig;
        }

        /// <summary>
        /// 指定したプロパティ内容を取得
        /// </summary>
        /// <param name="documentConfig"></param>
        /// <param name="configId"></param>
        /// <param name="propertyEnum"></param>
        /// <returns></returns>
        public string GetEditConfig(
        FactStatusConfig documentConfig,
        string? configId,
        PropertyEnum? propertyEnum) {
            // 引数チェック
            if (string.IsNullOrEmpty( configId )) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (propertyEnum == null) {
                this._ExceptionList.Add(new ArgumentNullException(PROPERTYNAME_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            return "";
        }

        /// <summary>
        /// 設定IDから削除
        /// </summary>
        /// <param name="configId"></param>
        public FactStatusConfig DeleteConfig(
        FactStatusConfig documentConfig,
        string? configId) {
            // 引数チェック
            if (string.IsNullOrEmpty( configId )) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            return documentConfig;
        }

        /// <summary>
        /// 設定IDに移動
        /// </summary>
        /// <param name="configId"></param>
        public FactStatusConfig MoveConfig(
        FactStatusConfig documentConfig,
        string? sourceId,
        string? destinationId) {
            // 引数チェック
            if (string.IsNullOrEmpty(sourceId)) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(destinationId)) {
                this._ExceptionList.Add(new ArgumentNullException(MOVECONFIGID_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

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
        string? sourceId,
        string? destinationId) {
            // 引数チェック
            if (string.IsNullOrEmpty(sourceId)) {
                this._ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(destinationId)) {
                this._ExceptionList.Add(new ArgumentNullException(COPYCONFIGIDLIST_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }


            return documentConfig;
        }

        /// <summary>
        /// 実装数を取得
        /// </summary>
        public int GetAchievementCount(
        FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount(
        FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount(
        FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount(
        FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public int GetFailureCount(
        FactStatusConfig documentConfig) {

            return 0;
        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureConfigList(
        FactStatusConfig documentConfig) {

        }

        // # 読み込み書き出し
        /// <summary>
        /// 階層型Jsonの読み込み
        /// </summary>
        public void LoadJsonByTree(
        string? loadFilePath) {
            // 引数チェック
            if (string.IsNullOrEmpty( loadFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(LOADFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

        }

        /// <summary>
        /// 階層型Jsonで保存
        /// </summary>
        public void SaveJsonByTree(
        string? saveFilePath,
        FactStatusConfig documentConfig) {
            // 引数チェック
            if (string.IsNullOrEmpty( saveFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(SAVEFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

        }

        /// <summary>
        /// データベース型jsonの読み込み
        /// </summary>
        public FactStatusConfig LoadJsonByRelational(
        string? loadFilePath) {
            // 引数チェック
            if (string.IsNullOrEmpty( loadFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(LOADFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            FactStatusConfig loadDocumentConfig = this._FactStatusStrategy.LoadJsonByRelational(loadFilePath!);
            return loadDocumentConfig;
        }

        /// <summary>
        /// データベース型Jsonで保存
        /// </summary>
        public void SaveJsonByRelational(
        string? saveFilePath,
        FactStatusConfig documentConfig) {
            // 引数チェック
            if (string.IsNullOrEmpty( saveFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(SAVEFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

            this._FactStatusStrategy.SaveJsonByRelational(saveFilePath!,documentConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownBySingle(
        string? loadFilePath) {
            // 引数チェック
            if (string.IsNullOrEmpty( loadFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(LOADFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownBySingle(
        string? saveFilePath,
        FactStatusConfig documentConfig) {
            // 引数チェック
            if (string.IsNullOrEmpty( saveFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(SAVEFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownByRoot(
        string? loadFilePath) {
            if (string.IsNullOrEmpty( loadFilePath )) {
                this._ExceptionList.Add(new ArgumentNullException(LOADFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }

        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownByRoot(
        string? saveFilePath,
        FactStatusConfig documentConfig) {
            if (string.IsNullOrEmpty(saveFilePath)) {
                this._ExceptionList.Add(new ArgumentNullException(SAVEFILEPATH_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(this._ExceptionList);
            }
        }
    }
}
