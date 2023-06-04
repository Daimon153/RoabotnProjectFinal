using Microsoft.Win32;
using Roabotn.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddWorkerPage.xaml
    /// </summary>
    public partial class AddWorkerPage : Page
    {
        Core db = new Core();
        OpenFileDialog openFileDialog;
        public AddWorkerPage()
        {
            InitializeComponent();
            Depart.ItemsSource = db.context.Department.ToList();
            Depart.DisplayMemberPath ="NameDepartment";
            Depart.SelectedValuePath = "IdDepartment";
            
        }

      
        private void LoadFileButton_Click_1(object sender, RoutedEventArgs e)
        {
             openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName);
                LoadFileImage.Source=new BitmapImage(uri);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker added = new Worker()
                {
                    firstname = firstname.Text,
                    lastname = lastname.Text,
                    surname = surname.Text,
                    number = number.Text,
                    email = email.Text,
                    INN = inn.Text,
                    Snils = snils.Text,
                    Specialnost = spec.Text,
                    Adress = adress.Text,
                    PasportSeries = pasportseries.Text,
                    PasportNumber = pasportnumber.Text,
                    birthday = birthday.SelectedDate.Value,
                    Image = System.IO.Path.GetFileName(openFileDialog.FileName),
                    IdDepartment = Convert.ToInt32(Depart.SelectedValue),
                    


                };
                db.context.Worker.Add(added);
                db.context.SaveChanges();
                MessageBox.Show("Добавление выполнено успешно !",
"Уведомление",
MessageBoxButton.OK,
MessageBoxImage.Information);
                //перенос файла
                string newfilename = "\\Assets\\Images\\";
                string appFolderPath = Directory.GetCurrentDirectory();
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                string imageName = System.IO.Path.GetFileName(openFileDialog.FileName);//имя картинки с расширением

                newfilename = appFolderPath + newfilename + imageName;

                File.Copy(openFileDialog.FileName, newfilename);
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
