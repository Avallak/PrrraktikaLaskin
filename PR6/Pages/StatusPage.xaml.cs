using PR6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using PR6.Pages;

namespace PR6.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        public StatusPage()
        {
            InitializeComponent();
            using (var db = new ZarplataEntities())
            {
                StatusDG.ItemsSource = db.Status.ToList();
            }
        }

        private void BackBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.MainFrame.Navigate(new WorkersPage());
        }
    }
}
