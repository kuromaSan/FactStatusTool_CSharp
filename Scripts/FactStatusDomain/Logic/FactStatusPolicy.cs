using FactStatus.Domain.Model;
using FactStatus.Domain.Rule;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;
using Newtonsoft.Json.Linq;
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
        private const string AggregateTYPE_EXCEPTION = "AggregateTypeに\"IDの後ろ2桁\"の文字列を設定してください。\nFactStatus.AggregateType = \"IDの後ろ2桁\"";
        private const string AggregateID_EXCEPTION = "SelectAggregateIdに\"選択対象のID\"の文字列を設定してください。\nFactStatus.SelectAggregateId = \"選択対象のID\"";
        private const string PROPERTYNAME_EXCEPTION = "SelectPropertyNameに\"IDに含まれるプロパティ\"の文字列を設定してください。\nFactStatus.SelectPropertyName = \"IDに含まれるプロパティ\"";
        private const string EDITVALUE_EXCEPTION = "EditValueに\"変更内容\"の文字列を設定してください。\nFactStatus.EditValue = \"変更内容\"";
        private const string MOVEAggregateID_EXCEPTION = "MoveAggregateIdに\"移動先のID\"の文字列を設定してください。\nFactStatus.MoveAggregateId = \"移動先のID\"";
        private const string COPYAggregateIDLIST_EXCEPTION = "CopyAggregateIdListに\"コピー先のID\"の配列[文字列]を設定してください。\nFactStatus.CopyAggregateIdList = [\"コピー先のID\",\"複数コピーする場合のID\"]";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="stringId"></param>
        /// <returns></returns>
        public IEntity GetParentIdEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            // 引数チェック
            var idValue = IdValue.FromString(stringId);

            // 親IDが存在しない場合はnullを返す
            Validation.DictionaryEntityFound(factStatusAggregate.ParentLinkDict, idValue);
            IdValue parentIdValue = factStatusAggregate.ParentLinkDict[idValue];
            // 親IDが存在しない場合はnullを返す
            return _factStatusStrategy.GetIdEntityByIdValue(factStatusAggregate,parentIdValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="stringId"></param>
        /// <returns></returns>
        public List<IEntity> GetChildrenIdEntityList(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            // 引数チェック
            var idValue = IdValue.FromString(stringId);

            // 子IDが存在しない場合は空リストを返す
            Validation.DictionaryEntityFound(factStatusAggregate.ChildrenLinkDict, idValue);
            List<IdValue> childrenIdValueList = factStatusAggregate.ChildrenLinkDict[idValue];
            if (childrenIdValueList == null) {
                return new List<IEntity>();
            }
            
            // 子IDが存在しない場合は空リストを返す
            return _factStatusStrategy.GetEntitiesByIdValues(factStatusAggregate, childrenIdValueList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <returns></returns>
        public DocumentEntity GetDocumentEntity(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetDocumentEntity(factStatusAggregate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="stringId"></param>
        /// <returns></returns>
        public SubjectEntity GetSubjectEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue= IdValue.FromString(stringId);
            return _factStatusStrategy.GetSubjectEntity(factStatusAggregate, idValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="stringId"></param>
        /// <returns></returns>
        public AchievementEntity GetAchievementEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetAchievementEntity(factStatusAggregate, idValue);
        }

        public EvidenceEntity GetEvidenceEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetEvidenceEntity(factStatusAggregate, idValue);
        }

        public ResultEntity GetResultEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetResultEntity(factStatusAggregate, idValue);
        }

        public RecordEntity GetRecordEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetRecordEntity(factStatusAggregate, idValue);
        }

        public TodoEntity GetTodoEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetTodoEntity(factStatusAggregate, idValue);
        }

        public SchemaEntity GetSchemaEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetSchemaEntity(factStatusAggregate, idValue);
        }

        public GroupEntity GetGroupEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            var idValue = IdValue.FromString(stringId);
            return _factStatusStrategy.GetGroupEntity(factStatusAggregate, idValue);
        }

        /// <summary>
        /// エンティティ一覧を取得
        /// </summary>
        public Dictionary<IdValue, SubjectEntity> GetSubjectEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetSubjectEntityDict(factStatusAggregate);
        }
        
        
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetAchievementEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetEvidenceEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, ResultEntity> GetResultEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetResultEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetRecordEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetTodoEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetSchemaEntityDict(factStatusAggregate);
        }

        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict(
            FactStatusAggregate factStatusAggregate) {

            return _factStatusStrategy.GetGroupEntityDict(factStatusAggregate);
        }

        /// <summary>
        /// IDタイプを指定してエンティティを作成
        /// </summary>
        public FactStatusAggregate CreateEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId,
            string idType,
            string title,
            string pathName) {

            // 引数チェック
            Validation.NullOfString(stringId);
            Validation.NullOfString(idType);
            Validation.NullOfString(title);
            Validation.NullOfString(pathName);
            Validation.StringToEnum<IdTypeEnum>(idType);

            var idValue = IdValue.FromString(stringId);
            var pathValue = PathValue.PathIsDirectory(pathName);

            IdTypeEnum idTypeEnum = Enum.Parse<IdTypeEnum>(idType);

            IdValue newIdValue = _factStatusStrategy.CreateIdValue(factStatusAggregate,idTypeEnum);

            // IDエンティティの作成
            FactStatusAggregate addFactStatusAggregate = _factStatusStrategy.CreateEntity(factStatusAggregate, newIdValue, title, pathValue);

            // IDエンティティの接続
            FactStatusAggregate linkFactStatusAggregate = _factStatusStrategy.LinkEntity(addFactStatusAggregate, idValue, newIdValue);

            return linkFactStatusAggregate;
        }

        /// <summary>
        /// IDエンティティを指定してエンティティを削除
        /// </summary>
        /// <param name="stringId"></param>
        public FactStatusAggregate DeleteEntity(
            FactStatusAggregate factStatusAggregate,
            string stringId) {

            // 引数チェック
            Validation.NullOfString(stringId);

            var idValue = IdValue.FromString(stringId);
            FactStatusAggregate deleteFactStatusAggregate = _factStatusStrategy.DeleteEntity(factStatusAggregate, idValue);

            return deleteFactStatusAggregate;
        }

        /// <summary>
        /// エンティティ同士を接続
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        public FactStatusAggregate LinkEntity(
            FactStatusAggregate factStatusAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            var sourceIdValue = IdValue.FromString(sourceIdEntity);
            var destinationIdValue = IdValue.FromString(destinationIdEntity);

            return _factStatusStrategy.LinkEntity(factStatusAggregate, sourceIdValue, destinationIdValue);
        }

        /// <summary>
        /// エンティティの接続を移動
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="sourceIdEntity">新しい親ID</param>
        /// <param name="destinationIdEntity">移動する子ID</param>
        public FactStatusAggregate MoveEntity(
            FactStatusAggregate factStatusAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            // エンティティIDを取得
            var newParentIdValue = IdValue.FromString(sourceIdEntity);
            var childIdValue = IdValue.FromString(destinationIdEntity);

            IdValue? oldParentIdValue = null;
            var childKey = factStatusAggregate.ParentLinkDict.Keys
                .FirstOrDefault(key => key.GetId() == childIdValue.GetId());
            if (childKey != null && factStatusAggregate.ParentLinkDict.TryGetValue(childKey, out var oldParent)) {
                oldParentIdValue = oldParent;
            }

            // 新しい階層へ接続
            FactStatusAggregate linkFactStatusAggregate = _factStatusStrategy.LinkEntity(
                factStatusAggregate,
                newParentIdValue,
                childIdValue);

            // 元の階層接続を削除
            if (oldParentIdValue != null && oldParentIdValue.GetId() != newParentIdValue.GetId()) {
                return _factStatusStrategy.UnConnectEntity(
                    linkFactStatusAggregate,
                    childIdValue,
                    oldParentIdValue);
            }

            return linkFactStatusAggregate;
        }

        /// <summary>
        /// エンティティをにコピー
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        /// <returns></returns>
        public FactStatusAggregate CopyEntity(
            FactStatusAggregate factStatusAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            // エンティティIDを取得
            var sourceIdValue = IdValue.FromString(sourceIdEntity);
            var destinationIdValue = IdValue.FromString(destinationIdEntity);

            // エンティティをコピー
            FactStatusAggregate copyFactStatusAggregate = _factStatusStrategy.CopyEntity(factStatusAggregate, sourceIdValue, destinationIdValue);

            // コピーしたエンティティを返す
            return copyFactStatusAggregate;
        }

        /// <summary>
        /// 複数のエンティティをグループ化
        /// </summary>
        /// <param name="factStatusAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdList"></param>
        /// <returns></returns>
        public FactStatusAggregate GroupEntity(
        FactStatusAggregate factStatusAggregate,
        string sourceIdEntity,
        string title,
        List<string> destinationIdList) {

            // 引数チェック
            if (string.IsNullOrEmpty(sourceIdEntity)) {
                _ExceptionList.Add(new ArgumentNullException(AggregateID_EXCEPTION));
            }
            if (string.IsNullOrEmpty(title)) {
                _ExceptionList.Add(new ArgumentNullException(AggregateID_EXCEPTION));
            }
            if (destinationIdList.Count < 0) {
                _ExceptionList.Add(new ArgumentNullException(COPYAggregateIDLIST_EXCEPTION));
            }
            if (_ExceptionList.Count > 0) {
                throw new AggregateException(_ExceptionList);
            }


            return factStatusAggregate;
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount(
            FactStatusAggregate factStatusAggregate) {
            // 達成設定の長さを返す
            return factStatusAggregate.AchievementEntityDict.Count;
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount(
            FactStatusAggregate factStatusAggregate) {
            // 証拠設定の長さを返す
            return factStatusAggregate.EvidenceEntityDict.Count;
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount(
            FactStatusAggregate factStatusAggregate) {
            // 結果設定の長さを返す
            return factStatusAggregate.ResultEntityDict.Count;
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount(
            FactStatusAggregate factStatusAggregate) {
            // 
            var resultAggregates = factStatusAggregate.ResultEntityDict;
            return 0;
        }

        /// <summary>
        /// 失敗数を取得
        /// </summary>
        public int GetFailureCount(
            FactStatusAggregate factStatusAggregate) {
            
            var resultAggregates = factStatusAggregate.ResultEntityDict;
            return 0;
        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureAggregateList(
            FactStatusAggregate factStatusAggregate) {

        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public FactStatusAggregate LoadRelational(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusAggregate loadfactStatusAggregate = _factStatusStrategy.LoadRelational(loadFilePathValue);
            return loadfactStatusAggregate;
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void SaveRelational(
            string saveFilePath,
            FactStatusAggregate factStatusAggregate) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveRelational(saveFilePathValue,factStatusAggregate);
        }
        
        /// <summary>
        /// JSONファイルを読込
        /// </summary>
        /// <param name="loadFilePath"></param>
        /// <returns></returns>
        public FactStatusAggregate LoadJson(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusAggregate loadfactStatusAggregate = _factStatusStrategy.LoadJson(loadFilePathValue);
            return loadfactStatusAggregate;
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson(
            string saveFilePath,
            FactStatusAggregate factStatusAggregate) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveJson(saveFilePathValue, factStatusAggregate);
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
            FactStatusAggregate factStatusAggregate) {

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
            FactStatusAggregate factStatusAggregate) {
            
            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.Root);
        }
    }
}
