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
using KamilSafiullin320_EducationalPractice.DB;

namespace KamilSafiullin320_EducationalPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для EngineerInformationPage.xaml
    /// </summary>
    public partial class EngineerInformationPage : Page
    {
        public static List<Employee> employees { get; set; }
        public static Employee emp { get; set; }
        public EngineerInformationPage()
        {
            InitializeComponent();

            EngineerNameTb.Text = AuthorizationPage.employeeemp.Surname;

            employees = new List<Employee>(DbConnection.Educational_Practice_320_KamilEntities.Employee.ToList());
            this.DataContext = this;

            EngineerInfoLv.ItemsSource = employees;
        }

        private void EngineerBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void EngineerInfoLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            emp = EngineerInfoLv.SelectedItem as Employee;
            NavigationService.Navigate(new EngineerEmployeePage());
        }

        private void EngineerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerAddPage());
        }
    }
}
