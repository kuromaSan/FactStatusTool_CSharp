using System.Configuration;
using System.Data;
using System.Windows;

namespace Scripts.Interface;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        // Temporary startup confirmation
        System.Windows.MessageBox.Show("App.OnStartup reached");
        base.OnStartup(e);
    }
}




