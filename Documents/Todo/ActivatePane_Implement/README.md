# アクティブペインを切り替えるの実装

1. Scripts/FactStatusDesktop/Surface/Views/MainWindow.axaml の FactStatus.Desktop.Views.MainWindow を編集対象にする。
1. ペイン操作時に最後に操作したペインをアクティブとして保持し、読込、書き込み可能切替、選択、親階層移動、分割の対象にする。
1. Scripts/FactStatusDesktop/Surface/ViewModels/MainWindowViewModel.cs の FactStatus.Desktop.ViewModels.MainWindowViewModel に、画面の状態と操作を反映するために必要なプロパティまたは処理を追加する。

---

[Back](../../Achievement/FactStatusDesktop_ActivatePane/README.md)
