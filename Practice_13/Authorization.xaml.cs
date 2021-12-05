using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice_13
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public bool AuthorizationCheck { get; set; }
        private string Password { get; set; }
        public Authorization()
        {
            InitializeComponent();
            Password = "123";
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Text == Password)
            {
                AuthorizationCheck = true;
                Close();
            }
            else MessageBox.Show("Неверный пароль.");
        }
    }
}
