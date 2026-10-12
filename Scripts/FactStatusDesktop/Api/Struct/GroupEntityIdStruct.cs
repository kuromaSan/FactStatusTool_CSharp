namespace FactStatus.Desktop.Api.Struct {
    /// <summary>
    /// エンティティ追加時に必要な値をまとめた構造体
    /// </summary>
    public struct GroupEntityIdStruct {
        public string parentId { get; }
        public string title { get; }
        public List<string> entityIdList { get; }

        public GroupEntityIdStruct(
            string parentId,
            string title,
            List<string> entityIdList) {
            
            this.parentId = parentId;
            this.title = title;
            this.entityIdList = entityIdList;
        }
    }
}