# AchievementEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/AchievementEntity.cs` に `public class AchievementEntity : IEntity` を置き、基本 4 プロパティと `EvidenceEntityDict`、`TodoEntityDict`、`SchemaEntityDict` を `Dictionary<IdValue, IEntity>` 型で宣言する。
1. `ChangePathName` の PathValue・string の 2 オーバーロードを追加する。string 版は `PathValue.PathIsDirectory(pathName)` を設定し、タイトル・説明の変更は null を空文字へ置き換える。
1. Evidence、Todo、Schema の各 `Add...` は null の場合に return し、それ以外は ID キーで辞書へ代入する。各 `Delete...` は対応する辞書から ID を削除する。
1. `Duplicate`、`Create`、`Build`、コンストラクタには 3 個の `Dictionary<IdValue, IEntity>` を渡す。Create と Build では空辞書を渡し、コンストラクタでは null を空辞書へ置き換える。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

