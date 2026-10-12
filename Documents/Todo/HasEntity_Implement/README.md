# エンティティの存在判定の実装

1. `Scripts/FactStatusDomain/Internal/Logic/IFactStatusDomainRepository.cs` を開き、既存の namespace とクラス構成を維持する。
1. HasById(IdValue id) で指定 ID の存在を bool として返し、呼び出し側では IdValue へ変換して Repository へ渡す。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_HasEntity/README.md)

