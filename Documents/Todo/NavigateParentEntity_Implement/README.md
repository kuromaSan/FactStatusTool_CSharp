# 親エンティティへ遷移するの実装

1. Scripts/FactStatusDesktop/Surface/Views/MainWindow.axaml の FactStatus.Desktop.Views.MainWindow を編集対象にする。
1. アクティブペイン上部に親階層メニューを追加し、親IDの選択時に親エンティティを表示する。親がない場合は親階層なしを無効表示にする。
1. Scripts/FactStatusDesktop/Surface/ViewModels/MainWindowViewModel.cs の FactStatus.Desktop.ViewModels.MainWindowViewModel に、画面の状態と操作を反映するために必要なプロパティまたは処理を追加する。

---

[Back](../../Achievement/FactStatusDesktop_NavigateParentEntity/README.md)
