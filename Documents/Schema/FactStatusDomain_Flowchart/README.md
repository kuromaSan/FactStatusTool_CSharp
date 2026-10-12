# フローチャート

## 体験

FactStatus では、主題から実装・証拠・結果・記録へと確認の流れがあり、手順と構想も関連付けて扱う。

## 評価

親子関係と補助的な関連を文章だけで示すと、各要素がどこに位置するかを把握しにくい。

## 仮説

主要な流れと、手順・構想の関連先を図形で示せば、データ構造と追跡の流れを理解しやすくなる。

## 抽象目標

主題から確認記録までの流れと、手順・構想との関係を一目で確認できるようにする。

## 実行目標

主要な親子関係と、手順・構想の関連先、および `FactStatusMain` からの処理の流れを次の図形で表す。

```text
Document
  └─ Subject
       ├─ Schema
       └─ Achievement
            ├─ Todo
            ├─ Schema
            └─ Evidence
                 ├─ Todo
                 ├─ Schema
                 └─ Result
                      └─ Record
```

### FactStatusMain からの処理フロー

`FactStatusCrafter` は `FactStatusRepository`、`JsonRepository`、`MarkdownRepository` を `FactStatusStrategy` に渡し、その Strategy を使う `FactStatusPolicy` と初期の `FactStatusAggregate` を `FactStatusMain` に渡して生成する。

```text
FactStatusCrafter
  DI(
    FactStatusAggregate,
    FactStatusPolicy,
    FactStatusStrategy,
    FactStatusRepository,
    JsonRepository,
    MarkdownRepository
  )
  Build(FactStatusMain)

FactStatusMain
  FactStatusAggregate 選択ID・読込パス・保存パスを保持
  Subを取得 FactStatusPolicy → FactStatusStrategy → Aggregate 内のエンティティを返す
  
  ├─ 作成・削除・移動・複製・グループ化
  │    └─ FactStatusPolicy（引数・型の検証）
  │         → FactStatusStrategy（ID生成、エンティティ／リンク操作）
  │         → 更新された FactStatusAggregate
  │         → FactStatusMain が Aggregate を差し替える
  └─ 読込・保存
       ├─ リレーショナル / JSON
       │    └─ FactStatusPolicy（PathValueへ変換）
       │         → FactStatusStrategy（DTO と Aggregate を相互変換）
       │         → FactStatusRepository / JsonRepository（ファイル入出力）
       │         → 読込時は FactStatusMain が Aggregate を差し替える
       └─ Markdown
            └─ 現在の Policy は PathValue の生成までで、
               Strategy / MarkdownRepository への委譲は未実装
```

DomainとDeskTopまでのデータ受け渡しフロー
```text
IFactStatusDomainRepository(FactStatusDomainIRepository)
↕
FactStatusDomainDto
↕
FactStatusDomainStrategy
↕
FactStatusDomainAggregate(FactStatusDomain_Entity)
↕
FactStatusDomainPolicy
↕
FactStatusDomainMain(FactStatusDomain_Sub)
↕
FactStatusDesktopMain(FactStatusDesktop_Sub)
↕
Avalonia
```

---

[Back](../../Subject/Documents_FactStatusDomain/README.md)  
