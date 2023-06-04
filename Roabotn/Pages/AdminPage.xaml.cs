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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace Roabotn.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Core db = new Core();
        List<Worker> workers;
        
        public AdminPage()
        {
            InitializeComponent();
            workers = db.context.Worker.ToList();
            WorkedListView.ItemsSource = workers;
        }
        private void UpdateUI()
        {
         

        }

        private void WorkedAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddWorkerPage());
        }

        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TasksPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());

        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
           

            /*создаем файл Excel*/

            var aplication = new Excel.Application();

            aplication.Visible = true;

            /*количество листов*/

            aplication.SheetsInNewWorkbook = 1;

            /*добавляем рабочую книгу*/

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/

            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Name = "Report"; //имя листа нужно вводить латинскими буквами

            /*заголовки вывод в Excel (в первую строку)*/

            worksheet.Cells[1][1] = "Фамилия";

            worksheet.Cells[2][1] = "Выполненные работы за месяц";
            worksheet.Cells[3][1] = "Выполненные работы за год";
            





            /*вывод данных из массива в Excel*/

            int rowIndex = 2;  //номер строки для вывода данных из массива

            foreach (var item in workers)

            {

                worksheet.Cells[1][rowIndex] = item.lastname;

                worksheet.Cells[2][rowIndex] = item.CountCompleteTaskMounth;
                worksheet.Cells[3][rowIndex] = item.CountCompleteTaskYear;
                
                

                rowIndex++;

            }
           
            //var ReportWorkers = db.context.Department.ToList().OrderBy(x => x.NameDepartment).ToList();
            //var Work = db.context.Worker.ToList().OrderBy(x => x.lastname).ToList();
            //var application = new Excel.Application();
            //application.SheetsInNewWorkbook = ReportWorkers.Count();
            //Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            //for(int i = 0; i < ReportWorkers.Count(); i++)
            //{
            //    int startRowIndex = 1;
            //    Excel.Worksheet worksheet = application.Worksheets.Item[i+1];
            //    worksheet.Name = ReportWorkers[i].NameDepartment;

            //    worksheet.Cells[1][startRowIndex] = "Фамилия сотрудника";
            //    worksheet.Cells[2][startRowIndex] = "Выполненные работы за месяц";
            //    worksheet.Cells[3][startRowIndex] = "Выполненные работы за год";
            //    worksheet.Cells[4][startRowIndex] = "Количество сотрудников подразделения";
            //    startRowIndex++;
            //    var workerCategories = ReportWorkers[i].Worker.OrderBy(x => x.lastname).OrderBy(x => x.CountCompleteTaskMounth).OrderBy(x => x.CountCompleteTaskYear);
            //    foreach(var Workers in Work)
            //    {
            //        worksheet.Cells[1][startRowIndex] = Workers.lastname;
            //    }
            //}
            //application.Visible= true;
        }

        private void WorkedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
         Worker activeWorker=activeButton.DataContext as Worker;
            this.NavigationService.Navigate(new UpdatePage(db,activeWorker));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try { 
            var item = WorkedListView.SelectedItem as Worker;

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

                        db.context.Worker.Remove(item);

                        db.context.SaveChanges();

                        MessageBox.Show("Информация удалена");

                        //обновление DataGrid

                        WorkedListView.ItemsSource = db.context.Worker.ToList();

                    }
                }
            }
            

            

catch (Exception)

            {
                MessageBox.Show("Данные не удалены. ");
            }
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

        private void SearchBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            WorkedListView.ItemsSource = db.context.Worker.Where(x=>x.lastname.Contains(SearchBox.Text)).ToList();
        }

        private void ReportButtonWord_Click(object sender, RoutedEventArgs e)
        {
            var aplication = new Word.Application();

            aplication.Visible = true;
            Word.Document document = aplication.Documents.Add();
            Word.Paragraph Dep = document.Paragraphs.Add();
            Word.Range DepBlock = Dep.Range;
            Word.Table DepTable = document.Tables.Add(DepBlock, 5, 3);



            DepTable.Cell(1, 1).Range.Text = "Наименование подразделения";
            DepTable.Cell(1, 2).Range.Text = "Количество сотрудников подразделения";
            DepTable.Cell(1, 3).Range.Text = "Количество сотрудников предприятия";
            int i = 1;
            foreach (var item in db.context.Department.ToList())

            {

                DepBlock = DepTable.Cell(i + 1, 1).Range;
                DepBlock.Text = $"{item.NameDepartment}";
                
                //DepBlock = DepTable.Cell(i+1,2).Range;
                //DepBlock.Text = $"{item.Depart}";
                i++;
            //DepBlock = DepTable.Cell(2,3).Range;
            //DepBlock.Text = $"{item.ColDep}";




            }
            foreach (var item in workers)
            {
                DepBlock = DepTable.Cell(i + 1, 2).Range;
                DepBlock.Text = $"{item.Depart}";
                i++;
                DepBlock = DepTable.Cell(2, 3).Range;
                DepBlock.Text = $"{item.ColDep}";
            }

            DepTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            DepTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        }
    }
}
