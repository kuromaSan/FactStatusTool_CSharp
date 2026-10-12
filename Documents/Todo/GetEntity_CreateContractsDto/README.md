# ContractsDtoの作成

1. 現行ソースに `ContractsDto` はないため、`Scripts/FactStatusDomain/Api/Contract/EntitySummaryDto.cs` を作成対象にする。
1. `FactStatus.Domain.Api.Contract` namespace 内に `public sealed record EntitySummaryDto(string EntityId, string EntityType, string PathName, string Title);` を置く。
1. `EntityDetailDto.cs` に `public sealed record EntityDetailDto(EntitySummaryDto Entity, EntitySummaryDto? Parent, IReadOnlyList<EntitySummaryDto> Children);` を置く。
1. `FactStatusDomainMain.cs` の `CreateEntitySummaryDto` と `CreateEntityDetailDto` で、この 2 record を生成する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

