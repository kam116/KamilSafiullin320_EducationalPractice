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
    /// Логика взаимодействия для EngineerChangePage.xaml
    /// </summary>
    public partial class EngineerChangePage : Page
    {
        public static List<Post> posts { get; set; }
        public EngineerChangePage()
        {
            InitializeComponent();

            EnEmployeeIdTb.Text = EngineerInformationPage.emp.Id_employee.ToString();
            EnEmployeeSurnameTb.Text = EngineerInformationPage.emp.Surname;

            posts = new List<Post>(DbConnection.Educational_Practice_320_KamilEntities.Post.ToList());
            EnEmployeePostCb.ItemsSource = posts;
            EnEmployeePostCb.DisplayMemberPath = "Name";

            //EnEmployeeIdTb.Text = EngineerInformationPage.emp.Id_employee.ToString();
        }

        private void EngineerAddBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerInformationPage());
        }

        private void EngineerChangeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EngineerDeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
