# エンティティ・アトリビュート・リレーションの3つのテーブル

## 体験

FactStatus のデータには、主題や証拠などのエンティティ、その属性、エンティティ間の親子・グループ関係がある。

## 評価

エンティティ、属性、リレーションを同じ構造で管理すると、種別ごとの属性制約や関連付けの規則を検証しにくい。

## 仮説

エンティティ・アトリビュート・リレーションを3つのテーブルとして分ければ、各データの責務と関係の制約を明確にできる。

## 抽象目標

FactStatus のデータを一貫した規則で保存・読込・検証できるようにする。

## 実行目標

`IDPatternRules.json` の `entityTypes`、`attributeTypes`、`edgeTypes`、`valueTypes` を基に、エンティティ種別、属性の対象、親子・グループ関係、`ValueTypes`（`string`、`bool`）を分けて管理する。

---

[Back](../../Subject/Documents_FactStatusDomain/README.md)  
