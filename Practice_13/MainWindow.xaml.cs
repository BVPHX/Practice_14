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
using System.Data;

namespace Practice_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Authorization auth = new Authorization();
            auth.ShowDialog();
            if (auth.AuthorizationCheck == true) InitializeComponent();
            else Close();
        }
        private string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");
        public int[,] processedArray;
        private DataTable res = new DataTable();

        private void InfoButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработал Шестаков Артём ИСП-31 \nВариант №7 \nВвести n целых чисел. Вычислить для чисел < 0 функцию x2.Результат обработки каждого числа вывести на экран");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Завершить работу программы?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(res == MessageBoxResult.Yes) Close();
        }

        private void ResultOutputButtonClick(object sender, RoutedEventArgs e)
        {
            if (inputBox.Text == null || inputBox.Text == "") MessageBox.Show("Данные не введены.");
            else
            {
                res = new DataTable();
                resultGrid.ItemsSource = null;
                resultGrid.Items.Clear();
                resultGrid.Columns.Clear();
                MatrixEdit.Fill(Convert.ToInt32(inputBox.Text), out processedArray);


                for (int i = 0; i < processedArray.GetLength(0); i++)
                {
                    res.Columns.Add("column " + i.ToString(), typeof(string));
                }
                for (int j = 0; j < processedArray.GetLength(0); j++)
                {
                    DataRow row = res.NewRow();
                    for (int i = 0; i < processedArray.GetLength(1); i++)
                    {
                        row[i] = processedArray[i, j];

                    }
                    res.Rows.Add(row);
                    resultGrid.ItemsSource = res.DefaultView;
                }
                Size.Text = processedArray.GetLength(0).ToString();
            }
        }
        public void SaveButton_click(object sender, RoutedEventArgs e)
        {

            MatrixEdit.SaveMatrix(path, processedArray);
        }
        public void OpenButton_click(object sender, RoutedEventArgs e)
        {
            MatrixEdit.OpenArray(path, out int[,] savedArray);
            res = new DataTable();
            resultGrid.ItemsSource = null;
            resultGrid.Items.Clear();
            resultGrid.Columns.Clear();


            for (int i = 0; i < savedArray.GetLength(0); i++)
            {
                res.Columns.Add("column " + i.ToString(), typeof(string));
            }
            for (int i = 0; i < savedArray.GetLength(0); i++)
            {
                DataRow row = res.NewRow();
                for (int j = 0; j < savedArray.GetLength(1); j++)
                {
                    row[j] = savedArray[j, i];
                }
                res.Rows.Add(row);
                resultGrid.ItemsSource = res.DefaultView;
            }
        }
        private void TextEditing(object sender, TextChangedEventArgs e)
        {
            resultGrid.ItemsSource = null;
        }

        private void resultGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedCell.Text = resultGrid.CurrentColumn.DisplayIndex.ToString(); 
            selectedCell.Text +="," + resultGrid.CurrentColumn.DisplayIndex.ToString();
        }
    }
}
