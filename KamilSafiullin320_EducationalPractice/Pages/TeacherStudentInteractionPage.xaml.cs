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
    /// Логика взаимодействия для TeacherStudentInteractionPage.xaml
    /// </summary>
    public partial class TeacherStudentInteractionPage : Page
    {
        public static List<Exam> exams { get; set; }
        public static List<Student> students { get; set; }
        public TeacherStudentInteractionPage()
        {
            InitializeComponent();

            DisciplineNameTb.Text = TeacherInformationPage.exam.Discipline.Name;
            DisciplineDateTb.Text = TeacherInformationPage.exam.Date.ToString().Split(' ')[0];

            exams = new List<Exam>(DbConnection.Educational_Practice_320_KamilEntities.Exam.ToList().Where(x => x.Date == TeacherInformationPage.exam.Date && x.Discipline == TeacherInformationPage.exam.Discipline));
            this.DataContext = this;

            students = new List<Student>(DbConnection.Educational_Practice_320_KamilEntities.Student.ToList());
            StudentRegNumberCb.ItemsSource = students;
            StudentRegNumberCb.DisplayMemberPath = "Id_student";

            TeacherStudentInfoLv.ItemsSource = exams;
        }

        private void TeacherStudentBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherInformationPage());
        }

        private void TeacherStudentAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentRegNumberCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Exam exam = new Exam
                {
                    Date = TeacherInformationPage.exam.Date,
                    Id_employee = TeacherInformationPage.exam.Id_employee,
                    Id_discipline = TeacherInformationPage.exam.Id_discipline,
                    Audience = TeacherInformationPage.exam.Audience,
                    Id_student = (StudentRegNumberCb.SelectedItem as Student).Id_student
                };

                DbConnection.Educational_Practice_320_KamilEntities.Exam.Add(exam);
                DbConnection.Educational_Practice_320_KamilEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                TeacherStudentInfoLv.ItemsSource = new List<Exam>(DbConnection.Educational_Practice_320_KamilEntities.Exam.ToList().Where(x => x.Date == TeacherInformationPage.exam.Date && x.Discipline == TeacherInformationPage.exam.Discipline));

                StudentRegNumberCb.SelectedItem = null;
            }
        }

        private void TeacherStudentDeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
