namespace FactStatus.Desktop.Api.Struct {
    /// <summary>
    /// エンティティ追加時に必要な値をまとめた構造体
    /// </summary>
    public struct FailureAggregateStruct {
        public string FailureReason { get; }
        public int Count { get; }

        public FailureAggregateStruct(
            string failureReason,
            int count) {

            this.FailureReason = failureReason;
            this.Count = count;
        }
    }
}