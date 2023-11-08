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
        public static List<Faculty> faculties { get; set; }
        public static Department dep { get; set; }

        public DepartmentHeadInformationPage()
        {
            InitializeComponent();

            DepartmentHeadNameTb.Text = AuthorizationPage.employeeemp.Surname;

            departments = new List<Department>(DbConnection.Educational_Practice_320_KamilEntities.Department.ToList());
            this.DataContext = this;

            faculties = new List<Faculty>(DbConnection.Educational_Practice_320_KamilEntities.Faculty.ToList());
            FacultyIdCb.ItemsSource = faculties;
            FacultyIdCb.DisplayMemberPath = "Id_faculty";

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
            if (DepartmentNameTb.Text == String.Empty || FacultyIdCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (departments.FirstOrDefault(x => x.Id_department.Trim() == GenerateCipher(DepartmentNameTb.Text).Trim())!= null)
            {
                MessageBox.Show("Шифр должен быть уникальным!");
            }
            else
            {
                Department department = new Department()
                {
                    Id_department = GenerateCipher(DepartmentNameTb.Text),
                    Name = DepartmentNameTb.Text,
                    Id_faculty = (FacultyIdCb.SelectedItem as Faculty).Id_faculty
                };

                DbConnection.Educational_Practice_320_KamilEntities.Department.Add(department);
                DbConnection.Educational_Practice_320_KamilEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                DepartmentHeadInfoLv.ItemsSource = new List<Department>(DbConnection.Educational_Practice_320_KamilEntities.Department.ToList());

                DepartmentNameTb.Text = string.Empty;
                FacultyIdCb.SelectedItem = null;
            }
        }

        public static string GenerateCipher(string name)
        {
            string[] mass = name.Trim().Split(' ');
            string cipher = "";
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != "")
                {
                    cipher += char.ToLower(mass[i][0]);
                }
            }
            return cipher;
        }
    }
}
