using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Internal.Logic {
    public interface IFactStatusDomainRepository {
        /// <summary>
        /// 永続ストアを使用可能な状態にする。SQLite 実装ではDBファイル、テーブル、索引を作成する。
        /// </summary>
        /// <param name="databasePath">SQLite DBファイルのパス。</param>
        void Initialize(PathValue databasePath);

        /// <summary>
        /// 指定した ID のエンティティを取得
        /// </summary>
        IEntity FindById(IdValue id);

        /// <summary>
        /// 指定した ID の接続しているエンティティ一覧を取得
        /// </summary>
        List<IEntity> FindConnectedEntitieListById(IdValue id);

        /// <summary>
        /// 指定した ID のエンティティが存在するかを判定します。
        /// </summary>
        bool HasById(IdValue id);

        /// <summary>
        /// 指定した ID 種別のエンティティ一覧を取得します。
        /// </summary>
        List<IEntity> GetEntityList(IdTypeEnum idType);

        /// <summary>
        /// 指定した ID 種別のエンティティ数を取得します。
        /// </summary>
        int EntityCount(IdTypeEnum idType);

        /// <summary>
        /// OK 状態のエンティティ数を取得します。
        /// </summary>
        int OKCount();

        /// <summary>
        /// NG 状態のエンティティ数を取得します。
        /// </summary>
        int NGCount();

        /// <summary>
        /// タイトルでエンティティを検索します。
        /// </summary>
        List<IEntity> SearchByTitle(string title);

        /// <summary>
        /// 本文または説明でエンティティを検索します。
        /// </summary>
        List<IEntity> SearchByText(string text);

        /// <summary>
        /// エンティティを追加し、指定した宛先に関連付けます。
        /// </summary>
        IEntity AddEntity(AddValue addValue);

        /// <summary>
        /// 複数のエンティティを一括で追加します。
        /// </summary>
        List<IEntity> AddByAddValueList(List<AddValue> addValueList);

        /// <summary>
        /// エンティティを移動します。
        /// </summary>
        void Move(PairIdValue pairId, bool only);

        /// <summary>
        /// 複数のエンティティを一括で移動します。
        /// </summary>
        void MoveByPairIdValueList(List<PairIdValue> pairIds, bool only);

        /// <summary>
        /// エンティティを複製します。
        /// </summary>
        void Copy(PairIdValue pairId, bool only);

        /// <summary>
        /// 複数のエンティティを一括で複製します。
        /// </summary>
        void CopyByPairIdValueList(List<PairIdValue> pairIds, BoolValue only);

        /// <summary>
        /// エンティティを削除します。
        /// </summary>
        void Delete(IdValue id, BoolValue only);

        /// <summary>
        /// 複数のエンティティを一括で削除します。
        /// </summary>
        void DeleteByIdValueList(List<IdValue> ids, BoolValue only);

        /// <summary>
        /// 属性 ID を基準に対象エンティティを更新します。
        /// </summary>
        void UpdateByAttributeId();

        /// <summary>
        /// 複数の属性 ID を基準に対象エンティティを一括更新します。
        /// </summary>
        void UpdateByAttributeIdList();

        /// <summary>
        /// ID の組を指定してエンティティまたは関連を追加します。
        /// </summary>
        void AddByPairIdValue();

        /// <summary>
        /// 複数の ID の組を指定してエンティティまたは関連を一括追加します。
        /// </summary>
        void AddByPairIdValueList();

        /// <summary>
        /// JSON ファイルからデータを読み込みます。
        /// </summary>
        void LoadJson(PathValue pathName);

        /// <summary>
        /// 現在のデータを JSON ファイルへ保存します。
        /// </summary>
        void SaveJson(PathValue pathName);

        /// <summary>
        /// XML ファイルからデータを読み込みます。
        /// </summary>
        void LoadXml(PathValue pathName);

        /// <summary>
        /// 現在のデータを XML ファイルへ保存します。
        /// </summary>
        void SaveXml(PathValue pathName);

        /// <summary>
        /// 単一の Markdown ファイルを読み込みます。
        /// </summary>
        void LoadMarkdown(PathValue pathName);

        /// <summary>
        /// 単一の Markdown ファイルへ保存します。
        /// </summary>
        void SaveMarkdown(PathValue pathName);

        /// <summary>
        /// エンティティを表す Markdown 群を読み込みます。
        /// </summary>
        void LoadMarkdownEntitys(PathValue pathName);

        /// <summary>
        /// エンティティを Markdown 群として保存します。
        /// </summary>
        void SaveMarkdownEntitys(PathValue pathName);

        /// <summary>
        /// Document を表す Markdown 群を読み込みます。
        /// </summary>
        void LoadMarkdownDocuments(PathValue pathName);

        /// <summary>
        /// Document を Markdown 群として保存します。
        /// </summary>
        void SaveMarkdownDocuments(PathValue pathName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IdPatternRulesDao LoadIdPatternRules(PathValue filePath);
    }
}
