# PairIdValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/PairIdValue.cs` に getter のみの `IdValue TargetId` と `IdValue DestinationId` を持つ `public sealed class PairIdValue` を作成する。
1. コンストラクタで `ArgumentNullException.ThrowIfNull(targetId)` と `ArgumentNullException.ThrowIfNull(destinationId)` を実行する。
1. null チェック後に TargetId と DestinationId を設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

