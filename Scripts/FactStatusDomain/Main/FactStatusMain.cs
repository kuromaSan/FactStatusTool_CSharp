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
        private FactStatusAggregate _factStatusAggregate;

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
        public string SelectIdValue { get; set; }


        /// <summary>
        /// 選択しているIDエンティティの親IDエンティティを取得
        /// </summary>
        /// <returns></returns>
        public IEntity GetParentIdEntity() {
            return _factStatusPolicy.GetParentIdEntity(
                _factStatusAggregate,
                SelectIdValue);
        }

        /// <summary>
        /// 選択しているIDエンティティの子IDエンティティリストを取得
        /// </summary>
        /// <returns></returns>
        public List<IEntity> GetChildIdEntityList() {
            return _factStatusPolicy.GetChildrenIdEntityList(
                _factStatusAggregate,
                SelectIdValue);
        }

        /// <summary>
        /// ドキュメントエンティティの取得
        /// </summary>
        /// <returns></returns>
        public DocumentEntity GetDocumentEntity() {
            return _factStatusPolicy.GetDocumentEntity(_factStatusAggregate);
        }

        /// <summary>
        /// 主題エンティティの取得
        /// </summary>
        /// <returns></returns>
        public SubjectEntity GetSubjectEntity() {
            return _factStatusPolicy.GetSubjectEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 実績エンティティの取得
        /// </summary>
        /// <returns></returns>
        public AchievementEntity GetAchievementEntity() {
            return _factStatusPolicy.GetAchievementEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 証拠エンティティの取得
        /// </summary>
        /// <returns></returns>
        public EvidenceEntity GetEvidenceEntity() {
            return _factStatusPolicy.GetEvidenceEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 結果エンティティの取得
        /// </summary>
        /// <returns></returns>
        public ResultEntity GetResultEntity() {
            return _factStatusPolicy.GetResultEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 記録エンティティの取得
        /// </summary>
        /// <returns></returns>
        public RecordEntity GetRecordEntity() {
            return _factStatusPolicy.GetRecordEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 手順エンティティの取得
        /// </summary>
        /// <returns></returns>
        public TodoEntity GetTodoEntity() {
            return _factStatusPolicy.GetTodoEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 構想エンティティの取得
        /// </summary>
        /// <returns></returns>
        public SchemaEntity GetSchemaEntity() {
            return _factStatusPolicy.GetSchemaEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 集合エンティティの取得
        /// </summary>
        /// <returns></returns>
        public GroupEntity GetGroupEntity() {
            return _factStatusPolicy.GetGroupEntity(
                _factStatusAggregate,
                SelectIdValue
            );
        }

        /// <summary>
        /// 主題エンティティ辞書の取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue,SubjectEntity> GetSubjectEntityDict() {
            return _factStatusPolicy.GetSubjectEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 達成エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, AchievementEntity> GetAchievementEntityDict() {
            return _factStatusPolicy.GetAchievementEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 証拠エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, EvidenceEntity> GetEvidenceEntityDict() {
            return _factStatusPolicy.GetEvidenceEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 結果エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, ResultEntity> GetResultEntityDict() {
            return _factStatusPolicy.GetResultEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 記録エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, RecordEntity> GetRecordEntityDict() {
            return _factStatusPolicy.GetRecordEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 実装エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, TodoEntity> GetTodoEntityDict() {
            return _factStatusPolicy.GetTodoEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 構想エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, SchemaEntity> GetSchemaEntityDict() {
            return _factStatusPolicy.GetSchemaEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 集合エンティティの取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<IdValue, GroupEntity> GetGroupEntityDict() {
            return _factStatusPolicy.GetGroupEntityDict(_factStatusAggregate);
        }

        /// <summary>
        /// 指定したIDタイプのエンティティを作成
        /// </summary>
        public void CreateEntity(string createIdType, string title, string pathName) {
            _factStatusAggregate = _factStatusPolicy.CreateEntity(
                _factStatusAggregate,
                SelectIdValue,
                createIdType,
                title,
                pathName);
        }

        /// <summary>
        /// 指定したIDエンティティを削除
        /// </summary>
        public void DeleteEntity() {
            _factStatusAggregate = _factStatusPolicy.DeleteEntity(
                _factStatusAggregate,
                SelectIdValue);
        }

        /// <summary>
        /// エンティティを移動
        /// </summary>
        public void MoveEntity(string linkIdEntity) {
            _factStatusAggregate = _factStatusPolicy.MoveEntity(
                _factStatusAggregate,
                SelectIdValue,
                linkIdEntity);
        }

        /// <summary>
        /// エンティティをコピー
        /// </summary>
        public void CopyEntity(string copyIdEntity) {
            _factStatusAggregate = _factStatusPolicy.CopyEntity(
                _factStatusAggregate,
                SelectIdValue,
                copyIdEntity);
        }

        /// <summary>
        /// 複数のエンティティをグループ化
        /// </summary>
        public void GroupEntity(string title, List<string>idEntityList) {
            _factStatusAggregate = _factStatusPolicy.GroupEntity(
                _factStatusAggregate,
                SelectIdValue,
                title,
                idEntityList);
        }

        /// <summary>
        /// 達成数を取得
        /// </summary>
        public int GetAchievementCount() {
            return _factStatusPolicy.GetAchievementCount(_factStatusAggregate);
        }

        /// <summary>
        /// 証拠数を取得 
        /// </summary>
        public int GetEvidenceCount() {
            return _factStatusPolicy.GetEvidenceCount(_factStatusAggregate);
        }

        /// <summary>
        /// 結果数を取得
        /// </summary>
        public int GetResultCount() {
            return _factStatusPolicy.GetResultCount(_factStatusAggregate);
        }

        /// <summary>
        /// 成功数を取得
        /// </summary>
        public int GetSuccessCount() {
            return _factStatusPolicy.GetSuccessCount(_factStatusAggregate);
        }

        /// <summary>
        ///失敗数を取得
        /// </summary>
        public int GetFailureCount() {
            return _factStatusPolicy.GetFailureCount(_factStatusAggregate);
        }
        
        /// <summary>
        ///失敗内容一覧を取得
        /// </summary>
        public void GetFailureAggregateList() {
            _factStatusPolicy.GetFailureAggregateList(_factStatusAggregate);
        }

        /// <summary>
        /// リレーショナル型の読込
        /// </summary>
        public void LoadRelational() {
            _factStatusAggregate = _factStatusPolicy.LoadRelational(LoadFilePath);
        }

        /// <summary>
        /// リレーショナル型で保存
        /// </summary>
        public void SaveRelational() {
            _factStatusPolicy.SaveRelational(SaveFilePath, _factStatusAggregate);
        }
        
        /// <summary>
        /// JSONファイルの読込
        /// </summary>
        public void LoadJson() {
            _factStatusAggregate = _factStatusPolicy.LoadJson(LoadFilePath);
        }

        /// <summary>
        /// JSONファイルで保存
        /// </summary>
        public void SaveJson() {
            _factStatusPolicy.SaveJson(SaveFilePath, _factStatusAggregate);
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
            _factStatusPolicy.SaveMarkdownSelect(SaveFilePath, _factStatusAggregate);
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
            _factStatusPolicy.SaveMarkdownRoot(SaveFilePath, _factStatusAggregate);
        }

        public FactStatusMain(
            FactStatusAggregate factStatusAggregate,
            FactStatusPolicy factStatusPolicy) {

            this._factStatusPolicy = factStatusPolicy;
            this._factStatusAggregate = factStatusAggregate;
            this.LoadFilePath = "";
            this.SaveFilePath = "";
            this.SelectIdValue = "";
        }
    }
}
