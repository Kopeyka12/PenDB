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

namespace PenDB
{
    //todo как искать имя файла окна
    /// <summary>
    /// Логика взаимодействия для WindowAddPen.xaml
    /// </summary>
    public partial class WindowAddPen : Window
    {
        public WindowAddPen()
        {
            InitializeComponent();
        }

        private void Button_Add_Book_Click(object sender, RoutedEventArgs e)
        {
            // Связывает WindowAddPen с главной формой
            MainWindow mForm = this.Owner as MainWindow;
            
            if (check_input())
            {
                string brend = textBox_Brend.Text;
                string color = textBox_Color.Text;
                string automatic = textBox_Automatic.Text;
                double thickness = double.Parse(textBox_Thickness.Text);
                int price = int.Parse(textBox_Price.Text);

                textBox_Brend.Text = "";
                textBox_Color.Text = "";
                textBox_Automatic.Text = "";
                textBox_Thickness.Text = "";
                textBox_Price.Text = "";

                mForm.Datapen.AddPen(brend, color, thickness, automatic, price);
                int n = mForm.Datapen.pens.Count;
            }
        }

        /// Проверка на правильность ввода и изменение цвета полей
        private bool check_input()
        {
            SolidColorBrush error_color = new SolidColorBrush();
            SolidColorBrush usual_color = new SolidColorBrush();

            ///цвет ошибочных полей 
            error_color.Color = Color.FromRgb(252, 187, 187);
            /////цвет полей обычный
            usual_color.Color = Colors.White;
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(textBox_Brend.Text))
            {
                textBox_Brend.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Brend.Background = usual_color;
            }

            if (string.IsNullOrWhiteSpace(textBox_Color.Text))
            {
                textBox_Color.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Color.Background = usual_color;
            }

            if (string.IsNullOrWhiteSpace(textBox_Automatic.Text))
            {
                textBox_Automatic.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Automatic.Background = usual_color;
            }

            double thick;
            if (!double.TryParse(textBox_Thickness.Text, out thick))
            {
                textBox_Thickness.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Thickness.Background = usual_color;
            }

            int price;
            if (!int.TryParse(textBox_Price.Text, out price))
            {
                textBox_Price.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Price.Background = usual_color;
            }
            return !hasError;
        }

        private void Button_Close_Form_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
