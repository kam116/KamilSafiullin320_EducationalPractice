using KamilSafiullin320_EducationalPractice.DB;
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

namespace KamilSafiullin320_EducationalPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartmentHeadDisciplinePage.xaml
    /// </summary>
    public partial class DepartmentHeadDisciplinePage : Page
    {
        public static List<Discipline> disciplines {  get; set; }
        public DepartmentHeadDisciplinePage()
        {
            InitializeComponent();

            DepartmentNameTb.Text = DepartmentHeadInformationPage.dep.Name;

            disciplines = new List<Discipline>(DbConnection.Educational_Practice_320_KamilEntities.Discipline.ToList().Where(x => x.Executor == DepartmentHeadInformationPage.dep.Id_department));
            this.DataContext = this;

            DepHeadDisciplineLv.ItemsSource = disciplines;
        }

        private void DisciplineBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentHeadInformationPage());
        }
    }
}
