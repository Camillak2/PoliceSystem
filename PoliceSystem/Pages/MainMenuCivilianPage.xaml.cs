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
using PoliceSystem.DB;

namespace PoliceSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuCivilianPage.xaml
    /// </summary>
    public partial class MainMenuCivilianPage : Page
    {
        public static List<User> users { get; set; }
        public static User loggedUser;

        public MainMenuCivilianPage()
        {
            InitializeComponent();
            loggedUser = DBConnection.loginedUser;
            UserTB.Text = loggedUser.FirstName.ToString() + " " + loggedUser.LastName.ToString();
            LoginTB.Text = DBConnection.loginedUser.Login;
        }

        private void ComplaintBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ComplaintsPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
