using Roabotn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Charts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Definitions.Series;
using LiveCharts.Dtos;
using LiveCharts.Events;
using LiveCharts.Helpers;
using LiveCharts.Wpf.Components;
using LiveCharts.Wpf.Points;
namespace Roabotn.Pages
{
    /// <summary>
    /// Логика взаимодействия для DiagramMouthPage.xaml
    /// </summary>
    public partial class DiagramMouthPage : Page
    {
        Core db;
        public DiagramMouthPage(Core db, Worker currentWorker)
        {
            InitializeComponent();
            this.DataContext = currentWorker;
            this.db = db;
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Выполненные задачи за месяц",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountCompleteTaskMounth) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Ожидаемые задачи за месяц",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountForthcomingTaskMounth) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Просроченные задачи за месяц",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountFailedTaskMounth) },
                    DataLabels = true
                },

            };
            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser.IdStatus == 1)
            {
                this.NavigationService.Navigate(new AdminPage());
                Console.WriteLine(App.CurrentUser.IdStatus);
            }
            if (App.CurrentUser.IdStatus == 2)
            {
                this.NavigationService.Navigate(new AdminPage());
                Console.WriteLine(App.CurrentUser.IdStatus);
            }
            if (App.CurrentUser.IdStatus == 3)
            {
                this.NavigationService.Navigate(new DepartPage());
                Console.WriteLine(App.CurrentUser.IdStatus);

            }
        }

        private void PieChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {
            // MessageBox.Show("Current value: " + chartPoint.Y + "(" + (chartPoint.Participation * 100).ToString() + "%");

        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
