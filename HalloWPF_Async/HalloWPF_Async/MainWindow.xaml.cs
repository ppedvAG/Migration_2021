using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HalloWPF_Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            Task.Run(() =>
            {

                for (int i = 0; i <= 100; i++)
                {
                    this.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(20);
                }
                MessageBox.Show("Fertig");
                this.Dispatcher.Invoke(() => ((Button)sender).IsEnabled = !false);
            })
                .ContinueWith(t => MessageBox.Show($"Error{t.Exception.InnerException.Message}"),
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnFaulted,
                TaskScheduler.Default);

        }

        private async void StartAsync(object sender, RoutedEventArgs e)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true;";

            var con = new SqlConnection(conString);

            try
            {
                await con.OpenAsync();
                MessageBox.Show("DB ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Schade {ex.Message}");
            }

        }

        private void StartVoll(object sender, RoutedEventArgs e)
        {
            List<Person> personen = new List<Person>();
            while (true)
                personen.Add(new Person() { Name = $"Fred {Guid.NewGuid()}" });
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
    }
}
