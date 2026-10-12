using FactStatus.Domain.Internal.Rule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Value;
using FactStatus.Domain.Internal.Entity;

namespace FactStatus.Domain.Internal.Logic {
    public class FactStatusDomainPolicy {
        private readonly FactStatusDomainStrategy _factStatusStrategy;

        // Exception管理用リスト。いつか専用のクラスを用意したい
        private readonly List<Exception> _ExceptionList = new List<Exception>();
        private const string LOADFILEPATH_EXCEPTION = "LoadFilePathにファイルパスを設定してください。\nFactStatus.LoadFilePath = \"ファイルパス\"";
        private const string SAVEFILEPATH_EXCEPTION = "SaveFilePathにファイルパスを設定してください。\nFactStatus.SaveFilePath = \"ファイルパス\"";
        private const string AggregateTYPE_EXCEPTION = "AggregateTypeに\"IDの後ろ2桁\"の文字列を設定してください。\nFactStatus.AggregateType = \"IDの後ろ2桁\"";
        private const string AggregateID_EXCEPTION = "SelectAggregateIdに\"選択対象のID\"の文字列を設定してください。\nFactStatus.SelectAggregateId = \"選択対象のID\"";
        private const string PROPERTYNAME_EXCEPTION = "SelectPropertyNameに\"IDに含まれるプロパティ\"の文字列を設定してください。\nFactStatus.SelectPropertyName = \"IDに含まれるプロパティ\"";
        private const string EDITVALUE_EXCEPTION = "EditValueに\"変更内容\"の文字列を設定してください。\nFactStatus.EditValue = \"変更内容\"";
        private const string MOVEAggregateID_EXCEPTION = "MoveAggregateIdに\"移動先のID\"の文字列を設定してください。\nFactStatus.MoveAggregateId = \"移動先のID\"";
        private const string COPYAggregateIDLIST_EXCEPTION = "CopyAggregateIdListに\"コピー先のID\"の配列[文字列]を設定してください。\nFactStatus.CopyAggregateIdList = [\"コピー先のID\",\"複数コピーする場合のID\"]";

        /// <summary>
        /// IDに紐づくエンティティを取得
        /// </summary>
        public void GetSelectedEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string stringId) {
            
            // 引数チェック
            var idValue = IdValue.FromString(stringId);

            // 選択中のエンティティを取得
            ResetSelectedEntity(ref factStatusDomainAggregate, idValue);
        }

        /// <summary>
        /// 親IDに紐づくエンティティを取得
        /// </summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="stringId"></param>
        /// <returns></returns>
        public void GetParentEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate) {
            
            // 親IDが存在しない場合はエラーを投げる
            // Validation.NullOfString(factStatusDomainAggregate.ParentIdEntity.IdValue.GetId().ToString());
            // オリジナルの親IDを取得
            IdValue parentIdValue = factStatusDomainAggregate.ParentIdEntity.IdValue;

            // 親IDに紐づくエンティティを取得
            ResetSelectedEntity(ref factStatusDomainAggregate, parentIdValue);
        }

        /// <summary>
        /// IDタイプを指定してエンティティを作成
        /// </summary>
        public void CreateEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string pathName,
            string title,
            string idType,
            string stringId,
            string selectFlg) {

            // 引数チェック
            AddValue addValue = AddValue.FromString(
                pathName,
                title,
                idType,
                stringId);
            BoolValue selectBoolValue = BoolValue.FromString(selectFlg);

            // IDエンティティの作成
            if (selectBoolValue.IsTrue()) {
                // 作成したIDエンティティを選択状態にする
                _factStatusDomainAggregate.SelectedEntity = _factStatusStrategy.CreateEntity(addValue);
                // 作成したIDエンティティの親IDを取得する
                _factStatusDomainAggregate.ParentEntity = _factStatusStrategy.GetParentEntityByIdValue(_factStatusDomainAggregate.SelectedEntity.Id);
                // 作成したIDエンティティの子ID一覧を取得する
                _factStatusDomainAggregate.ChildrenEntityList = _factStatusStrategy.GetChildrenEntityListByIdValue(_factStatusDomainAggregate.SelectedEntity.Id);
            } else {
                // 作成したIDエンティティを選択状態にしない
                _factStatusStrategy.CreateEntity(addValue);
            }
        }

        /// <summary>
        /// 複数のIDエンティティを作成
        /// </summary>
        public void CreateEntityList(List<AddValue> addValueList) {
            _factStatusStrategy.CreateEntityList(addValueList);
        }

        /// <summary>
        /// IDエンティティを指定してエンティティを削除
        /// </summary>
        /// <param name="stringId"></param>
        public void DeleteEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string stringId,
            string onlyFlg) {
            
            // IdValueに変換
            IdValue idValue = IdValue.FromString(stringId);
            BoolValue onlyBoolValue = BoolValue.FromString(onlyFlg);
            
            // エンティティを削除
            _factStatusStrategy.DeleteEntity(idValue, onlyBoolValue);

            // 選択中のエンティティが削除された場合は、親のエンティティを返す
            if (factStatusDomainAggregate.SelectedEntity != null
            && factStatusDomainAggregate.SelectedEntity.Id.GetId() == idValue.GetId()) {
                ResetSelectedEntity(ref factStatusDomainAggregate, factStatusDomainAggregate.ParentEntity.Id);
            }
        }

        /// <summary>
        /// 複数のIDエンティティを指定してエンティティを削除
        /// </summary>
        public void DeleteEntityList(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            List<IdValue> idValueList,
            string onlyFlg) {
            
            // IdValueに変換
            BoolValue onlyBoolValue = BoolValue.FromString(onlyFlg);
            
            // エンティティを削除
            _factStatusStrategy.DeleteEntityList(idValueList, onlyBoolValue);

            // 選択中のエンティティが削除された場合は、親のエンティティを返す
            if (factStatusDomainAggregate.SelectedEntity != null
            && idValueList.Any(id => id.GetId() == factStatusDomainAggregate.SelectedEntity.Id.GetId())) {

                ResetSelectedEntity(ref factStatusDomainAggregate, factStatusDomainAggregate.ParentEntity.Id);
            }
        }

        /// <summary>
        /// エンティティ同士を接続
        /// </summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        public void LinkEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            var sourceIdValue = IdValue.FromString(sourceIdEntity);
            var destinationIdValue = IdValue.FromString(destinationIdEntity);

            return _factStatusStrategy.LinkEntity(factStatusDomainAggregate, sourceIdValue, destinationIdValue);
        }

        /// <summary>
        /// エンティティの接続を移動
        /// </summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="sourceIdEntity">新しい親ID</param>
        /// <param name="destinationIdEntity">移動する子ID</param>
        public void MoveEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            // エンティティIDを取得
            var newParentIdValue = IdValue.FromString(sourceIdEntity);
            var childIdValue = IdValue.FromString(destinationIdEntity);

            IdValue? oldParentIdValue = null;
            var childKey = factStatusDomainAggregate.ParentLinkDict.Keys
                .FirstOrDefault(key => key.GetId() == childIdValue.GetId());
            if (childKey != null && factStatusDomainAggregate.ParentLinkDict.TryGetValue(childKey, out var oldParent)) {
                oldParentIdValue = oldParent;
            }

            // 新しい階層へ接続
            FactStatusDomainAggregate linkFactStatusDomainAggregate = _factStatusStrategy.LinkEntity(
                factStatusDomainAggregate,
                newParentIdValue,
                childIdValue);

            // 元の階層接続を削除
            if (oldParentIdValue != null && oldParentIdValue.GetId() != newParentIdValue.GetId()) {
                return _factStatusStrategy.UnConnectEntity(
                    linkFactStatusDomainAggregate,
                    childIdValue,
                    oldParentIdValue);
            }

            return linkFactStatusDomainAggregate;
        }

        /// <summary>
        /// エンティティをにコピー
        /// </summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdEntity"></param>
        /// <returns></returns>
        public void CopyEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            string sourceIdEntity,
            string destinationIdEntity) {

            // 引数チェック
            Validation.NullOfString(sourceIdEntity);
            Validation.NullOfString(destinationIdEntity);

            // エンティティIDを取得
            var sourceIdValue = IdValue.FromString(sourceIdEntity);
            var destinationIdValue = IdValue.FromString(destinationIdEntity);

            // エンティティをコピー
            FactStatusDomainAggregate copyFactStatusDomainAggregate = _factStatusStrategy.CopyEntity(factStatusDomainAggregate, sourceIdValue, destinationIdValue);

            // コピーしたエンティティを返す
            return copyFactStatusDomainAggregate;
        }

        /// <summary>
        /// 複数のエンティティをグループ化
        /// </summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="sourceIdEntity"></param>
        /// <param name="destinationIdList"></param>
        /// <returns></returns>
        public void GroupEntity(
        ref FactStatusDomainAggregate factStatusDomainAggregate,
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


            return factStatusDomainAggregate;
        }

        /// <summary>
        /// 失敗内容数を取得
        /// </summary>
        public void GetFailureAggregateList(
            FactStatusDomainAggregate factStatusDomainAggregate) {

        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public FactStatusDomainAggregate LoadRelational(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusDomainAggregate loadfactStatusDomainAggregate = _factStatusStrategy.LoadRelational(loadFilePathValue);
            return loadfactStatusDomainAggregate;
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void SaveRelational(
            string saveFilePath,
            FactStatusDomainAggregate factStatusDomainAggregate) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveRelational(saveFilePathValue, factStatusDomainAggregate);
        }

        /// <summary>
        /// JSONファイルを読込
        /// </summary>
        /// <param name="loadFilePath"></param>
        /// <returns></returns>
        public FactStatusDomainAggregate LoadJson(
            string loadFilePath) {

            var loadFilePathValue = new PathValue(loadFilePath, PathTypeEnum.RootFile);
            FactStatusDomainAggregate loadfactStatusDomainAggregate = _factStatusStrategy.LoadJson(loadFilePathValue);
            return loadfactStatusDomainAggregate;
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson(
            string saveFilePath,
            FactStatusDomainAggregate factStatusDomainAggregate) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.RootFile);
            _factStatusStrategy.SaveJson(saveFilePathValue, factStatusDomainAggregate);
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
            FactStatusDomainAggregate factStatusDomainAggregate) {

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
            FactStatusDomainAggregate factStatusDomainAggregate) {

            var saveFilePathValue = new PathValue(saveFilePath, PathTypeEnum.Root);
        }

        /// <summary>
        /// 選択したエンティティにリセット
        /// </summary>
        private void ResetSelectedEntity(
            ref FactStatusDomainAggregate factStatusDomainAggregate,
            IdValue idValue) {
            
            // 選択中のエンティティを取得
            factStatusDomainAggregate.SelectedEntity = _factStatusStrategy.GetEntityByIdValue(idValue);
            // 親のエンティティを取得
            factStatusDomainAggregate.ParentEntity = _factStatusStrategy.GetParentEntityByIdValue(factStatusDomainAggregate.SelectedEntity.Id);
            // 子のエンティティ一覧を取得
            factStatusDomainAggregate.ChildrenEntityList = _factStatusStrategy.GetChildrenEntityListByIdValue(factStatusDomainAggregate.SelectedEntity.Id);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="factStatusStrategy"></param>
        public FactStatusDomainPolicy(FactStatusDomainStrategy factStatusStrategy) {
            _factStatusStrategy = factStatusStrategy;
        }
    }
}
