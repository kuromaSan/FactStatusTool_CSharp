# BoolValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/BoolValue.cs` に `public sealed class BoolValue` と `public bool Value { get; private set; }` を追加する。
1. `IntgerToBoolDict` に 1/true と 0/false を、`StringToBoolDict` に 1、0、true、false を大文字小文字を区別しない辞書で定義する。
1. `ToInt`、`ToStringUppercase`、`ToStringLowercase`、`ToStringOfNumber` を追加し、Value から各形式の値を返す。
1. `FromBool`、`FromInt`、`FromString`、`IsTrue`、`IsFalse` を追加する。int と string の変換前には対応する Validation を実行する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

