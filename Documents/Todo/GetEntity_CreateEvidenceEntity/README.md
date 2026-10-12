# EvidenceEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/EvidenceEntity.cs` に `public class EvidenceEntity : IEntity` を置き、基本 4 プロパティと `BoolValue Success` を追加する。
1. `ChangePathName(PathValue)` は直接代入し、string 版は `PathValue.PathIsDirectory(pathName)` を代入する。タイトル・説明の変更は null を空文字へ置き換える。
1. `ChangeSuccess(bool)` は `new BoolValue(success)`、int 版は `BoolValue.FromInt(success)`、string 版は `BoolValue.FromString(success)` を Success へ代入する。
1. `Duplicate` は現在の Title、Description、Success を引き継ぐ。`Create` は空説明と `BoolValue.IsTrue()`、`Build` は指定された BoolValue を渡す。
1. コンストラクタで ID、パス、タイトル、説明、Success をこの順に設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

