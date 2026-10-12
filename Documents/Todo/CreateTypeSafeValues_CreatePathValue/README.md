# PathValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/PathValue.cs` に private の `_pathTypeEnum` と getter のみの `Path` を持つ `public class PathValue` を作成する。
1. `PathIsRoot`、`PathIsDirectory`、`PathIsFile`、`PathIsRootFile` では null チェック、`ValidatePath`、`new PathValue(path, 種別)` をこの順に実行する。
1. private `ValidatePath` を PathTypeEnum の switch で作り、Root、Directory、File、RootFile を対応する `Validation.*Value` メソッドへ渡す。
1. コンストラクタでも null チェックと ValidatePath を実行し、Path と `_pathTypeEnum` を設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

