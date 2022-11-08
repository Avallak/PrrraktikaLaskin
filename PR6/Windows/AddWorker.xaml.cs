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
using System.Windows.Shapes;
using PR6.Models;
using PR6.Pages;

namespace PR6.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {

        private Workers _workers;
        public WorkersPage workersPage = new WorkersPage();
        public AddWorker(WorkersPage _workersPage, Workers work = null)
        {
            InitializeComponent();
            _workers = work;
            workersPage = _workersPage;
            if (_workers != null) //Если переданный объект не пустой, то заполняем поля для ввода значениями этого объекта
            {
                NameTB.Text = _workers.Name;
                SurnameTB.Text = _workers.Surname;
                CodeExt.Text = _workers.FK_extension.ToString();

                CodeGradeTB.Text = _workers.FK_grade.ToString();
                CodeSalaryTB.Text = _workers.fin_salary_id.ToString();
                JobNameTB.Text = _workers.FK_Title.ToString();
                LabelOfBorder.Text = "Изменить";
                lbl.Content = "Изменение сотрудника";
            }
            else
            {
                LabelOfBorder.Text = "Добавить";
                lbl.Content = "Добавление сотрудника";
            }
        }
        /// <summary>
        /// Обработчик событий для изменения или добавления данных
        /// В зависимости он значения параметра конструктора worker проводится 
        /// либо изменение выбранных данных
        /// либо добавление новых.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Extensions ext = new Extensions();
            Titles titles = new Titles();
            Gradation gradation = new Gradation();
            using (var db = new ZarplataEntities())
            {
                var codeext = Convert.ToInt32(CodeExt.Text);
                var codetitle = Convert.ToInt32(JobNameTB.Text);
                var codegrad = Convert.ToInt32(CodeGradeTB.Text);
                ext = db.Extensions.FirstOrDefault(x => x.id == codeext);
                titles = db.Titles.FirstOrDefault(x => x.id == codetitle);
                gradation = db.Gradation.FirstOrDefault(x => x.id == codegrad);
            }
            if (!String.IsNullOrEmpty(NameTB.Text) && !String.IsNullOrEmpty(SurnameTB.Text) && !String.IsNullOrEmpty(JobNameTB.Text)
                && !String.IsNullOrEmpty(CodeExt.Text) && !String.IsNullOrEmpty(CodeGradeTB.Text) && !String.IsNullOrEmpty(CodeSalaryTB.Text))
            {
                if (_workers == null)
                {
                    using (var db = new ZarplataEntities())
                    {
                        Workers s = new Workers()
                        {
                            Name = NameTB.Text,
                            Surname = SurnameTB.Text,
                            FK_extension = Convert.ToInt32(CodeExt.Text),
                            FK_grade = Convert.ToInt32(CodeGradeTB.Text),
                            FK_Title = Convert.ToInt32(JobNameTB.Text),
                            fin_salary_id = Convert.ToInt32(CodeSalaryTB.Text),
                            
                        };
                        db.Workers.Add(s);
                        db.SaveChanges();
                        workersPage.RefreshWorkers();
                        this.Hide();
                        MessageBox.Show("Данные добавлены");
                    }
                }
                if (_workers != null)
                {
                    using (var db = new ZarplataEntities())
                    {
                        var dbCityObject = db.Workers.FirstOrDefault(p => p.id == _workers.id);
                        dbCityObject.Name = NameTB.Text;
                        dbCityObject.Surname = SurnameTB.Text;
                        dbCityObject.FK_extension = Convert.ToInt32(CodeExt.Text);
                        dbCityObject.FK_grade = Convert.ToInt32(CodeGradeTB.Text);
                        dbCityObject.FK_Title = Convert.ToInt32(JobNameTB.Text);
                        dbCityObject.fin_salary_id = Convert.ToInt32(CodeSalaryTB.Text);
                        db.SaveChanges();
                        workersPage.RefreshWorkers();
                        this.Hide();
                        MessageBox.Show("Данные добавлены");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!\n Возможно, данный владелец не найден.");
            }

        }
    }
}
