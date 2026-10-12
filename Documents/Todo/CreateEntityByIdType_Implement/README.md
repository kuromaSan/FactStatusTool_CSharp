# 指定したIDタイプでエンティティを作成の実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. CreateEntity の AddValue を受け取るオーバーロードから Policy の CreateEntity を呼び、指定された IdType に対応する Entity を作成する。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_CreateEntityByIdType/README.md)

