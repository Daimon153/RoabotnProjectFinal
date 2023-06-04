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
    /// Логика взаимодействия для CurrentTasksPage.xaml
    /// </summary>
    public partial class CurrentTasksPage : Page
    {
        Core db;
        List<TaskWorker> taskArray;
        public CurrentTasksPage(Core db, Worker currentWorker)
        {
            InitializeComponent();
            this.DataContext = currentWorker;
            this.db = db;
            taskArray = db.context.TaskWorker.Where(x=>x.Worker.IdWorker== currentWorker.IdWorker).ToList();
            CurrentTasksListView.ItemsSource = taskArray;
        }

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

        private void CurrentTasksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            Core dbnew=new Core();
            Button activeButton= sender as Button;
            TaskWorker activeWorker = activeButton.DataContext as TaskWorker;
            Console.WriteLine(activeWorker.IdTasks);
            Tasks activeTask = dbnew.context.Tasks.FirstOrDefault(x => x.IdTasks == activeWorker.IdTasks);
            if (activeTask != null)
            {
                activeTask.IdTaskStatus = 1;
                dbnew.context.SaveChanges();

            }
           
        }

        private void Diagramm_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Worker activeWorker = activeButton.DataContext as Worker;
            this.NavigationService.Navigate(new DiagramPage(db,activeWorker));

        }

        private void DiagrammMouth_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Worker activeWorker = activeButton.DataContext as Worker;
            this.NavigationService.Navigate(new DiagramMouthPage(db, activeWorker));

        }
    }
}
