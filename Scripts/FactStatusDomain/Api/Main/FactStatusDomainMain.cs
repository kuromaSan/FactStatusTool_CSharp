using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Internal.Rule;
using FactStatus.Domain.Internal.Value;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Desktop.Internal.Domain;
using FactStatus.Domain.Api.Contract;

namespace FactStatus.Domain.Api.Main {
    public class FactStatusDomainMain : IFactStatusDomainMain {
        
        private readonly FactStatusDomainPolicy _factStatusDomainPolicy;
        private FactStatusDomainAggregate _factStatusDomainAggregate;

        /// <summary>
        /// 指定したエンティティを更新
        /// </summary>
        public void UpdateEntity(
            EntityDetailDto entityDetailDto) {

            _factStatusDomainPolicy.UpdateEntity(
                ref _factStatusDomainAggregate,
                entityDetailDto);
        }
        
        /// <summary>
        /// 指定したIDからエンティティを取得
        /// </summary>
        /// <returns></returns>
        public EntityDetailDto GetSelectedEntity(
            string selectIdValue) {
            
            _factStatusDomainPolicy.GetSelectedEntity(
                ref _factStatusDomainAggregate,
                selectIdValue);
            return CreateEntityDetailDto(_factStatusDomainAggregate);
        }

        /// <summary>
        /// 選択中のエンティティを取得
        /// </summary>
        /// <returns></returns>
        public EntityDetailDto GetSelectedEntity() {
            return CreateEntityDetailDto(_factStatusDomainAggregate);
        }

        /// <summary>
        /// 選択中のエンティティの親エンティティを取得
        /// </summary>
        /// <returns></returns>
        public EntitySummaryDto? GetParentEntity() {
            _factStatusDomainPolicy.GetParentEntity(ref _factStatusDomainAggregate);
            return CreateEntitySummaryDto(_factStatusDomainAggregate.SelectedEntity);
        }

        /// <summary>
        /// 各エンティティ一覧を取得
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<EntitySummaryDto> GetAllEntityList() {
            return _factStatusDomainAggregate.AllEntityList
                .Select(CreateEntitySummaryDto)
                .Where(entity => entity is not null)
                .Cast<EntitySummaryDto>()
                .ToList();
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            return _factStatusDomainAggregate.AchievementCount;
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return _factStatusDomainAggregate.EvidenceCount;
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return _factStatusDomainAggregate.ResultCount;
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return _factStatusDomainAggregate.SuccessCount;
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return _factStatusDomainAggregate.FailureCount;
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public IReadOnlyList<FailureAggregateDto> GetFailureAggregateList() {
            return _factStatusDomainAggregate.FailureContentList
                .GroupBy(failureReason => failureReason)
                .Select(group => new FailureAggregateDto(group.Key, group.Count()))
                .OrderBy(failure => failure.FailureReason)
                .ToList();
        }

        /// <summary>
        /// 指定したIDタイプと文字列でエンティティを作成
        /// </summary>
        public void CreateEntity(
            string selectIdValue,
            string createIdType,
            string title,
            string pathName) {
            
            _factStatusDomainPolicy.CreateEntity(
                pathName,
                title,
                createIdType,
                selectIdValue);
        }

        /// <summary>
        /// 指定したIDタイプでエンティティを作成
        /// </summary>
        public void CreateEntity(
            string selectIdValue,
            AddValue addValue) {
            
            _factStatusDomainPolicy.CreateEntity(
                addValue.PathName,
                addValue.Title,
                addValue.CreateIdType,
                selectIdValue);
        }

        /// <summary>
        /// 指定したIDタイプでエンティティを一括作成
        /// </summary>
        public void CreateEntity(
            string selectIdValue,
            List<AddValue> addValueList) {
                
            _factStatusDomainPolicy.CreateEntityList(addValueList);
        }

        /// <summary>
        /// 指定したIDエンティティを削除
        /// </summary>
        public void DeleteEntity(
            string selectIdValue) {

            _factStatusDomainPolicy.DeleteEntity(
                ref _factStatusDomainAggregate,
                selectIdValue);
        }
        
        /// <summary>
        /// 指定したIDエンティティを削除
        /// </summary>
        public void DeleteEntity(
            IdValue selectIdValue) {

            _factStatusDomainPolicy.DeleteEntity(
                ref _factStatusDomainAggregate,
                selectIdValue);
        }

        /// <summary>
        /// 指定したIDエンティティ一覧を削除
        /// </summary>
        public void DeleteEntity(
            List<IdValue> selectIdValueList) {

            _factStatusDomainPolicy.DeleteEntityList(
                ref _factStatusDomainAggregate,
                selectIdValueList);
        }

        /// <summary>
        /// 指定したIDエンティティを移動
        /// </summary>
        public void MoveEntity(
            string targetIdValue,
            string selectIdValue) {

            _factStatusDomainPolicy.MoveEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// 指定したIDエンティティを移動
        /// </summary>
        public void MoveEntity(
            IdValue targetIdValue,
            IdValue selectIdValue) {

            _factStatusDomainPolicy.MoveEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// 指定したIDエンティティ一覧を移動
        /// </summary>
        public void MoveEntity(
            IdValue targetIdValue,
            List<IdValue> selectIdValueList) {

            _factStatusDomainPolicy.MoveEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }

        /// <summary>
        /// 指定したIDエンティティをコピー
        /// </summary>
        public void CopyEntity(
            string targetIdValue,
            string selectIdValue) {

            _factStatusDomainPolicy.CopyEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// 指定したIDエンティティをコピー
        /// </summary>
        public void CopyEntity(
            IdValue targetIdValue,
            IdValue selectIdValue) {

            _factStatusDomainPolicy.CopyEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }

        /// <summary>
        /// 指定したIDエンティティをコピー
        /// </summary>
        public void CopyEntity(
            IdValue targetIdValue,
            List<IdValue> selectIdValueList) {

            _factStatusDomainPolicy.CopyEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValueList);
        }

        /// <summary>
        /// エンティティにリンクを追加
        /// </summary>
        public void ConnectEntity(
            string targetIdValue,
            string selectIdValue) {

            _factStatusDomainPolicy.ConnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// エンティティにリンクを追加
        /// </summary>
        public void ConnectEntity(
            IdValue targetIdValue,
            IdValue selectIdValue) {

            _factStatusDomainPolicy.ConnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// エンティティ一覧にリンクを追加
        /// </summary>
        public void ConnectEntity(
            IdValue targetIdValue,
            Link<IdValue> selectIdValueList) {

            _factStatusDomainPolicy.ConnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValueList);
        }

        /// <summary>
        /// エンティティのリンクを削除
        /// </summary>
        /// <param name="targetIdValue"></param>
        /// <param name="selectIdValue"></param>
        public void DisconnectEntity(
            string targetIdValue,
            string selectIdValue) {

            _factStatusDomainPolicy.DisconnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// エンティティのリンクを削除
        /// </summary>
        /// <param name="targetIdValue"></param>
        /// <param name="selectIdValue"></param>
        public void DisconnectEntity(
            IdValue targetIdValue,
            IdValue selectIdValue) {

            _factStatusDomainPolicy.DisconnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValue);
        }
        
        /// <summary>
        /// エンティティ一覧のリンクを削除
        /// </summary>
        /// <param name="targetIdValue"></param>
        /// <param name="selectIdValue"></param>
        public void DisconnectEntity(
            IdValue targetIdValue,
            List<IdValue> selectIdValueList) {

            _factStatusDomainPolicy.DisconnectEntity(
                ref _factStatusDomainAggregate,
                targetIdValue,
                selectIdValueList);
        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public void Load(string loadFilePath) {
            _factStatusDomainPolicy.LoadRelational(
                ref _factStatusDomainAggregate,
                loadFilePath);
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void Save(string saveFilePath) {
            _factStatusDomainPolicy.SaveRelational(
                _factStatusDomainAggregate,
                saveFilePath);
        }
        
        /// <summary>
        /// JSONファイルの読込
        /// </summary>
        public void LoadJson(string loadFilePath) {
            _factStatusDomainAggregate = _factStatusDomainPolicy.LoadJson(loadFilePath);
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson(string saveFilePath) {
            _factStatusDomainPolicy.SaveJson(saveFilePath, _factStatusDomainAggregate);
        }

        /// <summary>
        /// XMLファイルの読込
        /// </summary>
        public void LoadXml(string loadFilePath) {
            _factStatusDomainAggregate = _factStatusDomainPolicy.LoadXml(loadFilePath);
        }

        /// <summary>
        /// XMLファイルで保存
        /// </summary>
        public void SaveXml(string saveFilePath) {
            _factStatusDomainPolicy.SaveXml(saveFilePath, _factStatusDomainAggregate);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownSelect(string loadFilePath) {
            _factStatusDomainPolicy.LoadMarkdownSelect(loadFilePath);
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownSelect(string saveFilePath) {
            _factStatusDomainPolicy.SaveMarkdownSelect(saveFilePath, _factStatusDomainAggregate);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot(string loadFilePath) {
            _factStatusDomainPolicy.LoadMarkdownRoot(loadFilePath);
        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownRoot(string saveFilePath, List<IdValue> selectIdValueList) {
            _factStatusDomainPolicy.SaveMarkdownRoot(saveFilePath, selectIdValueList, _factStatusDomainAggregate);
        }

        /// <summary>
        /// Domain 内部 Entity を、公開契約の一覧表示用 DTO に変換します。
        /// </summary>
        private static EntitySummaryDto? CreateEntitySummaryDto(IEntity? entity) {
            if (entity is null) {
                return null;
            }

            return new EntitySummaryDto(
                entity.Id.GetId(),
                entity.Id.Type.ToString(),
                entity.PathName.Path,
                entity.Title);
        }

        /// <summary>
        /// Domain 内部 Aggregate を、公開契約の詳細 DTO に変換します。
        /// </summary>
        private static EntityDetailDto CreateEntityDetailDto(
            FactStatusDomainAggregate aggregate) {

            var entity = CreateEntitySummaryDto(aggregate.SelectedEntity)
                ?? throw new InvalidOperationException("選択中のエンティティがありません。");

            var children = aggregate.ChildrenEntityList
                .Select(CreateEntitySummaryDto)
                .Where(child => child is not null)
                .Cast<EntitySummaryDto>()
                .ToList();

            return new EntityDetailDto(
                entity,
                CreateEntitySummaryDto(aggregate.ParentEntity),
                children);
        }

        /// <summary>
        /// コンストラクタ
        /// ＜/summary>
        /// <param name="factStatusDomainAggregate"></param>
        /// <param name="factStatusDomainPolicy"></param>
        public FactStatusDomainMain(
            FactStatusDomainAggregate factStatusDomainAggregate,
            FactStatusDomainPolicy factStatusDomainPolicy) {

            this._factStatusDomainPolicy = factStatusDomainPolicy;
            this._factStatusDomainAggregate = factStatusDomainAggregate;
        }
    }
}
