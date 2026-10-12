namespace FactStatus.Domain.Api.Contract;

/// <summary>
/// 失敗理由ごとの集計結果です。
/// </summary>
public sealed record FailureAggregateDto(
    string FailureReason,
    int Count);
