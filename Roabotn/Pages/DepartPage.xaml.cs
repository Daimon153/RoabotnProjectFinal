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

namespace Roabotn.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartPage.xaml
    /// </summary>
    public partial class DepartPage : Page
    {
        Core db = new Core();
        List<Worker> workers;
        public DepartPage()
        {
            InitializeComponent();
            workers = db.context.Worker.ToList();
           List<Worker>  arrUser=db.context.Worker.Where(x => x.IdDepartment == App.CurrentUser.IdDepartment).ToList();
            WorkedListView.ItemsSource = arrUser;

        }

        private void Rasp_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Worker activeWorker = activeButton.DataContext as Worker;
            this.NavigationService.Navigate(new DistributionPage(db, activeWorker));
        }

        private void currenttusk_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Worker activeWorker = activeButton.DataContext as Worker;
            this.NavigationService.Navigate(new CurrentTasksPage(db, activeWorker));
        }

        private void WorkedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            WorkedListView.ItemsSource = db.context.Worker.Where(x => x.lastname.Contains(SearchBox.Text)).ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TasksPage());
        }
    }
}
