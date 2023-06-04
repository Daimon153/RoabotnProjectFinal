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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        Core db;
        public UpdatePage(Core db, Worker currentWorker)
        {
            InitializeComponent();
            this.DataContext = currentWorker;
            this.db = db;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
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
