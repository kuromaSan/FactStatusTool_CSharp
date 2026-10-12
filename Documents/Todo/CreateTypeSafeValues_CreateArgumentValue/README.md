# ArgumentValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/ArgumentValue.cs` に Id、ParentId、ListIndex、KeyIndex、KeyName、DataType、Value の 7 プロパティを持つ `ArgumentValue` を作成する。
1. `Create` は 2 つの ID、0、0、空文字、`DataTypeEnum.None`、空文字を渡す。`Build` は 7 値すべてをコンストラクタへ渡す。
1. コンストラクタで ListIndex と KeyIndex に `Validation.MinusOneOrLessOfInt`、KeyName に `Validation.NullOfString` を実行する。
1. Value は null を空文字へ置き換え、残りの値を各プロパティへ設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

