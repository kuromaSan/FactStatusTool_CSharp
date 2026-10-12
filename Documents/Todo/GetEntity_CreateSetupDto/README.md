# SetupDtoの作成

1. 現行ソースに `SetupDto` はないため、`Scripts/FactStatusDomain/Internal/Setup/FactStatusDomainDao.cs` を作成対象にする。
1. `FactStatusDomainDao` に DocumentAggregate、各 Entity の Aggregates、ArgumentProperties、AssertionProperties、ParentEdges、GroupEdges を `required` プロパティとして追加する。
1. 各 AggregateJsonDto には `id`、`path_name`、`title` と要素固有の値を、`JsonPropertyName` 属性付きの `required string` プロパティとして追加する。
1. Argument、Assertion、ParentEdge、GroupEdge の JsonDto には、同ファイルで定義された属性名とプロパティ名をそのまま追加する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

