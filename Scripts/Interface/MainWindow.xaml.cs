using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;

namespace Scripts.Interface;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BrowseRelationalJson_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new System.Windows.Forms.OpenFileDialog();
        dlg.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
        var result = dlg.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            RelationalJsonPathTextBox.Text = dlg.FileName;
        }
    }

    private void BrowseMarkdownOutput_Click(object sender, RoutedEventArgs e)
    {
        // Use FolderBrowserDialog from WinForms
        using var dlg = new System.Windows.Forms.FolderBrowserDialog();
        var result = dlg.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            MarkdownOutputPathTextBox.Text = dlg.SelectedPath;
        }
    }

    private void ConvertButton_Click(object sender, RoutedEventArgs e)
    {
        string jsonPath = RelationalJsonPathTextBox.Text ?? string.Empty;
        string markdownRoot = MarkdownOutputPathTextBox.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(jsonPath) || string.IsNullOrWhiteSpace(markdownRoot))
        {
            System.Windows.MessageBox.Show("JsonパスとMarkdown出力先を指定してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            // load relational json -> FactStatusConfig
            var jsonRepo = new JsonRepository();
            var markdownRepo = new MarkdownRepository();
            var strategy = new FactStatusStrategy(jsonRepo, markdownRepo);
            var policy = new FactStatusPolicy(strategy);

            FactStatusConfig config = policy.LoadJsonByRelational(jsonPath);

            // build markdown dto list
            var builder = new MarkdownDtoBuilder();
            var markdownDto = builder.OfFactStatusConfig(config).ListBuild();

            // save markdown files
            markdownRepo.SaveMarkdownByRoot(markdownRoot, markdownDto);

            System.Windows.MessageBox.Show("変換が完了しました。", "完了", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (System.Exception ex)
        {
            System.Windows.MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}