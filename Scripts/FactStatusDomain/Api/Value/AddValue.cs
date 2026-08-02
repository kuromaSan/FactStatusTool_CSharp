namespace FactStatus.Domain.Api.Value {
    /// <summary>
    /// エンティティ追加時に必要な値をまとめた値オブジェクトです。
    /// </summary>
    public sealed class AddValue {
        public PathValue PathName { get; }
        public string Title { get; }
        public IdTypeEnum IdType { get; }
        public IdValue DestinationId { get; }

        public AddValue(
            PathValue pathName,
            string title,
            IdTypeEnum idType,
            IdValue destinationId) {

            ArgumentNullException.ThrowIfNull(pathName);
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            if (idType == IdTypeEnum.None) {
                throw new ArgumentOutOfRangeException(nameof(idType));
            }
            ArgumentNullException.ThrowIfNull(destinationId);

            PathName = pathName;
            Title = title;
            IdType = idType;
            DestinationId = destinationId;
        }
    }
}
