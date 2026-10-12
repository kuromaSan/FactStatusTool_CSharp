# SchemaEntityの作成

1. `Scripts/FactStatusDomain/Internal/Entity/SchemaEntity.cs` に `public class SchemaEntity : IEntity` を置き、基本 3 プロパティと Experience、Evaluation、Hypothesis、AbstractionGoal、ExecutionGoal を追加する。
1. `ChangePathName(string)` は `PathValue.PathIsDirectory(pathName)` を設定し、`ChangeTitle` は null を空文字へ置き換える。
1. `Duplicate` は 5 つの既存テキストを引き継ぐ。`Create` は 5 値に空文字を渡し、`Build` は 5 値を引数としてコンストラクタへ渡す。
1. コンストラクタでタイトルと 5 つのテキスト値をすべて `value ?? ""` の形式で設定する。

---

[Back](../../Achievement/FactStatusDomain_GetEntity/README.md)

