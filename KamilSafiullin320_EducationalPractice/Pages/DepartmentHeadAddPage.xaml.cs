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
    /// Логика взаимодействия для DepartmentHeadAddPage.xaml
    /// </summary>
    public partial class DepartmentHeadAddPage : Page
    {
        public DepartmentHeadAddPage()
        {
            InitializeComponent();
        }

        private void DisciplineBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentHeadDisciplinePage());
        }

        private void DisciplineAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DisciplineIdTb.Text == String.Empty || DisciplineVolumeTb.Text == String.Empty || DisciplineNameTb.Text == String.Empty)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Discipline discipline = new Discipline()
                {
                    Id_discipline = int.Parse(DisciplineIdTb.Text),
                    Volume = int.Parse(DisciplineVolumeTb.Text),
                    Name = DisciplineNameTb.Text,
                    Executor = DepartmentHeadInformationPage.dep.Id_department
                };

                DbConnection.Educational_Practice_320_KamilEntities.Discipline.Add(discipline);
                DbConnection.Educational_Practice_320_KamilEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                NavigationService.Navigate(new DepartmentHeadDisciplinePage());
            }
        }
    }
}
