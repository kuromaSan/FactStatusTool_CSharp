using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Entity {
    /// <summary>
    /// 達成設定クラス
    /// </summary>
    public class AchievementEntity : IEntity {
        
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Dictionary<IdValue,IEntity> EvidenceEntityDict { get; private set; }
        public Dictionary<IdValue,IEntity> TodoEntityDict { get; private set; }
        public Dictionary<IdValue,IEntity> SchemaEntityDict { get; private set; }

        /// <summary>
        /// パス名の変更
        /// </summary>
        /// <param name="pathName"></param>
        public void ChangePathName(PathValue pathName) {
            PathName = pathName;
        }
        
        /// <summary>
        /// パス名の変更
        /// </summary>
        /// <param name="pathName"></param>
        public void ChangePathName(string pathName) {
            PathName = PathValue.PathIsDirectory(pathName);
        }

        /// <summary>
        /// タイトルの変更
        /// </summary>
        /// <param name="title"></param>
        public void ChangeTitle(string title) {
            Title = title ?? "";
        }

        /// <summary>
        /// 内容の変更
        /// </summary>
        /// <param name="description"></param>
        public void ChangeDescription(string description) {
            Description = description ?? "";
        }

        /// <summary>
        /// 証拠エンティティを追加
        /// </summary>
        /// <param name="evidenceEntity"></param>
        public void AddEvidenceEntity(IEntity evidenceEntity) {
            if (evidenceEntity == null) {
                return;
            }
            EvidenceEntityDict[evidenceEntity.Id] = evidenceEntity;
        }

        /// <summary>
        /// 証拠エンティティを削除
        /// </summary>
        /// <param name="evidenceIdValue"></param>
        public void DeleteEvidenceEntity(IdValue evidenceIdValue) {
            EvidenceEntityDict.Remove(evidenceIdValue);
        }

        /// <summary>
        /// 実装エンティティを追加
        /// </summary>
        /// <param name="todoEntity"></param>
        public void AddTodoEntity(IEntity todoEntity) {
            if (todoEntity == null) {
                return;
            }
            TodoEntityDict[todoEntity.Id] = todoEntity;
        }

        /// <summary>
        /// 実装エンティティを削除
        /// </summary>
        /// <param name="todoIdValue"></param>
        public void DeleteTodoEntity(IdValue todoIdValue) {
            TodoEntityDict.Remove(todoIdValue);
        }

        /// <summary>
        /// 構想エンティティを追加
        /// </summary>
        /// <param name="schemaEntity"></param>
        public void AddSchemaEntity(IEntity schemaEntity) {
            if (schemaEntity == null) {
                return;
            }
            SchemaEntityDict[schemaEntity.Id] = schemaEntity;
        }

        /// <summary>
        /// 構想エンティティを削除
        /// </summary>
        /// <param name="schemaIdValue"></param>
        public void DeleteSchemaEntity(IdValue schemaIdValue) {
            SchemaEntityDict.Remove(schemaIdValue);
        }

        /// <summary>
        /// エンティティを複製
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public AchievementEntity Duplicate(
            IdValue id,
            PathValue path) {

            return new AchievementEntity(
                id,
                path,
                Title,
                Description,
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>());
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static AchievementEntity Create(
            IdValue id,
            PathValue pathName,
            string title) {

            return new AchievementEntity(
                id,
                pathName,
                title,
                "",
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>());
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static AchievementEntity Build(
            IdValue id,
            PathValue pathName,
            string title,
            string description) {
            return new AchievementEntity(
                id,
                pathName,
                title,
                description,
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>(),
                new Dictionary<IdValue,IEntity>());
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public AchievementEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description,
            Dictionary<IdValue,IEntity> evidenceEntityDict,
            Dictionary<IdValue,IEntity> todoEntityDict,
            Dictionary<IdValue,IEntity> schemaEntityDict) {

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
            EvidenceEntityDict = evidenceEntityDict ?? new Dictionary<IdValue,IEntity>();
            TodoEntityDict = todoEntityDict ?? new Dictionary<IdValue,IEntity>();
            SchemaEntityDict = schemaEntityDict ?? new Dictionary<IdValue,IEntity>();
        }
    }
}
