# エンティティにリンクを追加の実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. ConnectEntity の各オーバーロードから Policy の ConnectEntity を呼び、Policy で Strategy のリンク操作へ委譲する。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_ConnectEntity/README.md)

