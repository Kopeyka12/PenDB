// @author Мирошин В. И.
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
    
    //В совйствах MainWindow в разделе Общее можно в Icon задать путь к иконки приложения

    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = Datapen.pens;
        }
       
        public DBPen Datapen = new DBPen();
        public string filename = "";
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        //Обработчик событии при нажатии на кнопку из меню Открыть
        //обращаемся к обработчику событии из кнопки Открыть
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Button_Open_Click(sender, e);
        }
        
        //Обработчик событии при нажатии на кнопку из меню Сохранить
        //открывается диалоговое окно, где выбираем в какой файл сохранить базу данных
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (filename == "")
            {   //ShowDialog отображает форму как модальное диалоговое окно,
                //а вот DialogResultс задает идентификаторы, которые определяют возвращаемое значение диалогового окна (можем узнать, какую кнопку в окне сообщения нажал пользователь) 
                if (saveFileDialog.ShowDialog() == DialogResult) return;
                filename = saveFileDialog.FileName;

            }
            Datapen.SaveDB(filename);
        }
       
        //Обработчик событии при нажатии на кнопку из меню Автор
        //открывается окно с сообщением
        private void Author_Click(object sender, RoutedEventArgs e)
        {
            string Info = "Разработчик: Мирошин В. И., студент группы ВМК-21\n\n";
            MessageBox.Show(Info, "О разработчике", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Обработчик событии при нажатии на кнопку Добавить
        //Открывается окно новой формы 
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            //Сначала создаем объект WindowAddPen класса (для создание второго окна),
            //а потом для его отображения на экране вызываем метод Show.
            //У всех окон есть свойство Owner, которое указывает на главное окно, владеющее текущим окном.
            //То есть если  мы закроем MainWindow то и закроется WindowAddPen
            //Используя ссылку на окно, мы можем взаимодействовать с ним, например, передавать ему данные из главной формы или вызывать его методы.
            WindowAddPen addform = new WindowAddPen();
            addform.Owner = this;
            addform.Show();
        }

       
        //Обработчик событияя при нажатии кнопки Открыть
        //Открывает диалоговое окно, где мы открываем файл с базой данных
        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                Datapen.OpenFile(filename);

            }
        }


        // Обработчик события на нажатие кнопку Удалить все
        // Удаляет всю базу данных
        private void Button_Del_All_Click(object sender, RoutedEventArgs e)
        {
            Datapen.pens.Clear();
        }

        // Обработчик события на нажатие кнопку Удалить строку
        // Удаляет выделенную строчку из базы данных
        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            int ind = datagrid.SelectedIndex;
            Datapen.pens.RemoveAt(ind);
        }

        
    }
}
