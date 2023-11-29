using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using itog_proj.Class;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class CitiesWindow : Window
{
    private string _con = "server=sql11.freesqldatabase.com ;database=sql11665362;user=sql11665362;password=25aq3RvR62";
    private List<Cities> _cities;
    private MySqlConnection _connection;
    private List<Route> Route { get; set; }
    public CitiesWindow()
    {
        InitializeComponent();
        ShowTable();
    }

    public void ShowTable()
    {
        string sql =
                "select Id, Name from sql11665362.Cities"
            ;
        _cities = new List<Cities>();
        _connection = new MySqlConnection(_con);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var cities = new Cities()
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
            };
            _cities.Add(cities);
        }
        _connection.Close();
        CitiesDataGrid.ItemsSource = _cities;
        
    }
}