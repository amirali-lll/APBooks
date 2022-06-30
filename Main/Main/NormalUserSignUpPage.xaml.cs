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
    /// Interaction logic for NormalUserSignUpPage.xaml
    /// </summary>
    public partial class NormalUserSignUpPage : Window
    {
        public NormalUserSignUpPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserLoginPage userLoginPage = new UserLoginPage(MOrU.normaluser);
            userLoginPage.Show();
            Close();
        }
    }
}
