using FileTestTask.Models;
using FileTestTask.Services.Exel;
using FileTestTask.Services.Repository;
using FileTestTask.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
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

        private readonly RecordRepository _recordRepository;

        private readonly AccountClassRepository _accountClassRepository;

        private readonly AccountRepository _accountRepository;

        private readonly OriginFileRepository _originFileRepository;

        private readonly ExcelService _excelService;

        public MainWindow(IRepository<Record> repository, IRepository<Account> accountRepository,
            IRepository<AccountClass> accountClassRepository, ExcelService excelService,
            IRepository<OriginFile> originFileRepository)
        {
            _recordRepository = (RecordRepository)repository;
            _accountClassRepository = (AccountClassRepository)accountClassRepository;
            _accountRepository = (AccountRepository)accountRepository;
            _excelService = excelService;
            InitializeComponent();
            _originFileRepository = (OriginFileRepository)originFileRepository;
        }

        private void TaskOne_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TaskOne(_recordRepository));
        }

        private void TaskTwo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TaskTwo(_excelService, _originFileRepository, _accountRepository, _accountClassRepository));
        }

        
    }
}