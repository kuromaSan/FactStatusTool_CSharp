# 各エンティティ一覧を取得
## 実装内容
`FactStatusDomainMain` で管理対象の全エンティティを各タイプ一覧で分けて取得する。

## 実装証拠
[各エンティティ一覧を取得ができること](../../Evidence/GetAllEntityList_Verify/README.md)  
[エンティティ一覧が未設定ならエラーになること](../../Evidence/GetAllEntityList_Error/README.md)  

## 実装手順
[各エンティティ一覧を取得の実装](../../Todo/GetAllEntityList_Implement/README.md)  

## 実装構想
[リポジトリで ID 種別から Entity の一覧を取得する（`GetEntityList`）](../../Achievement/FactStatusDomain_GetEntitiesByIdType/README.md)  
[SQLiteからDictionary`<IdTypeEnum, List<IEntity>>`に変換するためのDto](../../Achievement/FactStatusDomain_/README.md)  

---
[Back](../../Subject/Documents_FactStatusDomain/README.md)
