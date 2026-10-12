# DomainPolicyにGetEntity関数の作成

1. `Scripts/FactStatusDomain/Internal/Logic/FactStatusDomainPolicy.cs` に `public void GetSelectedEntity(ref FactStatusDomainAggregate factStatusDomainAggregate, string stringId)` を追加する。
1. メソッド先頭で `var idValue = IdValue.FromString(stringId);` を実行する。
1. `ResetSelectedEntity(ref factStatusDomainAggregate, idValue);` を呼び出す。
1. ResetSelectedEntity 内で `_factStatusStrategy.GetEntityByIdValue(idValue)` の戻り値を `factStatusDomainAggregate.SelectedEntity` へ代入する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

