# AssertionValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/AssertionValue.cs` に Id、ParentId、Assert、Target、DataType、Value の 6 プロパティを持つ `AssertionValue` を作成する。
1. `Create` は `AssertEnum.None`、空 Target、`DataTypeEnum.None`、空 Value を渡す。`Build` は 6 値すべてをコンストラクタへ渡す。
1. コンストラクタで Target に `Validation.NullOfString` を実行し、Value は null を空文字へ置き換える。
1. Id、ParentId、Assert、Target、DataType、Value を対応するプロパティへ設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

