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
    /// Логика взаимодействия для TaskAddPage.xaml
    /// </summary>
    public partial class TaskAddPage : Page
    {
        Core db = new Core();
        public TaskAddPage()
        {
            InitializeComponent();
        }

        private void backMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TasksPage());

        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tasks added = new Tasks()
                {
                    TaskName = taskname.Text,
                    Description = description.Text,
                    StartTime = starttime.SelectedDate.Value,
                    EndTime = endtime.SelectedDate.Value,
                    IdTaskStatus = 2
                };
                db.context.Tasks.Add(added);
               
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
