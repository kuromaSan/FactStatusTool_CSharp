# エンティティを保持するAggregateを作成

1. `Scripts/FactStatusDomain/Internal/Entity/FactStatusDomainAggregate.cs` に `public class FactStatusDomainAggregate` を作成する。
1. SaveFileName、SelectedEntity、ParentEntity、AllEntityList、SearchedEntityList、各件数、FailureContentList のプロパティを追加する。
1. `AllEntityList` はコンストラクタ引数 `List<IEntity> allEntityList` と同じ `List<IEntity>` 型にそろえる。
1. コンストラクタで saveFileName、selectedEntity、parentEntity、allEntityList、searchedEntityList、5 個の集計値、failureContentList を受け取り、同名プロパティへ代入する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

