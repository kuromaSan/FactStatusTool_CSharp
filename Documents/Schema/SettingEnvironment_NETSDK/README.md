# .NET SDKに関して

## 体験

FactStatusTool のドメイン、デスクトップUI、およびテストプロジェクトは `net8.0` を対象としている。

## 評価

ビルドとテストには、対象フレームワークに対応する .NET SDK が必要である。

## 仮説

使用する SDK のバージョンを `global.json` で統一すれば、開発環境ごとの差異を抑えられる。

## 抽象目標

すべての開発者が同じ条件でソリューションをビルド・テストできるようにする。

## 実行目標

.NET 8 SDK をインストールし、`global.json` で指定された SDK を使用する。

---

[Back](../../Subject/Documents_SettingEnvironment/README.md)  
