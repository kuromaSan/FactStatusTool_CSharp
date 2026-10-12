# 選択中の親エンティティを取得するの実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. GetParentEntity で Policy の GetParentEntity を呼び、Aggregate の親 Entity を EntitySummaryDto へ変換して返す。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_GetSelectedParentEntity/README.md)

