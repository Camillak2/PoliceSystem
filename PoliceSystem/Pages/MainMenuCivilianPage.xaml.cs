﻿using System;
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

namespace PoliceSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuCivilianPage.xaml
    /// </summary>
    public partial class MainMenuCivilianPage : Page
    {
        public MainMenuCivilianPage()
        {
            InitializeComponent();
        }

        private void ComplaintBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
