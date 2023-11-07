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
    /// Логика взаимодействия для DepartmentHeadInformationPage.xaml
    /// </summary>
    public partial class DepartmentHeadInformationPage : Page
    {
        public static List<Department> departments { get; set; }
        public static Department dep { get; set; }

        public DepartmentHeadInformationPage()
        {
            InitializeComponent();

            DepartmentHeadNameTb.Text = AuthorizationPage.employeeemp.Surname;

            departments = new List<Department>(DbConnection.Educational_Practice_320_KamilEntities.Department.ToList());
            this.DataContext = this;

            DepartmentHeadInfoLv.ItemsSource = departments;
        }

        private void DepartmentHeadBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void DepartmentHeadInfoLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dep = DepartmentHeadInfoLv.SelectedItem as Department;
            NavigationService.Navigate(new DepartmentHeadDisciplinePage());
        }

        private void DepartmentHeadAddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
