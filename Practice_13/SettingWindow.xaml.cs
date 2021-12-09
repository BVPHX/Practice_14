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
using System.IO;

namespace Practice_13
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        private string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void settingsCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void settingsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter save = new StreamWriter(path))
            {
                save.WriteLine(settingsInput.Text);
                
            }
            Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int a) != true) e.Handled = false;  /*settingsInput.Text.Remove(settingsInput.Text.IndexOf(e.Text));*/
        }
    }
}
