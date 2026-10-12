# Validationの作成

1. Scripts/FactStatusDomain/Internal/Rule/Validation.cs に internal static class Validation を配置する。
1. 文字列、数値、bool 変換、Enum、日時、パス、辞書、Entity 辞書を対象とする public static の検証メソッドを追加する。
1. 失敗時は ValidationMessages.Get(ValidationErrorCode...) で取得したメッセージを含む ArgumentException または KeyNotFoundException を送出する。
1. 同ファイル内の ValidationMessages と ValidationErrorCode へ、各検証メソッドに対応するエラーコードとメッセージを追加する。

---

[Back](../../Achievement/FactStatusDomain_CreateValidationRules/README.md)

