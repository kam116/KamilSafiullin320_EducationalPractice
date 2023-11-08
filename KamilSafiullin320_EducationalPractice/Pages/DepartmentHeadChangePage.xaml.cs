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
    /// Логика взаимодействия для DepartmentHeadChangePage.xaml
    /// </summary>
    public partial class DepartmentHeadChangePage : Page
    {
        public DepartmentHeadChangePage()
        {
            InitializeComponent();

            DisciplineIdTb.Text = DepartmentHeadDisciplinePage.discipline.Id_discipline.ToString();
            DisciplineVolumeTb.Text = DepartmentHeadDisciplinePage.discipline.Volume.ToString();
            DisciplineNameTb.Text = DepartmentHeadDisciplinePage.discipline.Name;
        }

        private void DisciplineBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentHeadDisciplinePage());
        }

        private void DisciplineChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DisciplineIdTb.Text == String.Empty || DisciplineVolumeTb.Text == String.Empty || DisciplineNameTb.Text == String.Empty)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                DepartmentHeadDisciplinePage.discipline.Id_discipline = int.Parse(DisciplineIdTb.Text);
                DepartmentHeadDisciplinePage.discipline.Volume = int.Parse(DisciplineVolumeTb.Text);
                DepartmentHeadDisciplinePage.discipline.Name = DisciplineNameTb.Text;

                DbConnection.Educational_Practice_320_KamilEntities.SaveChanges();

                MessageBox.Show("Данные изменены!");

                NavigationService.Navigate(new DepartmentHeadDisciplinePage());
            }
        }
    }
}
