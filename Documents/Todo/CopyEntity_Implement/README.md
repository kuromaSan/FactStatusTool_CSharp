# Entityをコピーの実装

1. `Scripts/FactStatusDomain/Api/Main/FactStatusDomainMain.cs` を開き、既存の namespace とクラス構成を維持する。
1. CopyEntity の string・IdValue・一覧の各オーバーロードから Policy の CopyEntity を呼び、Strategy で複製先の Entity を生成する。
1. 引数、戻り値、Aggregate または DTO の受け渡しを、対象ファイル内の既存メソッドと同じ型で実装する。

---

[Back](../../Achievement/FactStatusDomain_CopyEntity/README.md)

