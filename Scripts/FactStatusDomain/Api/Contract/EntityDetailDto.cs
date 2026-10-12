namespace FactStatus.Domain.Api.Contract;

/// <summary>
/// 選択中エンティティと、その画面表示に必要な関連情報です。
/// </summary>
public sealed record EntityDetailDto(
    EntitySummaryDto Entity,
    EntitySummaryDto? Parent,
    IReadOnlyList<EntitySummaryDto> Children);
