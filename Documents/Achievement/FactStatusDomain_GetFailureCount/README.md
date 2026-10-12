# 失敗数を取得
## 実装内容
`FactStatusDomainMain` で失敗状態の件数を取得する。

## 実装証拠
[失敗数を取得ができること](../../Evidence/GetFailureCount_Verify/README.md)  
[集計対象のAggregateが未設定ならエラーになること](../../Evidence/GetFailureCount_Error/README.md)  

## 実装手順
[失敗数を取得の実装](../../Todo/GetFailureCount_Implement/README.md)  

## 実装構想
[リポジトリで NG 状態の Entity の件数を取得する（`NGCount`）](../../Achievement/FactStatusDomain_CountNGEntities/README.md)
[`OperationResultDto` を追加し、更新・保存の成功／失敗とエラー内容を Contract として返す](../..//FactStatusDomain/Api/Contract/)

---
[Back](../../Subject/Documents_FactStatusDomain/README.md)
