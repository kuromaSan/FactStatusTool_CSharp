# エンティティにリンクを削除の実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. DisconnectEntity の各オーバーロードから Policy の DisconnectEntity を呼び、指定した関連を削除する。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_DisconnectEntity/README.md)

