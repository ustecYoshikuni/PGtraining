﻿using System.Windows.Controls;

namespace PGtraining.RisMenu.Views
{
    /// <summary>
    /// Interaction logic for Login
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.passwordBox.Clear();
        }
    }
}