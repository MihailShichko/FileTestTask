using FileTestTask.Services.Exel;
using FileTestTask.Services.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

using WinForms = System.Windows.Forms;


namespace FileTestTask.Views
{
    /// <summary>
    /// Interaction logic for TaskTwo.xaml
    /// </summary>
    public partial class TaskTwo : Page
    {
        private readonly ExcelService _excelService;
        private readonly OriginFileRepository _originFileRepository;
        private readonly AccountClassRepository _accountClassRepository;
        private readonly AccountRepository _accountRepository;
        public TaskTwo(ExcelService excelService, OriginFileRepository originFileRepository,
            AccountRepository accountRepository, AccountClassRepository accountClassRepository)
        {
            _originFileRepository = originFileRepository;
            _excelService = excelService;
            _accountRepository = accountRepository;
            _accountClassRepository = accountClassRepository;
            InitializeComponent();
        }

        private async void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog openFileDialog = new WinForms.OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            string filePath;
            if (openFileDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                return;
            }

            ImportTextBlock.Visibility = Visibility.Visible;
            ImportTextBlock.Text = "Process...";
            await _excelService.Import(filePath);
            ClassBox.ItemsSource = (await _accountClassRepository.GetAll()).Select(ac => ac.ClassName).ToList();
            ImportTextBlock.Text = "Done";
        }

        private async void ShowFilesButton_Click(object sender, RoutedEventArgs e)
        {
            FileList.ItemsSource = (await _originFileRepository.GetAll()).Select(o => o.Name).ToList();
            FileList.Visibility = Visibility.Visible;
        }

        private async void ClassBox_Selected(object sender, RoutedEventArgs e)
        {
            AccountList.ItemsSource = (await _accountRepository.GetAll()).Where(
                a => a.Class.ClassName == ClassBox.Text).ToList();
            AccountList.Visibility = Visibility.Visible;
        }

        private async void ClassBox_Loaded(object sender, RoutedEventArgs e)
        {
            ClassBox.ItemsSource = (await _accountClassRepository.GetAll()).Select(ac => ac.ClassName).ToList();

        }
    }
}
