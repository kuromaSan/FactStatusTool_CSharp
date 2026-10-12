# AddValueの作成

1. `Scripts/FactStatusDomain/Internal/Value/AddValue.cs` に PathName、Title、IdType、DestinationId を getter のみで持つ `public sealed class AddValue` を作成する。
1. `FromString(pathName, title, idType, destinationId)` で pathName、idType、destinationId の null チェックを行う。
1. `PathValue.PathIsDirectory(pathName)`、`Validation.StringToEnum<IdTypeEnum>(idType)`、`IdValue.FromString(destinationId)` を生成してコンストラクタへ渡す。
1. コンストラクタで title の null チェックを行い、4 引数を対応するプロパティへ設定する。

---

[Back](../../Achievement/FactStatusDomain_CreateTypeSafeValues/README.md)

