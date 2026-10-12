namespace FactStatus.Domain.Api.Contract;

/// <summary>
/// Desktop などの呼出元へ公開する、エンティティの識別・一覧表示用データです。
/// Domain 内部の Entity は公開しません。
/// </summary>
public sealed record EntitySummaryDto(
    string EntityId,
    string EntityType,
    string PathName,
    string Title);
