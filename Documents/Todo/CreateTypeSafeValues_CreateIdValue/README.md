# IdValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/IdValue.cs` に `int Index` と `IdTypeEnum Type` を getter のみで持つ `public class IdValue` を作成する。
1. `GetId()` は `$"{Index:D4}{(int)Type:D4}"` を返し、`FromString(string id)` は `new IdValue(id)` を返す。
1. コンストラクタで null・長さの Validation を実行し、`id[..^4]` と `id[^4..]` へ分割する。
1. 両方を整数として検証し、後半を `IdTypeEnum` として検証してから、Index と Type を `int.Parse` で設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

