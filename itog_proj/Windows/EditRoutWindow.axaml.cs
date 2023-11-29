using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using itog_proj.Class;
using MySql.Data.MySqlClient;

namespace itog_proj.Windows;

public partial class EditRoutWindow : Window
{
    private readonly Route _route;
    public EditRoutWindow(Route route)
    {
        _route = route;
        InitializeComponent();
    }

    private void Save_btn_OnClick(object? sender, RoutedEventArgs e)
    {
            string _conn = "server=sql11.freesqldatabase.com ;database=sql11665362;user=sql11665362;password=25aq3RvR62";
            List<Route> _routes ;
            MySqlConnection _connection;
            _routes = new List<Route>();
            _connection = new MySqlConnection(_conn);
            _connection.Open();
            var cmd = new MySqlCommand("UPDATE Rout SET Name = @TxtName, Start = @NewStart, Finish = @NewFinish, Driver = @NewDriver, Car = @NewCar");
            cmd.Parameters.AddWithValue("@TxtName", TxtName.Text);
            cmd.Parameters.AddWithValue("@NewStart", NewStart.Text);
            cmd.Parameters.AddWithValue("@NewFinish", NewFinish.Text);
            cmd.Parameters.AddWithValue("@NewDriver", NewDriver.Text);
            cmd.Parameters.AddWithValue("@NewCar", NewCar.Text);
            cmd.ExecuteNonQuery();
    }
}