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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Employee employeeemp;
        public static List<Employee> employees { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы входите как гость!");
            NavigationService.Navigate(new GuestInformationPage());
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordPb.Password.Trim();

            employees = new List<Employee>(DbConnection.Educational_Practice_320_KamilEntities.Employee.ToList());
            employeeemp = employees.FirstOrDefault(i => i.Id_employee.ToString() == login && i.Id_employee.ToString() == password);

            if (employeeemp != null && employeeemp.Post == "зав. кафедрой")
            {
                MessageBox.Show($"Вы входите как {employeeemp.Surname} ({employeeemp.Post})!");
                NavigationService.Navigate(new DepartmentHeadInformationPage());
            }
            else if (employeeemp != null && employeeemp.Post == "преподаватель")
            {
                MessageBox.Show($"Вы входите как {employeeemp.Surname} ({employeeemp.Post})!");
                NavigationService.Navigate(new TeacherInformationPage());
            }
            else if (employeeemp != null && employeeemp.Post == "инженер")
            {
                MessageBox.Show($"Вы входите как {employeeemp.Surname} ({employeeemp.Post})!");
                NavigationService.Navigate(new EngineerInformationPage());
            }
            else
            {
                MessageBox.Show("Повторите попытку!");
                loginTb.Text = string.Empty;
                passwordPb.Password = string.Empty;
            }
        }
    }
}
