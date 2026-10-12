namespace FactStatus.Domain.Internal.Value {
    /// <summary>
    /// エンティティ追加時に必要な値をまとめた値オブジェクトです。
    /// </summary>
    public sealed class AddValue {
        public PathValue PathName { get; }
        public string Title { get; }
        public IdTypeEnum IdType { get; }
        public IdValue DestinationId { get; }

        static public AddValue FromString(
            string pathName,
            string title,
            string idType,
            string destinationId) {

            // nullチェック
            Validation.NullOfString(pathName);
            Validation.NullOfString(idType);
            Validation.NullOfString(destinationId);

            // パス変換
            PathValue pathValue = PathValue.PathIsDirectory(pathName);
            // enum変換
            IdTypeEnum idTypeEnum = Validation.StringToEnum<IdTypeEnum>(idType);
            // ID変換
            IdValue destinationIdValue = IdValue.FromString(destinationId);

            return new AddValue(
                pathValue,
                title,
                idTypeEnum,
                destinationIdValue);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AddValue(
            PathValue pathName,
            string title,
            IdTypeEnum idType,
            IdValue destinationId) {
            
            // nullチェック
            Validation.NullOfString(title);

            PathName = pathName;
            Title = title;
            IdType = idType;
            DestinationId = destinationId;
        }
    }
}
