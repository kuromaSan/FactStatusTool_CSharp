# 指定したエンティティを更新
## 実装内容
`FactStatusDomainMain`でContractを設定してEntity変換してから更新する。

## 実装証拠
[指定したエンティティを更新ができること](../../Evidence/UpdateEntityByAttributeId_Verify/README.md)  
[指定したエンティティが無ければエラーになること](../../Evidence/UpdateEntityByAttributeId_Error/README.md)  

## 実装手順
[指定したエンティティを更新の実装](../../Todo/UpdateEntityByAttributeId_Implement/README.md)  

## 実装構想
[UIからの内容を更新する必要がある](../../Schema/UpdateEntityByAttributeId_/README.md)  
[DtoとEntityを使い分ける理由](../../Schema/UpdateEntityByAttributeId_/README.md)  
[リポジトリで属性 ID を基準に Entity を更新する（`UpdateByAttributeId`）](../../Achievement/FactStatusDomain_UpdateEntityByAttributeId/README.md)  
[`UpdateEntityRequestDto` を追加し、UI からの属性更新要求を Entity ではなく Contract で受け取る](../..//FactStatusDomain/Api/Contract/)

---
[Back](../../Subject/Documents_FactStatusDomain/README.md)
