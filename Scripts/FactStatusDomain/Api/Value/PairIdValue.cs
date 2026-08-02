namespace FactStatus.Domain.Api.Value {
    /// <summary>
    /// 操作対象と操作先の ID をまとめた値オブジェクトです。
    /// </summary>
    public sealed class PairIdValue {
        public IdValue TargetId { get; }
        public IdValue DestinationId { get; }

        public PairIdValue(IdValue targetId, IdValue destinationId) {
            ArgumentNullException.ThrowIfNull(targetId);
            ArgumentNullException.ThrowIfNull(destinationId);

            TargetId = targetId;
            DestinationId = destinationId;
        }
    }
}
