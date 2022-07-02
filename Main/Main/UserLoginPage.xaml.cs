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
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Interaction logic for UserLoginPage.xaml
    /// </summary>
    public partial class UserLoginPage : Window
    {
        public UserLoginPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckEmailValidation(EmailBox.Text, MOrU.normaluser))
            {
                if(CheckRegularExpressions.CheckPasswordValidation(EmailBox.Text, PassWordBox.Password, MOrU.normaluser))
                {
                    MessageBox.Show("Welcome " + EmailBox.Text + " !");
                    Close();
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
        private void HereButton_Click(object sender, RoutedEventArgs e)
        {
            NormalUserSignUpPage normalUserSignUpPage = new NormalUserSignUpPage();
            normalUserSignUpPage.Show();
            Close();
        }
    }
}

