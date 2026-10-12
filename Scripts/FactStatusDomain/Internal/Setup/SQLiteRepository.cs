using System.Globalization;
using FactStatus.Domain.Internal.Entity;
using FactStatus.Domain.Internal.Logic;
using FactStatus.Domain.Internal.Value;
using Microsoft.Data.Sqlite;

namespace FactStatus.Domain.Internal.Setup {
    /// <summary>
    /// FactStatus のスナップショットを Entity / 型別 Value / Relation に正規化して保存する SQLite 実装。
    /// </summary>
    public sealed class SQLiteRepository : IFactStatusDomainRepository {
        private const string TextType = "text";
        private const string BooleanType = "boolean";
        private const string DateTimeType = "datetime";

        private static readonly (string Id, string Name, string ValueType)[] AttributeDefinitions = [
            ("1003", "description", TextType), ("1004", "success", BooleanType),
            ("1005", "date", DateTimeType), ("1006", "reviewer", TextType),
            ("1007", "experience", TextType), ("1008", "evaluation", TextType),
            ("1009", "hypothesis", TextType), ("1010", "abstraction_goal", TextType),
            ("1011", "execution_goal", TextType)
        ];

        private PathValue? _databasePath;

        /// <summary>
        /// DBファイルを開き、スキーマと初期属性定義を作成する。
        /// 既存DBの場合はデータを変更せず、不足するテーブル・索引だけを追加する。
        /// </summary>
        public void Initialize(PathValue databasePath) {
            ArgumentNullException.ThrowIfNull(databasePath);
            _databasePath = databasePath;
            using SqliteConnection connection = Open(databasePath);
            EnsureSchema(connection);
        }

        public IEntity FindById(IdValue id) {
            return LoadEntities().FirstOrDefault(x => x.Id.GetId() == id.GetId());
        }
        
        public bool HasById(IdValue id) {
            return FindById(id) is not null;
        }
        
        public List<IEntity> GetEntityList(IdTypeEnum idType) {
            return LoadEntities().Where(x => x.Id.Type == idType).ToList();
        }
        
        public int EntityCount(IdTypeEnum idType) {
            return GetEntityList(idType).Count;
        }
        
        public int OKCount() {
            return LoadEntities().OfType<EvidenceEntity>().Count(x => x.Success.Value);
        }
        
        public int NGCount() {
            return LoadEntities().OfType<EvidenceEntity>().Count(x => !x.Success.Value);
        }
        
        public List<IEntity> SearchByTitle(string title) {
            return LoadEntities().Where(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public List<IEntity> SearchByText(string text) {
            return LoadEntities().Where(x => GetSearchText(x).Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public IEntity AddEntity(AddValue addValue) {
            throw new NotSupportedException();
        }
        
        public List<IEntity> AddEntityByAddValueList(List<AddValue> addValueList) {
            throw new NotSupportedException();
        }
        
        public void Move(PairIdValue pairId, bool only) {
            throw new NotSupportedException();
        }
        
        public void MoveByPairIdValueList(List<PairIdValue> pairIds, bool only) {
            throw new NotSupportedException();
        }
        
        public void Copy(PairIdValue pairId, bool only) {
            throw new NotSupportedException();
        }
        
        public void CopyByPairIdValueList(List<PairIdValue> pairIds, BoolValue only) {
            throw new NotSupportedException();
        }
        
        public void Delete(IdValue id, BoolValue only) {
            throw new NotSupportedException();
        }
        
        public void DeleteByIdValueList(List<IdValue> ids, BoolValue only) {
            throw new NotSupportedException();
        }
        
        public void UpdateByAttributeId() {
            throw new NotSupportedException();
        }
        
        public void UpdateByAttributeIdList() {
            throw new NotSupportedException();
        }
        
        public void AddByPairIdValue() {
            throw new NotSupportedException();
        }
        
        public void AddByPairIdValueList() {
            throw new NotSupportedException();
        }
        
        public void LoadJson(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void SaveJson(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void LoadXml(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void SaveXml(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void LoadMarkdown(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void LoadMarkdownEntitys(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void LoadMarkdownDocuments(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void SaveMarkdown(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void SaveMarkdownEntitys(PathValue pathName) {
            throw new NotSupportedException();
        }
        
        public void SaveMarkdownDocuments(PathValue pathName) {
            throw new NotSupportedException();
        }

        private List<IEntity> LoadEntities() {
            FactStatusDomainDao dto = LoadRelational(RequireDatabasePath());
            var builder = new FactStatusBuilder()
                .OfDocumentEntity(dto.DocumentAggregate)
                .OfSubjectEntityDict(dto.SubjectAggregates)
                .OfAchievementEntityDict(dto.AchievementAggregates)
                .OfEvidenceEntityDict(dto.EvidenceAggregates)
                .OfResultEntityDict(dto.ResultAggregates, dto.ArgumentProperties, dto.AssertionProperties)
                .OfRecordEntityDict(dto.RecordAggregates)
                .OfTodoEntityDict(dto.TodoAggregates)
                .OfSchemaEntityDict(dto.SchemaAggregates)
                .OfGroupEntityDict(dto.GroupAggregates)
                .OfParentLinkDict(dto.ParentEdges)
                .OfChildrenLinkDict(dto.ParentEdges)
                .OfGroupLinkDict(dto.GroupEdges);
            var aggregate = builder.Build();
            return [aggregate.DocumentEntity]
                .Concat(aggregate.SubjectEntityDict.Values)
                .Concat(aggregate.AchievementEntityDict.Values)
                .Concat(aggregate.EvidenceEntityDict.Values)
                .Concat(aggregate.ResultEntityDict.Values)
                .Concat(aggregate.RecordEntityDict.Values)
                .Concat(aggregate.TodoEntityDict.Values)
                .Concat(aggregate.SchemaEntityDict.Values)
                .Concat(aggregate.GroupEntityDict.Values)
                .ToList();
        }

        private PathValue RequireDatabasePath() {
            return _databasePath ?? throw new InvalidOperationException("Initialize を先に呼び出してください。");
        }

        private static string GetSearchText(IEntity entity) {
            switch (entity) {
                case DocumentEntity value: return value.Description;
                case SubjectEntity value: return value.Description;
                case AchievementEntity value: return value.Description;
                case EvidenceEntity value: return value.Description;
                case RecordEntity value: return $"{value.Description} {value.Reviewer}";
                case TodoEntity value: return value.Description;
                case SchemaEntity value: return $"{value.Experience} {value.Evaluation} {value.Hypothesis} {value.AbstractionGoal} {value.ExecutionGoal}";
                default: return entity.Title;
            }
        }
        public IdPatternRulesDao LoadIdPatternRules(PathValue filePath) { throw new NotSupportedException("ID ルールは JSON リポジトリから読み込んでください。"); }

        private static SqliteConnection Open(PathValue filePath) {
            var connection = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = filePath.Path, ForeignKeys = true }.ToString());
            connection.Open();
            return connection;
        }

        private static void EnsureSchema(SqliteConnection connection) {
            Execute(connection, null, """
                CREATE TABLE IF NOT EXISTS schema_info (version INTEGER NOT NULL);
                INSERT INTO schema_info(version) SELECT 1 WHERE NOT EXISTS (SELECT 1 FROM schema_info);
                CREATE TABLE IF NOT EXISTS entities (id TEXT PRIMARY KEY, entity_type INTEGER NOT NULL, path TEXT NOT NULL, title TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS attribute_definitions (id TEXT PRIMARY KEY, name TEXT NOT NULL UNIQUE, value_type TEXT NOT NULL CHECK(value_type IN ('text', 'integer', 'real', 'boolean', 'datetime')));
                CREATE TABLE IF NOT EXISTS entity_text_values (entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, attribute_id TEXT NOT NULL REFERENCES attribute_definitions(id), value TEXT NOT NULL, PRIMARY KEY(entity_id, attribute_id));
                CREATE TABLE IF NOT EXISTS entity_integer_values (entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, attribute_id TEXT NOT NULL REFERENCES attribute_definitions(id), value INTEGER NOT NULL, PRIMARY KEY(entity_id, attribute_id));
                CREATE TABLE IF NOT EXISTS entity_real_values (entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, attribute_id TEXT NOT NULL REFERENCES attribute_definitions(id), value REAL NOT NULL, PRIMARY KEY(entity_id, attribute_id));
                CREATE TABLE IF NOT EXISTS entity_boolean_values (entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, attribute_id TEXT NOT NULL REFERENCES attribute_definitions(id), value INTEGER NOT NULL CHECK(value IN (0, 1)), PRIMARY KEY(entity_id, attribute_id));
                CREATE TABLE IF NOT EXISTS entity_datetime_values (entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, attribute_id TEXT NOT NULL REFERENCES attribute_definitions(id), value TEXT NOT NULL, PRIMARY KEY(entity_id, attribute_id));
                CREATE TABLE IF NOT EXISTS arguments (id TEXT PRIMARY KEY, parent_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, list_index INTEGER NOT NULL, key_index INTEGER NOT NULL, key_name TEXT NOT NULL, data_type INTEGER NOT NULL, text_value TEXT, integer_value INTEGER, real_value REAL, boolean_value INTEGER CHECK(boolean_value IN (0, 1)));
                CREATE TABLE IF NOT EXISTS assertions (id TEXT PRIMARY KEY, parent_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, assert_type INTEGER NOT NULL, target TEXT NOT NULL, data_type INTEGER NOT NULL, text_value TEXT, integer_value INTEGER, real_value REAL, boolean_value INTEGER CHECK(boolean_value IN (0, 1)));
                CREATE TABLE IF NOT EXISTS relations (id TEXT PRIMARY KEY, from_entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, to_entity_id TEXT NOT NULL REFERENCES entities(id) ON DELETE CASCADE, relation_type TEXT NOT NULL CHECK(relation_type IN ('parent', 'group_member')), sequence INTEGER NOT NULL DEFAULT 0, UNIQUE(from_entity_id, to_entity_id, relation_type));
                CREATE INDEX IF NOT EXISTS ix_text_values_attribute_value ON entity_text_values(attribute_id, value);
                CREATE INDEX IF NOT EXISTS ix_boolean_values_attribute_value ON entity_boolean_values(attribute_id, value);
                CREATE INDEX IF NOT EXISTS ix_relations_from_type ON relations(from_entity_id, relation_type);
                CREATE INDEX IF NOT EXISTS ix_relations_to_type ON relations(to_entity_id, relation_type);
                """);
            foreach ((string id, string name, string type) in AttributeDefinitions)
                Execute(connection, null, "INSERT INTO attribute_definitions(id, name, value_type) VALUES ($id, $name, $type) ON CONFLICT(id) DO UPDATE SET name = excluded.name, value_type = excluded.value_type;", ("$id", id), ("$name", name), ("$type", type));
        }

        private static void InsertEntity(SqliteConnection c, SqliteTransaction t, string id, IdTypeEnum type, string path, string title) {
            Execute(c, t, "INSERT INTO entities(id, entity_type, path, title) VALUES ($id, $type, $path, $title);", ("$id", id), ("$type", (int)type), ("$path", path), ("$title", title));
        }
        private static void InsertTextValue(SqliteConnection c, SqliteTransaction t, string id, string attribute, string value) {
            InsertValue(c, t, "entity_text_values", id, attribute, value);
        }
        private static void InsertDateValue(SqliteConnection c, SqliteTransaction t, string id, string attribute, string value) {
            InsertValue(c, t, "entity_datetime_values", id, attribute, value);
        }
        private static void InsertBooleanValue(SqliteConnection c, SqliteTransaction t, string id, string attribute, bool value) {
            InsertValue(c, t, "entity_boolean_values", id, attribute, value ? 1 : 0);
        }
        private static void InsertValue(SqliteConnection c, SqliteTransaction t, string table, string id, string attribute, object value) {
            Execute(c, t, $"INSERT INTO {table}(entity_id, attribute_id, value) SELECT $entityId, id, $value FROM attribute_definitions WHERE name = $attribute;", ("$entityId", id), ("$attribute", attribute), ("$value", value));
        }

        private static void InsertArgument(SqliteConnection c, SqliteTransaction t, ArgumentPropertieJsonDto value) {
            ValueColumns columns = ConvertValue(value.DataType, value.Value);
            Execute(c, t, "INSERT INTO arguments(id, parent_id, list_index, key_index, key_name, data_type, text_value, integer_value, real_value, boolean_value) VALUES ($id, $parent, $list, $key, $name, $type, $text, $integer, $real, $boolean);", ("$id", value.Id), ("$parent", value.ParentId), ("$list", int.Parse(value.ListIndex, CultureInfo.InvariantCulture)), ("$key", int.Parse(value.KeyIndex, CultureInfo.InvariantCulture)), ("$name", value.KeyName), ("$type", (int)Enum.Parse<DataTypeEnum>(value.DataType)), ("$text", columns.Text), ("$integer", columns.Integer), ("$real", columns.Real), ("$boolean", columns.Boolean));
        }

        private static void InsertAssertion(SqliteConnection c, SqliteTransaction t, AssertionPropertieJsonDto value) {
            ValueColumns columns = ConvertValue(value.DataType, value.Value);
            Execute(c, t, "INSERT INTO assertions(id, parent_id, assert_type, target, data_type, text_value, integer_value, real_value, boolean_value) VALUES ($id, $parent, $assert, $target, $type, $text, $integer, $real, $boolean);", ("$id", value.Id), ("$parent", value.ParentId), ("$assert", (int)Enum.Parse<AssertEnum>(value.Assert)), ("$target", value.Target), ("$type", (int)Enum.Parse<DataTypeEnum>(value.DataType)), ("$text", columns.Text), ("$integer", columns.Integer), ("$real", columns.Real), ("$boolean", columns.Boolean));
        }

        private static void InsertRelation(SqliteConnection c, SqliteTransaction t, string id, string from, string to, string type, int sequence) {
            Execute(c, t, "INSERT INTO relations(id, from_entity_id, to_entity_id, relation_type, sequence) VALUES ($id, $from, $to, $type, $sequence);", ("$id", id), ("$from", from), ("$to", to), ("$type", type), ("$sequence", sequence));
        }

        private static List<EntityRow> ReadEntities(SqliteConnection connection) {
            using SqliteCommand command = connection.CreateCommand(); command.CommandText = "SELECT id, entity_type, path, title FROM entities ORDER BY id;";
            using SqliteDataReader reader = command.ExecuteReader(); var values = new List<EntityRow>();
            while (reader.Read()) values.Add(new EntityRow(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3))); return values;
        }

        private static Dictionary<string, Dictionary<string, string>> ReadStringValues(SqliteConnection c, string table) {
            using SqliteCommand command = c.CreateCommand(); command.CommandText = $"SELECT v.entity_id, a.name, v.value FROM {table} v JOIN attribute_definitions a ON a.id = v.attribute_id;";
            using SqliteDataReader reader = command.ExecuteReader(); var values = new Dictionary<string, Dictionary<string, string>>();
            while (reader.Read()) Add(values, reader.GetString(0), reader.GetString(1), reader.GetString(2)); return values;
        }

        private static Dictionary<string, Dictionary<string, int>> ReadBooleanValues(SqliteConnection c) {
            using SqliteCommand command = c.CreateCommand(); command.CommandText = "SELECT v.entity_id, a.name, v.value FROM entity_boolean_values v JOIN attribute_definitions a ON a.id = v.attribute_id;";
            using SqliteDataReader reader = command.ExecuteReader(); var values = new Dictionary<string, Dictionary<string, int>>();
            while (reader.Read()) { string id = reader.GetString(0); if (!values.TryGetValue(id, out Dictionary<string, int>? attributes)) values[id] = attributes = new Dictionary<string, int>(); attributes.Add(reader.GetString(1), reader.GetInt32(2)); } return values;
        }

        private static List<ArgumentPropertieJsonDto> ReadArguments(SqliteConnection c) {
            using SqliteCommand command = c.CreateCommand(); command.CommandText = "SELECT id, parent_id, list_index, key_index, key_name, data_type, text_value, integer_value, real_value, boolean_value FROM arguments ORDER BY parent_id, list_index, key_index, id;";
            using SqliteDataReader reader = command.ExecuteReader(); var values = new List<ArgumentPropertieJsonDto>();
            while (reader.Read()) values.Add(new ArgumentPropertieJsonDto { Id = reader.GetString(0), ParentId = reader.GetString(1), ListIndex = reader.GetInt32(2).ToString(CultureInfo.InvariantCulture), KeyIndex = reader.GetInt32(3).ToString(CultureInfo.InvariantCulture), KeyName = reader.GetString(4), DataType = ((DataTypeEnum)reader.GetInt32(5)).ToString(), Value = ReadTypedValue(reader, 5) }); return values;
        }

        private static List<AssertionPropertieJsonDto> ReadAssertions(SqliteConnection c) {
            using SqliteCommand command = c.CreateCommand(); command.CommandText = "SELECT id, parent_id, assert_type, target, data_type, text_value, integer_value, real_value, boolean_value FROM assertions ORDER BY parent_id, id;";
            using SqliteDataReader reader = command.ExecuteReader(); var values = new List<AssertionPropertieJsonDto>();
            while (reader.Read()) values.Add(new AssertionPropertieJsonDto { Id = reader.GetString(0), ParentId = reader.GetString(1), Assert = ((AssertEnum)reader.GetInt32(2)).ToString(), Target = reader.GetString(3), DataType = ((DataTypeEnum)reader.GetInt32(4)).ToString(), Value = ReadTypedValue(reader, 4) }); return values;
        }

        private static List<RelationRow> ReadRelations(SqliteConnection c, string type) {
            using SqliteCommand command = c.CreateCommand(); command.CommandText = "SELECT id, from_entity_id, to_entity_id, sequence FROM relations WHERE relation_type = $type ORDER BY from_entity_id, sequence, id;"; command.Parameters.AddWithValue("$type", type);
            using SqliteDataReader reader = command.ExecuteReader(); var values = new List<RelationRow>(); while (reader.Read()) values.Add(new RelationRow(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3))); return values;
        }

        private static ValueColumns ConvertValue(string typeText, string value) {
            switch (Enum.Parse<DataTypeEnum>(typeText)) {
                case DataTypeEnum.Int: return new(null, int.Parse(value, CultureInfo.InvariantCulture), null, null);
                case DataTypeEnum.Float: return new(null, null, double.Parse(value, CultureInfo.InvariantCulture), null);
                case DataTypeEnum.Bool: return new(null, null, null, ParseBoolean(value) ? 1 : 0);
                default: return new(value, null, null, null);
            }
        }

        private static string ReadTypedValue(SqliteDataReader reader, int typeColumn) {
            DataTypeEnum type = (DataTypeEnum)reader.GetInt32(typeColumn); int firstValue = typeColumn + 1;
            switch (type) {
                case DataTypeEnum.Int: return reader.IsDBNull(firstValue + 1) ? "" : reader.GetInt32(firstValue + 1).ToString(CultureInfo.InvariantCulture);
                case DataTypeEnum.Float: return reader.IsDBNull(firstValue + 2) ? "" : reader.GetDouble(firstValue + 2).ToString(CultureInfo.InvariantCulture);
                case DataTypeEnum.Bool: return reader.IsDBNull(firstValue + 3) ? "" : reader.GetInt32(firstValue + 3).ToString(CultureInfo.InvariantCulture);
                default: return reader.IsDBNull(firstValue) ? "" : reader.GetString(firstValue);
            }
        }

        private static bool ParseBoolean(string value) {
            return value == "1" || bool.Parse(value);
        }
        private static string GetText(Dictionary<string, Dictionary<string, string>> values, string id, string attribute) {
            return values.TryGetValue(id, out Dictionary<string, string>? attrs) && attrs.TryGetValue(attribute, out string? value) ? value : "";
        }
        private static int GetBoolean(Dictionary<string, Dictionary<string, int>> values, string id, string attribute) {
            return values.TryGetValue(id, out Dictionary<string, int>? attrs) && attrs.TryGetValue(attribute, out int value) ? value : 0;
        }
        private static void Add(Dictionary<string, Dictionary<string, string>> values, string id, string attribute, string value) { if (!values.TryGetValue(id, out Dictionary<string, string>? attrs)) values[id] = attrs = new Dictionary<string, string>(); attrs.Add(attribute, value); }

        private static void Execute(SqliteConnection c, SqliteTransaction? t, string sql, params (string Name, object? Value)[] parameters) {
            using SqliteCommand command = c.CreateCommand(); command.Transaction = t; command.CommandText = sql;
            foreach ((string name, object? value) in parameters) command.Parameters.AddWithValue(name, value ?? DBNull.Value); command.ExecuteNonQuery();
        }

        private sealed record EntityRow(string Id, int Type, string Path, string Title);
        private sealed record RelationRow(string Id, string FromId, string ToId, int Sequence);
        private sealed record ValueColumns(string? Text, int? Integer, double? Real, int? Boolean);
    }
}
