using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoliceSystem.DB;

namespace PoliceSystem.Automation
{
    internal class AuthorizationClass
    {
        public bool Login(string login, string password)
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
    }
}
