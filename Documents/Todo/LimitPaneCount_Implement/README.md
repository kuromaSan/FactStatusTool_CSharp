# 分割ペイン数を制限するの実装

1. Scripts/FactStatusDesktop/Surface/Views/MainWindow.axaml の FactStatus.Desktop.Views.MainWindow を編集対象にする。
1. 右分割と下分割の操作前に表示中のペイン数を判定し、初期実装では最大4ペインを目安に新しいペインの作成を制限する。
1. Scripts/FactStatusDesktop/Surface/ViewModels/MainWindowViewModel.cs の FactStatus.Desktop.ViewModels.MainWindowViewModel に、画面の状態と操作を反映するために必要なプロパティまたは処理を追加する。

---

[Back](../../Achievement/FactStatusDesktop_LimitPaneCount/README.md)
