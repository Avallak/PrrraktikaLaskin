using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using PR6.Models;
using iTextSharp.text;
using System.Data;
using PR6.Windows;
using PR6.Classes;

namespace PR6.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            using (var db = new ZarplataEntities())
            {
                WorkesDG.ItemsSource = db.Workers.ToList();
            }
        }
       /// <summary>
       /// Обновление данных в datagrid
       /// </summary>
        public void RefreshWorkers()
        {
            WorkesDG.ItemsSource = null;
            WorkesDG.Items.Clear();
            using (var db = new ZarplataEntities())
            {
                WorkesDG.ItemsSource = db.Workers.ToList();
            }
        }
     
        private void AddWorkersBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddWorker addWorker = new AddWorker(this, null);
            addWorker.ShowDialog();
        }
        BaseFont bf;
        Font f_title;
        Font f_text;
        /// <summary>
        /// Обработчик событий для экспорта в PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintToPDF_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PdfPTable table = new PdfPTable(6);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 20, 20, 40, 20);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Сотрудники.pdf", System.IO.FileMode.Create)); //Создаем файл

            bf = BaseFont.CreateFont("C:\\Users\\JutsPC\\Desktop\\Демо-Экзамен\\Rakhimov_Marcel\\PR6\\PR6\\Fonts\\Roboto-Regular.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            f_title = new Font(bf, 20);
            f_text = new Font(bf, 14);

            doc.Open();
            doc.Add(new Phrase("Сотрудники", f_title));

            for (int j = 0; j < 7; ++j)
            {
                if (WorkesDG.Columns[j].Header.ToString() == "Изменить" || WorkesDG.Columns[j].Header.ToString() == "Удалить") //Пропускаем соответствующие столбцы
                    continue;
                table.AddCell(new Phrase(WorkesDG.Columns[j].Header.ToString(), f_text));
            }

            table.HeaderRows = 0;
            IEnumerable itemsSource = WorkesDG.ItemsSource as IEnumerable;

            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = WorkesDG.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = MethodForExportToPDF.FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < 7; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, f_text));
                            }
                        }
                    }
                }
                doc.Add(table);
                doc.Close();
                System.Diagnostics.Process.Start("Сотрудники.pdf");
            }
        }
        /// <summary>
        /// Обработчик событий для удаления данных из таблицы Workes и связанных данных из таблицы Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnForDelete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить выбранные данные?", "Удаление объекта", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ZarplataEntities())
                {
                    Workers s = (sender as Border).DataContext as Workers;
                    var statuc = db.Status.Where(x => x.Worker_id == s.id).ToList();
                    var cityobj = db.Workers.FirstOrDefault(p => p.id == s.id);
                    db.Workers.Remove(cityobj);
                    db.Status.RemoveRange(statuc);
                    db.SaveChanges();
                    RefreshWorkers();
                    MessageBox.Show("Данные удалены");
                }
            }

        }

        private void BtnForEdit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddWorker addWorker = new AddWorker(this, (sender as Border).DataContext as Workers);
            addWorker.Show();
        }

        private void StatusPageOpenBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.MainFrame.Navigate(new StatusPage());
        }
    }
}
