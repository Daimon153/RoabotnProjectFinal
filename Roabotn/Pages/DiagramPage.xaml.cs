
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Логика взаимодействия для DiagramPage.xaml
    /// </summary>
    public partial class DiagramPage : Page
    {
         Core db = new Core();
        public DiagramPage(Core db, Worker currentWorker)
        {
            InitializeComponent();
            this.DataContext = currentWorker;
            this.db = db;
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Выполненные задачи за год",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountCompleteTaskYear) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Ожидаемые задачи за год",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountForthcomingTaskYear) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Просроченные задачи за год",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(currentWorker.CountFailedTaskYear) },
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

        private void DiagramView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

        private void TaskMonth_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void TaskYear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
           // MessageBox.Show("Current value: " + chartPoint.Y + "(" + (chartPoint.Participation * 100).ToString() + "%");
        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
