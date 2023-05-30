using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Threading;

namespace PenDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Счетчик нажатий кнопки Сортировка
        int countCLICK = 0;

        public MainWindow()
        {
            InitializeComponent();
            /// todo
            /// как работает ItemSource
            datagrid.ItemsSource = Datapen.pens;
            //System.Windows.Threading.DispatcherTimer 
            //Label_Save.Visibility = Visibility.Hidden;
            //InitializeTimer();
        }
       
        public DBPen Datapen = new DBPen();
        public string filename = "";
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Button_Open_Click(sender, e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Button_Save_Click(sender, e);
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            string Info = "Разработчик: Мирошин В. И., студент группы ВМК-21\n\n";
            MessageBox.Show(Info, "О разработчике", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (filename == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult) return;
                filename = saveFileDialog.FileName;

            }
            Datapen.SaveDB(filename);
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPen addform = new WindowAddPen();
            addform.Owner = this;
            addform.Show();
        }

        private void Button_Sort_Click(object sender, RoutedEventArgs e)
        {
            countCLICK++; // увеличиваем счетчик на 1 при каждом нажатии на кнопку

            // проверяем значение счетчика и выполняем соответствующее действие
            if (countCLICK == 1)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Бренд", ListSortDirection.Ascending);
                //применяем сортировку
                datagrid.Items.SortDescriptions.Add(sortByName);
                //обновляем данные в таблице
                datagrid.Items.Refresh();
            }
            else if (countCLICK == 2)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Бренд", ListSortDirection.Descending);
                //удаление сущ.фильтрации
                datagrid.Items.SortDescriptions.Clear();
                //применяем сортировку
                datagrid.Items.SortDescriptions.Add(sortByName);
                //обновляем данные в таблице
                datagrid.Items.Refresh();
            }
            else
            {

                countCLICK = 0;
                datagrid.Items.SortDescriptions.Clear();
            }
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                //this.Text = filename + " - База данных книжного магазина";


                Datapen.OpenFile(filename);

            }
        }
    }
}
