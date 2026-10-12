# DomainStrategyにGetEntity関数の作成

1. `Scripts/FactStatusDomain/Internal/Logic/FactStatusDomainStrategy.cs` に `public IEntity GetEntityByIdValue(IdValue idValue)` を置く。
1. メソッド内で `_factStatusRepository.FindById(idValue)` を呼び出し、その `IEntity` を戻り値として返す。
1. `IFactStatusDomainRepository` の `IEntity FindById(IdValue id)` と同じ戻り型を維持する。
1. 未完成の dto 変数と return 文は残さず、Repository の戻り値を直接返す。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

