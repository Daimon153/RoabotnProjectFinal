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
    /// Логика взаимодействия для DistributionPage.xaml
    /// </summary>
    public partial class DistributionPage : Page
    {
        Core db;
            List<Tasks> tasks;
        Worker activeWorker;
        
        public DistributionPage(Core db, Worker currentWorker)
        {
            InitializeComponent();
            this.DataContext = currentWorker;
            this.db = db;
            
            tasks = db.context.Tasks.Where(x=>x.IdTaskStatus==2).ToList();
            DistributionListView.ItemsSource = tasks;
            activeWorker = currentWorker;
            
        }

        private void backMain_Click(object sender, RoutedEventArgs e)
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
            //try
            //{
            //    switch (App.CurrentUser.IdStatus)
            //    {

            //        case 1:
            //            this.NavigationService.Navigate(new AdminPage());

            //            break;

            //        case 2:
            //            this.NavigationService.Navigate(new AdminPage());

            //            break;
            //        case 3:
            //            this.NavigationService.Navigate(new DepartPage());

            //            break;

            //    }
            //}
            //catch { }

     
        }

        private void DistributionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddWork_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton= sender as Button;
            Tasks activeTask=activeButton.DataContext as Tasks;
            int idTask = activeTask.IdTasks;
            int idWorker = activeWorker.IdWorker;
            try
            {
                TaskWorker added = new TaskWorker()
                {
                    IdTasks= idTask,
                    IdWorker= idWorker,
                };
                db.context.TaskWorker.Add(added);

                db.context.SaveChanges();
                MessageBox.Show("Добавление выполнено успешно !",
"Уведомление",
MessageBoxButton.OK,
MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Критический сбой в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        }

       
    }

