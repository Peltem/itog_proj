using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using itog_proj.Class;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class DeleteWindow : Window
{
    private readonly Route _route;
    public DeleteWindow(Route route)
    {
        _route = route;
        InitializeComponent();
    }

    private void Yes_OnClick(object? sender, RoutedEventArgs e)
    {
        string _connString = "server=sql11.freesqldatabase.com ;database=sql11665362;user=sql11665362;password=25aq3RvR62";
        MySqlConnection _connection;
        string sql = "SET FOREIGN_KEY_CHECKS=0;" + "DELETE from Rout WHERE Id = @Id LIMIT 1";
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@Id", MySqlDbType.Int32);
        command.Parameters["@Id"].Value = _route.Id;
        command.ExecuteNonQuery();
        _connection.Close();
        Close(true);
    }
    
    public bool Result { get; private set; }

    private void No_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}