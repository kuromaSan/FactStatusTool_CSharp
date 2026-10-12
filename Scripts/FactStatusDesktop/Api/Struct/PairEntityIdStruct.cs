namespace FactStatus.Desktop.Api.Struct {
    /// <summary>
    /// 操作対象と操作先の ID をまとめた構造体
    /// </summary>
    public sealed class PairEntityIdStruct {
        public string TargetId { get; }
        public string DestinationId { get; }

        public PairEntityIdStruct(string targetId, string destinationId) {
            this.TargetId = targetId;
            this.DestinationId = destinationId;
        }
    }
}
