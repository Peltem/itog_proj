using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class LoginWindow : Window
{
    private MySqlConnection _connection;
    private string _con = "server=10.10.1.24;database=pro1_1;user=user_01;password=user01pro";

    public LoginWindow()
    {
        InitializeComponent();
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void LoginButton_OnClick(object? sender, RoutedEventArgs e)
    {

        MySqlConnection _connection;
        string sql = "SELECT Login, Password from pro1_8.AdminTools WHERE Login = @login and Password = @password";
        _connection = new MySqlConnection(_con);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginTextBox.Text;
        var login = command.Parameters["@login"].Value;
        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text;
        var password = command.Parameters["@password"].Value;
        var reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            if(LoginTextBox.Text.Equals(login) && PasswordTextBox.Text.Equals(password))
            {
                RoutWindow routWindow = new RoutWindow();
                routWindow.Show();
                this.Close();
            }
        }
    }

    private void HidePasswordCheckBox_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if(PasswordTextBox.PasswordChar == (char)0)
        {
            PasswordTextBox.PasswordChar = '•';
        }
        else
        {
            PasswordTextBox.PasswordChar = (char)0;
        }

   
    }
}
