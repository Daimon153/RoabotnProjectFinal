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
    /// Логика взаимодействия для TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        Core db = new Core();
        List<Tasks> taskArray;
        public TasksPage()
        {
            InitializeComponent();
            taskArray = db.context.Tasks.ToList();
            TasksListView.ItemsSource = taskArray;

        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TaskAddPage());

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

        private void TasksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          

        }

        private void DelTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = TasksListView.SelectedItem as Tasks;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {

                    MessageBox.Show("Вы не выбрали ни одной строки");

                    return;

                }

                else
                {

                    //выполним удаление только в том случае, если пользователь даст согласие на удаление

                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {

                        //удаляем выбранную строку

                        db.context.Tasks.Remove(item);

                        db.context.SaveChanges();

                        MessageBox.Show("Информация удалена");

                        //обновление DataGrid

                        TasksListView.ItemsSource = db.context.Tasks.ToList();

                    }
                }
            }




            catch (Exception)

            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Tasks activeTasks = activeButton.DataContext as Tasks;
            this.NavigationService.Navigate(new TaskUpdatePage(db, activeTasks));
        }
    }
}
