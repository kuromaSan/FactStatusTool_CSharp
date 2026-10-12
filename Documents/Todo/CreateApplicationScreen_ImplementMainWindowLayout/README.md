# 基本画面の実装

1. `Scripts/FactStatusDesktop/Surface/Views/MainWindow.axaml` の `FactStatus.Desktop.Views` 名前空間の `MainWindow` で、`Greeting` にバインドしている単一の `TextBlock` を削除する。
1. 同じ `MainWindow` のコンテンツに、左サイドバー用の領域と中央メインUI用の領域を横並びに配置するレイアウトコンテナを追加する。左側はサイドバーを実装するタスクが内容を配置できる領域とし、右側は中央メインUIの領域とする。
1. 中央メインUIの領域に、選択対象がない初期状態で読込方法または対象の選択を案内する空状態の表示を追加する。
1. `Scripts/FactStatusDesktop/Surface/ViewModels/MainWindowViewModel.cs` の `FactStatus.Desktop.ViewModels.MainWindowViewModel` から、削除したバインドに対応する `public string Greeting { get; } = "Welcome to Avalonia!";` を削除する。

---

[Back](../../Achievement/FactStatusDesktop_CreateApplicationScreen/README.md)
