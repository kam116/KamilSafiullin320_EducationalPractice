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
    /// Логика взаимодействия для GuestInformationPage.xaml
    /// </summary>
    public partial class GuestInformationPage : Page
    {
        public static List<Discipline> disciplines {  get; set; }
        public GuestInformationPage()
        {
            InitializeComponent();

            disciplines = new List<Discipline>(DbConnection.Educational_Practice_320_KamilEntities.Discipline.ToList());
            this.DataContext = this;

            GuestInfoLv.ItemsSource = disciplines;
        }

        private void GuestBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
