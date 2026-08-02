using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FactStatus.Domain.Internal.Rule;
using FactStatus.Domain.Api.Value;

namespace FactStatus.Domain.Api.Entity {
    /// <summary>
    /// 記録クラス
    /// </summary>
    public class RecordEntity : IEntity {
        public IdValue Id { get; }
        public PathValue PathName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Reviewer { get; private set; }
        public BoolValue Success { get; private set; }

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
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void ChangeDate(string date) {
            ChangeDate(DateTime.Parse(date));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void ChangeDate(DateTime date) {
            Validation.DateTimeNotDefault(date);
            Validation.DateTimeNotFuture(date, DateTime.Now);
            Date = date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reviewer"></param>
        public void ChangeReviewer(string reviewer) {
            Validation.NullOfString(reviewer);
            Reviewer = reviewer;
        }
        
        /// <summary>
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(bool success) {
            Success = new BoolValue(success);
        }

        /// <summary>
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(int success) {
            Success = BoolValue.FromInt(success);
        }

        /// <summary>
        /// 成功状態の変更
        /// </summary>
        /// <param name="success"></param>
        public void ChangeSuccess(string success) {
            Success = BoolValue.FromString(success);
        }

        /// <summary>
        /// エンティティを複製
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public RecordEntity Duplicate(
            IdValue id,
            PathValue path) {

            return new RecordEntity(id, path, Title, Description, Date, Reviewer, Success);
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="discription"></param>
        /// <param name="reviewer"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public static RecordEntity AutoSet(
            IdValue id,
            PathValue pathName,
            string title,
            string discription,
            string reviewer,
            BoolValue success) {

            return new RecordEntity(
                id,
                pathName,
                title,
                discription,
                DateTime.Now,
                reviewer,
                success);
        }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static RecordEntity Create(
            IdValue id,
            PathValue pathName,
            string title) {

            return new RecordEntity(
                id,
                pathName,
                title,
                "",
                DateTime.Now,
                "",
                BoolValue.IsTrue());
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static RecordEntity Build(
            IdValue id,
            PathValue pathName,
            string title,
            string discription,
            string reviewer,
            BoolValue success) {

            return new RecordEntity(
                id,
                pathName,
                title,
                discription,
                DateTime.Now,
                reviewer,
                success);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pathName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="reviewer"></param>
        /// <param name="success"></param>
        public RecordEntity(
            IdValue id,
            PathValue pathName,
            string title,
            string description,
            DateTime date,
            string reviewer,
            BoolValue success){

            Id = id;
            PathName = pathName;
            Title = title ?? "";
            Description = description ?? "";
            
            Validation.DateTimeNotDefault(date);
            Validation.DateTimeNotFuture(date,DateTime.Now);
            Date = date;

            Validation.NullOfString(reviewer);
            Reviewer = reviewer;

            Success = success;
        }
    }
}
