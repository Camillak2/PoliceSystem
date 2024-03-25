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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<User> users { get; set; }

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTB.Text.Trim();
                string password = PasswordTB.Password.Trim();

                users = new List<User>(DBConnection.police_System.User.ToList());
                var currentUser = users.FirstOrDefault(i => i.Login.Trim() == login && i.Password.Trim() == password);
                DBConnection.loginedUser = currentUser;

                if (currentUser != null && currentUser.Role.Name == "Полицейский")
                {
                    NavigationService.Navigate(new MainMenuPolicePage());
                }
                else if (currentUser != null && currentUser.Role.Name == "Мирный житель")
                {
                    NavigationService.Navigate(new MainMenuCivilianPage());
                }
                else if (currentUser != null && currentUser.Role.Name == "Преступник")
                {
                    NavigationService.Navigate(new MainMenuCriminalPage());
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
