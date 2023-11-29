using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using itog_proj.Class;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class RoutWindow : Window
{
    private string _con = "server=sql11.freesqldatabase.com ;database=sql11665362;user=sql11665362;password=25aq3RvR62";
    private List<Route> _routes;
    private MySqlConnection _connection;
    private List<Route> Route { get; set; }
    public RoutWindow()
    {
        InitializeComponent();
        ShowTable();
    }

    public void ShowTable()
    {
        string sql =
                "select Id, Name, Start, Finish, Driver, Car from sql11665362.Rout"
            ;
        _routes = new List<Route>();
        _connection = new MySqlConnection(_con);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var route = new Route()
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Start = reader.GetInt32("Start"),
                Finish = reader.GetInt32("Finish"),
                Driver = reader.GetInt32("Driver"),
                Car = reader.GetInt32("Car")
            };
            _routes.Add(route);
        }
        _connection.Close();
        RouteDataGrid.ItemsSource = _routes;
        
    }
   
    private void Delet_btn_OnClick(object? sender, RoutedEventArgs e)
    {
        var myValuee = ((Button)sender).Tag as Route;
        DeleteWindow deleteWindow = new DeleteWindow(myValuee);
        deleteWindow.ShowDialog(this);
        deleteWindow.Closed += (o, args) => {
            if (deleteWindow.Result) {
                ShowTable();
            }
        };
    }
    private void SerchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        List<Route> routeList = Route.Where(x =>
            x.Id.ToString() == SerchBox.Text ||
            x.Name.Contains(SerchBox.Text, StringComparison.OrdinalIgnoreCase) ||
            x.Start.ToString() == SerchBox.Text ||
            x.Finish.ToString() == SerchBox.Text ||
            x.Driver.ToString() == SerchBox.Text ||
            x.Car.ToString() == SerchBox.Text).ToList();
        RouteDataGrid.ItemsSource = routeList;
        if (SerchBox.Text == "")
        {
            ShowTable();
        }
    }

    private void CarOpen_btn_OnClick(object? sender, RoutedEventArgs e)
    {
        CarWindow carWindow = new CarWindow();
        carWindow.Show();
        this.Close();
    }

    private void Driver_Btn_OnClick(object? sender, RoutedEventArgs e)
    {
        DriverWindow driverWindow = new DriverWindow();
        driverWindow.Show();
        this.Close();
    }

    private void Cities_btn_OnClick(object? sender, RoutedEventArgs e)
    {
        CitiesWindow citiesWindow = new CitiesWindow();
        citiesWindow.Show();
        this.Close();
    }
}