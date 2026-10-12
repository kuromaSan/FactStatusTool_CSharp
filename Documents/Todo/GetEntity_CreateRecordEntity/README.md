# RecordEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/RecordEntity.cs` に `public class RecordEntity : IEntity` を置き、基本 4 プロパティ、`DateTime Date`、`string Reviewer`、`BoolValue Success` を追加する。
1. `ChangeDate(string)` は `DateTime.Parse` を DateTime 版へ渡す。DateTime 版では `Validation.DateTimeNotDefault` と `Validation.DateTimeNotFuture(date, DateTime.Now)` の後に Date を設定する。
1. `ChangeReviewer` は `Validation.NullOfString(reviewer)` の後に設定する。3 つの `ChangeSuccess` は BoolValue の bool・int・string 変換を使う。
1. `AutoSet` と `Build` は `DateTime.Now` を渡し、`Create` は空説明、空 Reviewer、`BoolValue.IsTrue()` を渡す。コンストラクタでも日付と Reviewer の Validation を実行してから設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

