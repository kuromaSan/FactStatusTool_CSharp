# FactStatusTool

[ドキュメント](./Documents/README.md)

## 開発環境

### 必要なもの

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 以降（`global.json` で SDK 8 以上を要求）
- UI 開発時: [JetBrains Rider](https://www.jetbrains.com/rider/) と [Avalonia for Rider](https://plugins.jetbrains.com/plugin/14839-avalonia) プラグイン

### JetBrains Rider

1. `FactStatusTool.sln` を Rider で開く
2. 初回は NuGet パッケージの復元とインデックス作成が走る
3. 右上の Run Configuration から次のいずれかを選んで実行する
   - **FactStatus.Desktop** — Avalonia デスクトップアプリ
   - **FactStatus.Domain.Test** — ドメインの xUnit テスト一式
   - **FactStatus.Desktop.Test** — デスクトップUIの xUnit テスト一式

Run Configuration はリポジトリ直下の [`.run/`](./.run/) に共有設定として置いてある。Rider が自動で読み込む。

### コマンドライン

```powershell
# ビルド
dotnet build FactStatusTool.sln

# テスト
dotnet test FactStatusTool.sln

# UI 起動（リポジトリルートを作業ディレクトリにする）
dotnet run --project Scripts/FactStatusDesktop/FactStatus.Desktop.csproj
```

### ソリューション構成

| プロジェクト | パス | 説明 |
|---|---|---|
| FactStatus.Domain | `Scripts/FactStatusDomain/` | ドメインロジック |
| FactStatus.Desktop | `Scripts/FactStatusDesktop/` | Avalonia デスクトップUI |
| FactStatus.Domain.Test | `Tests/FactStatusDomainTest/` | ドメインの xUnit テスト |
| FactStatus.Desktop.Test | `Tests/FactStatusDesktopTest/` | デスクトップUIの xUnit テスト |
