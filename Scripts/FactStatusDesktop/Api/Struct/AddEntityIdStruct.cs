namespace FactStatus.Desktop.Api.Struct {
    /// <summary>
    /// エンティティ追加時に必要な値をまとめた構造体
    /// </summary>
    public struct AddEntityIdStruct {
        public string DestinationEntityId { get; }
        public string IdType { get; }
        public string Title { get; }
        public string PathName { get; }

        public AddEntityIdStruct(
            string destinationEntityId,
            string idType,
            string title,
            string pathName) {

            this.DestinationEntityId = destinationEntityId;
            this.IdType = idType;
            this.Title = title;
            this.PathName = pathName;
        }
    }
}