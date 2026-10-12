using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Entity {
    /// <summary>
    /// 主題設定クラス
    /// </summary>
    public class SubjectEntity : IEntity {

        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Dictionary<IdValue, AchievementEntity> AchievementEntityDict { get; private set; }
        public Dictionary<IdValue, SchemaEntity> SchemaEntityDict { get; private set; }

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
        /// 達成エンティティを追加
        /// </summary>
        /// <param name="achievementEntity"></param>
        public void AddAchievementEntity(AchievementEntity achievementEntity) {
            if (achievementEntity == null) {
                return;
            }
            AchievementEntityDict[achievementEntity.Id] = achievementEntity;
        }

        /// <summary>
        /// 達成エンティティを削除
        /// </summary>
        /// <param name="achievementIdValue"></param>
        public void DeleteAchievementEntity(IdValue achievementIdValue) {
            AchievementEntityDict.Remove(achievementIdValue);
        }

        /// <summary>
        /// 構想エンティティを追加
        /// </summary>
        /// <param name="schemaEntity"></param>
        public void AddSchemaEntity(SchemaEntity schemaEntity) {
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
        /// <param name="pathName"></param>
        /// <returns></returns>
        public SubjectEntity Duplicate(
            IdValue id,
            PathValue path) {
                
            return new SubjectEntity(
                id,
                path,
                Title,
                Description,
                new Dictionary<IdValue, AchievementEntity>(),
                new Dictionary<IdValue, SchemaEntity>());
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static SubjectEntity Create(
            IdValue id,
            PathValue pathName,
            string title) {

            return new SubjectEntity(
                id,
                pathName,
                title,
                "",
                new Dictionary<IdValue, AchievementEntity>(),
                new Dictionary<IdValue, SchemaEntity>());
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static SubjectEntity Build(
            IdValue id,
            PathValue pathName,
            string title,
            string description,
            Dictionary<IdValue, AchievementEntity> achievementEntityDict,
            Dictionary<IdValue, SchemaEntity> schemaEntityDict) {

            return new SubjectEntity(
                id,
                pathName,
                title,
                description,
                achievementEntityDict,
                schemaEntityDict);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="achievementEntityDict"></param>
        /// <param name="schemaEntityDict"></param>
        public SubjectEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description,
            Dictionary<IdValue, AchievementEntity> achievementEntityDict,
            Dictionary<IdValue, SchemaEntity> schemaEntityDict) {

            // 初期設定
            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
            AchievementEntityDict = achievementEntityDict ?? new Dictionary<IdValue, AchievementEntity>();
            SchemaEntityDict = schemaEntityDict ?? new Dictionary<IdValue, SchemaEntity>();
        }
    }
}
