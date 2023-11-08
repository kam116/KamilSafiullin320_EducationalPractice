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
    /// Логика взаимодействия для EngineerAddPage.xaml
    /// </summary>
    public partial class EngineerAddPage : Page
    {
        public static List<Department> departments { get; set; }
        public static List<Post> posts { get; set; }
        public static List<Employee> employees { get; set; }
        public EngineerAddPage()
        {
            InitializeComponent();

            departments = new List<Department>(DbConnection.Educational_Practice_320_KamilEntities.Department.ToList());
            EmployeeCipherCb.ItemsSource = departments;
            EmployeeCipherCb.DisplayMemberPath = "Id_department";

            posts = new List<Post>(DbConnection.Educational_Practice_320_KamilEntities.Post.ToList());
            EmployeePostCb.ItemsSource = posts;
            EmployeePostCb.DisplayMemberPath = "Name";

            employees = new List<Employee>(DbConnection.Educational_Practice_320_KamilEntities.Employee.ToList());
            EmployeeChiefCb.ItemsSource = employees;
            EmployeeChiefCb.DisplayMemberPath = "Id_employee";
        }

        private void EngineerAddBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerInformationPage());
        }

        private void EngineerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeIdTb.Text == String.Empty || EmployeeCipherCb.SelectedItem == null || EmployeeSurnameTb.Text == String.Empty || EmployeePostCb.SelectedItem == null || EmployeeSalaryTb.Text == String.Empty || EmployeeChiefCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Employee employee = new Employee()
                {
                    Id_employee = int.Parse(EmployeeIdTb.Text),
                    Cipher = (EmployeeCipherCb.SelectedItem as Department).Id_department,
                    Surname = EmployeeSurnameTb.Text,
                    Post = (EmployeePostCb.SelectedItem as Post).Name,
                    Salary = int.Parse(EmployeeSalaryTb.Text),
                    Id_chief = (EmployeeChiefCb.SelectedItem as Employee).Id_employee
                };

                DbConnection.Educational_Practice_320_KamilEntities.Employee.Add(employee);
                DbConnection.Educational_Practice_320_KamilEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                NavigationService.Navigate(new EngineerInformationPage());
            }
        }
    }
}
