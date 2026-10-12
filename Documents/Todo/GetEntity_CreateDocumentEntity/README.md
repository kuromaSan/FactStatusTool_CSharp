# DocumentEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/DocumentEntity.cs` を作成し、先頭に `using FactStatus.Domain.Internal.Value;`、`using System.Collections.Generic;` を記載する。namespace は `FactStatus.Domain.Internal.Entity` とする。
1. namespace 内に `public class DocumentEntity : IEntity` を宣言する。
1. クラス直下に、次の 5 プロパティをこの型とアクセサで追加する。`public IdValue Id { get; }`、`public PathValue PathName { get; private set; }`、`public string Title { get; private set; }`、`public string Description { get; private set; }`、`public Dictionary<IdValue, IEntity> SubjectEntityDict { get; private set; }`。
1. `private void ChangePathName(string pathName)` を追加し、メソッド本体を `PathName = PathValue.PathIsDirectory(pathName);` の 1 行にする。
1. `private void ChangeTitle(string title)` を追加し、メソッド本体を `Title = title;` の 1 行にする。
1. `public void ChangeDiscription(string description)` を追加する。メソッド名は既存仕様どおり `Discription` と綴り、メソッド本体を `Description = description ?? "";` の 1 行にする。
1. `public void AddSubjectEntity(IEntity subjectEntity)` を追加する。`subjectEntity == null` のときは何もせず `return;` し、それ以外では `SubjectEntityDict[subjectEntity.Id] = subjectEntity;` を実行する。
1. `public void DeleteSubjectEntity(IdValue subjectIdValue)` を追加し、メソッド本体を `SubjectEntityDict.Remove(subjectIdValue);` の 1 行にする。
1. `public static DocumentEntity Create()` を追加し、`return new DocumentEntity("", new Dictionary<IdValue, IEntity>());` を返す。
1. `public static DocumentEntity Build(string description, Dictionary<IdValue, IEntity> subjectEntityDict)` を追加し、`return new DocumentEntity(description, subjectEntityDict);` を返す。
1. `public DocumentEntity(string description, Dictionary<IdValue, IEntity> subjectEntityDict)` コンストラクタを追加する。
1. コンストラクタ内で `Id = new IdValue("00010001");`、`PathName = new PathValue("Documents", PathTypeEnum.Directory);`、`Title = "ドキュメント";` をこの順で設定する。
1. 続けてコンストラクタ内で `Description = description ?? "";`、`SubjectEntityDict = subjectEntityDict ?? new Dictionary<IdValue, IEntity>();` を設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

