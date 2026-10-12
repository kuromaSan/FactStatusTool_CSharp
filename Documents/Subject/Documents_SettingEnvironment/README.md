# 環境構築
## 企画内容
FactStatusTool をローカルでビルド・テスト・起動できる開発環境をそろえる。
- OS: Windows 10 / 11
- SDK: .NET 8 SDK
- リポジトリ直下の `global.json` により、SDK は `8.0.0` 以降（`latestMajor`）を使用する。
- デスクトップUI開発には JetBrains Rider + Avalonia for Rider、または Visual Studio / VS Code を利用できる。
- DB SQLite

## 企画実装
[.NET 8 SDKのインストール](../../Achievement/SettingEnvironment_InstallDotNET8SDK/README.md)  
[ディレクトリの作成](../../Achievement/SettingEnvironment_CreateDirectory/README.md)  
[依存パッケージの復元とソリューションのビルド](../../Achievement/SettingEnvironment_RestoreAndBuild/README.md)  
[テストの実行](../../Achievement/SettingEnvironment_RunTests/README.md)  
[デスクトップUIの起動](../../Achievement/SettingEnvironment_RunDesktopUI/README.md)  
[Avaloniaの設定](../../Achievement/SettingEnvironment_ConfigureAvalonia/README.md)  
[xUnitの設定](../../Achievement/SettingEnvironment_ConfigureXUnit/README.md)  

## 企画構想
[OSに関して](../../Schema/SettingEnvironment_OS/README.md)  
[.NET SDKに関して](../../Schema/SettingEnvironment_NETSDK/README.md)  
[デスクトップUI Avaloniaに関して](../../Schema/SettingEnvironment_DesktopUIAvalonia/README.md)  
[データベースSQLiteの使用理由](../../Schema/SettingEnvironment_SQLite/README.md)  

---

[Back](../../README.md)
