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
using System.Windows.Shapes;
using PoliceSystem.DB;

namespace PoliceSystem.Windowsss
{
    /// <summary>
    /// Логика взаимодействия для EditComplaint.xaml
    /// </summary>
    public partial class EditComplaint : Window
    {
        public static List<Сomplaint> complaints { get; set; }
        public static List<User> users { get; set; }
        public static List<Status> statuses { get; set; }

        Сomplaint contextСomplaint;

        public EditComplaint(Сomplaint сomplaint)
        {
            InitializeComponent();

            InitializeComponent();
            contextСomplaint = сomplaint;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            complaints = DBConnection.police_System.Сomplaint.ToList();
            users = DBConnection.police_System.User.ToList();
            statuses = DBConnection.police_System.Status.ToList();
            this.DataContext = this;

            ComplaintTB.Text = contextСomplaint.Text;
            CriminalCB.SelectedIndex = (int)contextСomplaint.Criminal_id - 1;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                Сomplaint сomplaint = contextСomplaint;
                if (string.IsNullOrWhiteSpace(CriminalCB.Text) || string.IsNullOrWhiteSpace(ComplaintTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    сomplaint.Text = ComplaintTB.Text;
                    сomplaint.Criminal_id = (CriminalCB.SelectedItem as User).User_id;
                    DBConnection.police_System.SaveChanges();

                    ComplaintTB.Text = String.Empty;
                    CriminalCB.Text = String.Empty;

                    DBConnection.police_System.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
