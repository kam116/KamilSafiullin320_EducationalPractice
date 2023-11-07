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
    /// Логика взаимодействия для TeacherInformationPage.xaml
    /// </summary>
    public partial class TeacherInformationPage : Page
    {
        public static List<Exam> exams { get; set; }
        public static Employee employee1;
        public static Exam exam;
        public TeacherInformationPage()
        {
            InitializeComponent();

            employee1 = AuthorizationPage.employeeemp;

            TeacherNameTb.Text = employee1.Surname;

            exams = new List<Exam>(DbConnection.Educational_Practice_320_KamilEntities.Exam.ToList().Where(x => x.Id_employee == employee1.Id_employee));
            List<Exam> sourceExams = new List<Exam>();

            for (int i = 0; i < exams.Count; i++)
            {
                if (sourceExams.FirstOrDefault(x => x.Date == exams[i].Date && x.Id_discipline == exams[i].Id_discipline) == null)
                {
                    sourceExams.Add(exams[i]);
                }
            }
            
            this.DataContext = this;

            TeacherInfoLv.ItemsSource = sourceExams;
        }

        private void TeacherBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void TeacherInfoLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exam = TeacherInfoLv.SelectedItem as Exam;
            NavigationService.Navigate(new TeacherStudentInteractionPage());
        }
    }
}
