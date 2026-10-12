# SubjectEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/SubjectEntity.cs` に `public class SubjectEntity : IEntity` を置き、`Id`、`PathName`、`Title`、`Description`、`Dictionary<IdValue, AchievementEntity> AchievementEntityDict`、`Dictionary<IdValue, SchemaEntity> SchemaEntityDict` を getter と private setter で宣言する。
1. `ChangePathName(string)` は `PathValue.PathIsDirectory(pathName)` を設定し、`ChangeTitle` と `ChangeDescription` は `value ?? ""` を設定する。
1. `AddAchievementEntity`／`AddSchemaEntity` は null の場合に return し、それ以外は対応する辞書へ `entity.Id` をキーに代入する。`DeleteAchievementEntity`／`DeleteSchemaEntity` は対応する ID を `Remove` する。
1. `Duplicate` は指定 ID・パス、既存タイトル・説明、2 個の空辞書を渡す。`Create` は空説明と 2 個の空辞書を、`Build` は説明と 2 辞書をコンストラクタへ渡す。
1. コンストラクタで ID、パス、タイトル、説明を設定し、各辞書が null の場合は対応する空辞書を設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

