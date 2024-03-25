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
    /// Логика взаимодействия для AddComplaintWindow.xaml
    /// </summary>
    public partial class AddComplaintWindow : Window
    {
        public static List<Сomplaint> complaints { get; set; }
        public static List<User> users { get; set; }

        public static Сomplaint сomplaint = new Сomplaint();

        public AddComplaintWindow()
        {
            InitializeComponent();
            complaints = DBConnection.police_System.Сomplaint.ToList();
            users = DBConnection.police_System.User.ToList();
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
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
                    сomplaint.Text = ComplaintTB.Text.Trim();
                    var a = CriminalCB.SelectedItem as User;
                    сomplaint.Criminal_id = a.User_id;

                    DBConnection.police_System.Сomplaint.Add(сomplaint);
                    DBConnection.police_System.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
