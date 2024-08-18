using FileTestTask.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;

///TODO
///Сделать выбор места для объединенного файла через проводник
///Не дваать пользователю заруинить методом выбора первой таски, ввода данных => вторая таска => опять первая
/// 
/// 
/// 

namespace FileTestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TaskOne_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TaskOne());
        }

        private void TaskTwo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TaskTwo());
        }
    }
}