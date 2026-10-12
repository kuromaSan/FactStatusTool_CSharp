# DomainRepositoryにGetEntity関数の作成

1. `Scripts/FactStatusDomain/Internal/Setup/FactStatusDomainRepository.cs` の `FindById(IdValue id)` を取得用の実装箇所とする。
1. 永続ストアから id に一致する 1 件を読み出し、対応する `IEntity` を戻り値として返す処理を実装する。
1. `IFactStatusDomainRepository.FindById` と同じ null 許容仕様および戻り型にそろえる。
1. `throw new NotSupportedException()` を削除し、Strategy の `GetEntityByIdValue` から直接利用できる戻り値を返す。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

