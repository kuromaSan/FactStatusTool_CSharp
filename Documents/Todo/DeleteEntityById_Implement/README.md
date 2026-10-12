# IDからEntityを削除の実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. DeleteEntity の string・IdValue・一覧の各オーバーロードから Policy の DeleteEntity または DeleteEntityList を呼ぶ。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_DeleteEntityById/README.md)

