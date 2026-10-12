# DomainMainにGetEntity関数の作成

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` では取得 API 名を `GetSelectedEntity` とし、別名の `GetEntity` は追加しない。
1. `public EntityDetailDto GetSelectedEntity(string selectIdValue)` 内で `_factStatusDomainPolicy.GetSelectedEntity(ref _factStatusDomainAggregate, selectIdValue);` を実行する。
1. 同メソッドの戻り値として `CreateEntityDetailDto(_factStatusDomainAggregate)` を返す。
1. 引数なしの `GetSelectedEntity()` は現在の Aggregate を `CreateEntityDetailDto` へ渡して返す。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

