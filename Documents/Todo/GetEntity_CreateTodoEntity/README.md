# TodoEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/TodoEntity.cs` に `public class TodoEntity : IEntity` を置き、`Id`、`PathName`、`Title`、`Description` を宣言する。
1. `ChangePathName(string)` は `PathValue.PathIsDirectory(pathName)` を設定し、`ChangeTitle` と `ChangeDescription` は null を空文字へ置き換える。
1. `Duplicate` は既存タイトル・説明を、`Create` は空説明を、`Build` は指定説明をコンストラクタへ渡す。
1. コンストラクタで ID、パス、タイトル、説明を設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

