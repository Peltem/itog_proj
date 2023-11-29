using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using itog_proj.Class;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class DriverWindow : Window
{
   
    private string _con = "server=sql11.freesqldatabase.com ;database=sql11665362;user=sql11665362;password=25aq3RvR62";
    private List<Driver> _drivers;
    private MySqlConnection _connection;
    public DriverWindow()
    {
        InitializeComponent();
        ShowTable();
    }

    public void ShowTable()
    {
        string sql =
                "select Id, Name, Lastname, Number from sql11665362.Driver"
            ;
        _drivers = new List<Driver>();
        _connection = new MySqlConnection(_con);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var driver = new Driver()
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Lastname = reader.GetString("Lastname"),
                Number = reader.GetInt32("Number")
            };
            _drivers.Add(driver);
        }
        _connection.Close();
        DriverDataGrid.ItemsSource = _drivers;
        
    }
}