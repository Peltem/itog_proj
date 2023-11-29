using Avalonia.Controls;
using Avalonia.Interactivity;
using itog_proj.Windows;

namespace itog_proj;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LogBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }
}