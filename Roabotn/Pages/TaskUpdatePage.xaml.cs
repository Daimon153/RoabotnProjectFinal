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
    /// Логика взаимодействия для TaskUpdatePage.xaml
    /// </summary>
    public partial class TaskUpdatePage : Page
    {
        Core db;
        public TaskUpdatePage(Core db, Tasks currentTasks)
        {
            InitializeComponent();
            
            this.DataContext = currentTasks;
            this.db = db;
        }

        private void backMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TasksPage());
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            db.context.SaveChanges();
            MessageBox.Show("Добавление выполнено успешно !",
"Уведомление",
MessageBoxButton.OK,
MessageBoxImage.Information);
        }
    }
}
