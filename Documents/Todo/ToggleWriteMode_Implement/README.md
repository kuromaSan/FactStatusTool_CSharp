# 書き込み可能モードを切り替えるの実装

1. Scripts/FactStatusDesktop/Surface/Views/MainWindow.axaml の FactStatus.Desktop.Views.MainWindow を編集対象にする。
1. 各ペイン上部に現在の状態が分かる切替操作を追加し、読み取り専用では編集項目と保存操作を無効にする。
1. Scripts/FactStatusDesktop/Surface/ViewModels/MainWindowViewModel.cs の FactStatus.Desktop.ViewModels.MainWindowViewModel に、画面の状態と操作を反映するために必要なプロパティまたは処理を追加する。

---

[Back](../../Achievement/FactStatusDesktop_ToggleWriteMode/README.md)
