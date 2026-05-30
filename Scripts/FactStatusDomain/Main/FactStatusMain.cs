using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Logic;
using FactStatus.Domain.Model;
using FactStatus.Domain.Rule;
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Main {
    public class FactStatusMain {
        
        private readonly FactStatusPolicy _factStatusPolicy;
        private FactStatusConfig _factStatusConfig;

        /// <summary>
        /// 読み込むファイルパスを設定 
        /// </summary>
        public string LoadFilePath { get; set; }

        /// <summary>
        /// 保存するファイルパスを設定
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// 選択している設定IDを設定
        /// </summary>
        public string SelectIdEntity { get; set; }

        /// <summary>
        /// ドキュメントエンティティの取得
        /// </summary>
        /// <returns></returns>
        public DocumentEntity GetDocumentEntity() {
            return _factStatusPolicy.GetDocumentEntity(_factStatusConfig);
        }

        /// <summary>
        /// 主題エンティティの取得
        /// </summary>
        /// <returns></returns>
        public SubjectEntity GetSubjectEntity() {
            return _factStatusPolicy.GetSubjectEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 実績エンティティの取得
        /// </summary>
        /// <returns></returns>
        public AchievementEntity GetAchievementEntity() {
            return _factStatusPolicy.GetAchievementEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 証拠エンティティの取得
        /// </summary>
        /// <returns></returns>
        public EvidenceEntity GetEvidenceEntity() {
            return _factStatusPolicy.GetEvidenceEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 結果エンティティの取得
        /// </summary>
        /// <returns></returns>
        public ResultEntity GetResultEntity() {
            return _factStatusPolicy.GetResultEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 記録エンティティの取得
        /// </summary>
        /// <returns></returns>
        public RecordEntity GetRecordEntity() {
            return _factStatusPolicy.GetRecordEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 手順エンティティの取得
        /// </summary>
        /// <returns></returns>
        public TodoEntity GetTodoEntity() {
            return _factStatusPolicy.GetTodoEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 構想エンティティの取得
        /// </summary>
        /// <returns></returns>
        public SchemaEntity GetSchemaEntity() {
            return _factStatusPolicy.GetSchemaEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 集合エンティティの取得
        /// </summary>
        /// <returns></returns>
        public GroupEntity GetGroupEntity() {
            return _factStatusPolicy.GetGroupEntity(
                _factStatusConfig,
                SelectIdEntity
            );
        }

        /// <summary>
        /// 主題エンティティ辞書の取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue,SubjectEntity> GetSubjectEntityDict() {
            return _factStatusPolicy.GetSubjectEntityDict(_factStatusConfig);
        }

        /// <summary>
        /// 達成エンティティの取得
        /// </summary>
        /// <param name="idTypeEnum"></param>
        /// <returns></returns>
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetAchievementEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetEvidenceEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, ResultEntity> GetResultEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetResultEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetRecordEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetTodoEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetSchemaEntityDict(_factStatusConfig);
        }

        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict(IdTypeEnum idTypeEnum) {
            return _factStatusPolicy.GetGroupEntityDict(_factStatusConfig);
        }

        /// <summary>
        /// 指定したIDタイプのエンティティを作成
        /// </summary>
        public void CreateEntity(IdTypeEnum idTypeEnum) {
            _factStatusConfig = _factStatusPolicy.CreateEntity(
                _factStatusConfig,
                SelectIdEntity,
                idTypeEnum);
            
        }

        /// <summary>
        /// 指定したIDエンティティを削除
        /// </summary>
        public void DeleteEntity() {
            _factStatusConfig = _factStatusPolicy.DeleteEntity(
                _factStatusConfig,
                SelectIdEntity);
        }

        /// <summary>
        /// エンティティ同士を接続
        /// </summary>
        public void LinkEntity(string linkIdEntity) {
            _factStatusConfig = _factStatusPolicy.LinkEntity(
                _factStatusConfig,
                SelectIdEntity,
                linkIdEntity);
        }

        /// <summary>
        /// エンティティをにコピー
        /// </summary>
        public void CopyEntity(string copyIdEntity) {
            _factStatusConfig = _factStatusPolicy.CopyEntity(
                _factStatusConfig,
                SelectIdEntity,
                copyIdEntity);
        }

        /// <summary>
        /// 複数のエンティティをグループ化
        /// </summary>
        public void GroupEntity(string title, List<string>idEntityList) {
            _factStatusConfig = _factStatusPolicy.GroupEntity(
                _factStatusConfig,
                SelectIdEntity,
                title,
                idEntityList);
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            return _factStatusPolicy.GetAchievementCount(_factStatusConfig);
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return _factStatusPolicy.GetEvidenceCount(_factStatusConfig);
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return _factStatusPolicy.GetResultCount(_factStatusConfig);
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return _factStatusPolicy.GetSuccessCount(_factStatusConfig);
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return _factStatusPolicy.GetFailureCount(_factStatusConfig);
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public void GetFailureConfigList() {
            _factStatusPolicy.GetFailureConfigList(_factStatusConfig);
        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public void LoadRelational() {
            _factStatusConfig = _factStatusPolicy.LoadRelational(LoadFilePath);
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void SaveRelational() {
            _factStatusPolicy.SaveRelational(SaveFilePath, _factStatusConfig);
        }
        
        /// <summary>
        /// JSONファイルの読込
        /// </summary>
        public void LoadJson() {
            _factStatusConfig = _factStatusPolicy.LoadJson(LoadFilePath);
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson() {
            _factStatusPolicy.SaveJson(SaveFilePath, _factStatusConfig);
        }

        /// <summary>
        /// Markdown単体を読み込み
        /// </summary>
        public void LoadMarkdownSelect() {
            _factStatusPolicy.LoadMarkdownSelect(LoadFilePath);
        }

        /// <summary>
        /// Markdown単体で保存
        /// </summary>
        public void SaveMarkdownSelect() {
            _factStatusPolicy.SaveMarkdownSelect(SaveFilePath, _factStatusConfig);
        }

        /// <summary>
        /// Markdownルートから読み込み
        /// </summary>
        public void LoadMarkdownRoot() {
            _factStatusPolicy.LoadMarkdownRoot(LoadFilePath);
        }

        /// <summary>
        /// Markdownルートを作成して保存
        /// </summary>
        public void SaveMarkdownRoot() {
            _factStatusPolicy.SaveMarkdownRoot(SaveFilePath, _factStatusConfig);
        }

        public FactStatusMain(
            FactStatusConfig factStatusConfig,
            FactStatusPolicy factStatusPolicy) {

            this._factStatusPolicy = factStatusPolicy;
            this._factStatusConfig = factStatusConfig;
            this.LoadFilePath = "";
            this.SaveFilePath = "";
            this.SelectIdEntity = "";
        }
    }
}
