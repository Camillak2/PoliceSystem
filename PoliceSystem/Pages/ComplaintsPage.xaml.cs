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
using PoliceSystem.Windowsss;

namespace PoliceSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для ComplaintsPage.xaml
    /// </summary>
    public partial class ComplaintsPage : Page
    {
        public static List<Сomplaint> complaints { get; set; }
        public static List<User> users { get; set; }
        public static List<Status> statuses { get; set; }
        public static User loggedUser;

        public ComplaintsPage()
        {
            InitializeComponent();
            loggedUser = DBConnection.loginedUser;
            complaints = DBConnection.police_System.Сomplaint.ToList();
            users = DBConnection.police_System.User.ToList();
            statuses = DBConnection.police_System.Status.ToList();
            this.DataContext = this;
            Refresh();
        }
        private void Refresh()
        {
            ComplaintsLV.ItemsSource = DBConnection.police_System.Сomplaint.Where(i => i.User_id == loggedUser.User_id).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void EditWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsLV.SelectedItem is Сomplaint сomplaint)
            {
                DBConnection.selectedForEditComplaint = ComplaintsLV.SelectedItem as Сomplaint;
                EditComplaint editComplaint = new EditComplaint(сomplaint);
                editComplaint.ShowDialog();
            }
            else if (ComplaintsLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите жалобу!");
            }
            Refresh();
        }

        private void AddWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            AddComplaintWindow addComplaintWindow = new AddComplaintWindow();
            addComplaintWindow.ShowDialog(); 
            Refresh();
        }

        private void DeleteWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsLV.SelectedItem is Сomplaint сomplaint)
            {
                DBConnection.police_System.Сomplaint.Remove(сomplaint);
                DBConnection.police_System.SaveChanges();
            }
            else if (ComplaintsLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите жалобу!");
            }
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuCivilianPage());
        }
    }
}
