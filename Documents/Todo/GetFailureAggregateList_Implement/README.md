# 失敗内容一覧を取得の実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. GetFailureAggregateList で FailureContentList を理由ごとに GroupBy し、FailureAggregateDto へ変換して理由順に並べる。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_GetFailureAggregateList/README.md)

