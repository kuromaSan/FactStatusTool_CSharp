using FactStatus.Domain.Model;
using FactStatus.Domain.Rule;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Logic {
    public class FactStatusPolicy(
    FactStatusStrategy factStatusStrategy) {
        private readonly FactStatusStrategy _factStatusStrategy = factStatusStrategy;

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

        public DocumentEntity GetDocumentEntity(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetDocumentEntity(factStatusConfig);
        }

        public SubjectEntity GetSubjectEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetSubjectEntity(factStatusConfig, idValue);
        }

        public AchievementEntity GetAchievementEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {
            
            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetAchievementEntity(factStatusConfig, idValue);
        }

        public EvidenceEntity GetEvidenceEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetEvidenceEntity(factStatusConfig, idValue);
        }

        public ResultEntity GetResultEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetResultEntity(factStatusConfig, idValue);
        }

        public RecordEntity GetRecordEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetRecordEntity(factStatusConfig, idValue);
        }

        public TodoEntity GetTodoEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetTodoEntity(factStatusConfig, idValue);
        }

        public SchemaEntity GetSchemaEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetSchemaEntity(factStatusConfig, idValue);
        }

        public GroupEntity GetGroupEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            var idValue = new IdValue(idEntity);
            return _factStatusStrategy.GetGroupEntity(factStatusConfig, idValue);
        }

        /// <summary>
        /// エンティティ一覧を取得
        /// </summary>
        public Dictionary<IdValue, SubjectEntity> GetSubjectEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetSubjectEntityDict(factStatusConfig);
        }
        
        
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetAchievementEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetEvidenceEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, ResultEntity> GetResultEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetResultEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetRecordEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetTodoEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetSchemaEntityDict(factStatusConfig);
        }

        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict(
            FactStatusConfig factStatusConfig) {

            return _factStatusStrategy.GetGroupEntityDict(factStatusConfig);
        }

        /// <summary>
        /// IDタイプを指定してエンティティを作成
        /// </summary>
        public FactStatusConfig CreateEntity(
            FactStatusConfig factStatusConfig,
            string idEntity,
            IdTypeEnum idTypeEnum) {

            // 引数チェック
            if (string.IsNullOrEmpty(idEntity)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (idTypeEnum.Equals(IdTypeEnum.None)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGTYPE_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }

            return factStatusConfig;
        }

        /// <summary>
        /// IDエンティティを指定してエンティティを削除
        /// </summary>
        /// <param name="idEntity"></param>
        public FactStatusConfig DeleteEntity(
            FactStatusConfig factStatusConfig,
            string idEntity) {

            // 引数チェック
            if (string.IsNullOrEmpty(idEntity)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }

            return factStatusConfig;
        }

        /// <summary>
        /// エンティティ同士を接続
        /// </summary>
        /// <param name="factStatusConfig"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        public FactStatusConfig LinkEntity(
            FactStatusConfig factStatusConfig,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            if (string.IsNullOrEmpty(sourceIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(destinationIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(MOVECONFIGID_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }

            return factStatusConfig;
        }

        /// <summary>
        /// エンティティをにコピー
        /// </summary>
        /// <param name="factStatusConfig"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        /// <returns></returns>
        public FactStatusConfig CopyEntity(
            FactStatusConfig factStatusConfig,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            if (string.IsNullOrEmpty(sourceIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(destinationIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(COPYCONFIGIDLIST_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }

            return factStatusConfig;
        }

        /// <summary>
        /// 複数のエンティティをグループ化
        /// </summary>
        /// <param name="factStatusConfig"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdList"></param>
        /// <returns></returns>
        public FactStatusConfig GroupEntity(
        FactStatusConfig factStatusConfig,
        string sourceIdEntity,
        string title,
        List<string> destinationIdList) {

            // 引数チェック
            if (string.IsNullOrEmpty(sourceIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(title)) {
                _ExceptionList.Add(new ArgumentNullException(CONFIGID_EXCEPTION));
            }
            if (destinationIdList.Count < 0) {
                _ExceptionList.Add(new ArgumentNullException(COPYCONFIGIDLIST_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }


            return factStatusConfig;
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount(
            FactStatusConfig factStatusConfig) {
            // 達成設定の長さを返す
            return factStatusConfig.AchievementEntityDict.Count;
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount(
            FactStatusConfig factStatusConfig) {
            // 証拠設定の長さを返す
            return factStatusConfig.EvidenceEntityDict.Count;
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount(
            FactStatusConfig factStatusConfig) {
            // 結果設定の長さを返す
            return factStatusConfig.ResultEntityDict.Count;
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount(
            FactStatusConfig factStatusConfig) {
            // 
            var resultConfigs = factStatusConfig.ResultEntityDict;
            return 0;
        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public int GetFailureCount(
            FactStatusConfig factStatusConfig) {
            
            var resultConfigs = factStatusConfig.ResultEntityDict;
            return 0;
        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureConfigList(
            FactStatusConfig factStatusConfig) {

        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public FactStatusConfig LoadRelational(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusConfig loadfactStatusConfig = _factStatusStrategy.LoadRelational(loadFilePathValue);
            return loadfactStatusConfig;
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void SaveRelational(
            string saveFilePath,
            FactStatusConfig factStatusConfig) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveRelational(saveFilePathValue,factStatusConfig);
        }
        
        /// <summary>
        /// JSONファイルを読込
        /// </summary>
        /// <param name="loadFilePath"></param>
        /// <returns></returns>
        public FactStatusConfig LoadJson(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusConfig loadfactStatusConfig = _factStatusStrategy.LoadJson(loadFilePathValue);
            return loadfactStatusConfig;
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson(
            string saveFilePath,
            FactStatusConfig factStatusConfig) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveJson(saveFilePathValue, factStatusConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownSelect(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownSelect(
            string saveFilePath,
            FactStatusConfig factStatusConfig) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.Root);

        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownRoot(
            string saveFilePath,
            FactStatusConfig factStatusConfig) {
            
            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.Root);
        }
    }
}
