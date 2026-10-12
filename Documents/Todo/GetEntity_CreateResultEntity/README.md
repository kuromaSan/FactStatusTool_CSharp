# ResultEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/ResultEntity.cs` に `public class ResultEntity : IEntity` を置き、`Id`、`PathName`、`Title`、`List<ArgumentValue> Arguments`、`List<AssertionValue> Assertions` を追加する。
1. `ChangePathName(string)` で `PathValue.PathIsDirectory(pathName)` を設定し、`ChangeTitle` は null を空文字へ置き換える。`GetArguments` と `GetAssertions` は各リストを返す。
1. `Create` は `new List<ArgumentValue>()` と `new List<AssertionValue>()` を作成してコンストラクタへ渡す。`Build` と `Duplicate` は受け取った、または既存の 2 リストを渡す。
1. コンストラクタで ID、パス、タイトル、Arguments、Assertions を設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

