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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    { Core db = new Core();
        public LoginPage()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                //считаем количество записей в таблице с заданными параметрами (логин, пароль)
                AdminLogin enter = db.context.AdminLogin.Where(
                x => x.login == login.Text && x.password == password.Text
                ).FirstOrDefault();

                if (enter == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                }
                else

                {
                    App.CurrentUser = enter;
                    Console.WriteLine(enter.IdStatus);
                    switch (enter.IdStatus)
                    {

                        case 1:
                            this.NavigationService.Navigate(new AdminPage());

                            break;

                        case 2:
                            this.NavigationService.Navigate(new AdminPage());

                            break;
                        case 3:
                            this.NavigationService.Navigate(new DepartPage());

                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }
    }
}
