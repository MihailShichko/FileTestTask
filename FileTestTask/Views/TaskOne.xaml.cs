using WinForms = System.Windows.Forms;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FileTestTask.Data;
using FileTestTask.Services;
using FileTestTask.Services.Repository;
using FileTestTask.Models;





namespace FileTestTask.Views
{
    public partial class TaskOne : Page
    {
        DirectoryInfo workDir = null;

        private readonly RecordRepository _recordRepository;

        public TaskOne(RecordRepository repository)
        {
            _recordRepository = (RecordRepository)repository;
            InitializeComponent();
        }

        private void ChooseDirButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderBrowserDialog = new WinForms.FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (folderBrowserDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                workDir = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                DirText.Text = "directory is " + workDir.Name;
            }
            
        }

        private async void CreateFilesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (workDir == null)
                {
                    throw new Exception("Directory is not chooosen");
                }

                DirText.Text = "In process...";

                var fileCreator = new FileCreator(workDir.FullName, new RecordCreator(), new SimpleRecordCreationService());
                await fileCreator.Create();

                DirText.Text = "Done";

                MakeVisible(new FrameworkElement[] { MergeFilesButton, FilterTextBlock, FilterTextBox });
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private async void MergeFilesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MergingResultTextBlock.Text = "In process...";
                var filter = FilterTextBox.Text;
                int? count = null;


                if (filter != null && filter != "")
                {
                    count = await FileManipulations.RemoveSubstringFromFiles(workDir.FullName, filter, "merged.txt");
                }
                else
                {
                    await FileManipulations.MergeFiles(workDir.FullName, "merged.txt");
                }

                if (count != null)
                {
                    MergingResultTextBlock.Text = "Deleted lines: " + count.ToString();
                }
                else
                {
                    MergingResultTextBlock.Text = "Done Merging";
                }

                MakeVisible(new FrameworkElement[] { ImportButton, ImportProgress });
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private async void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (workDir == null)
                {
                    throw new Exception("Directory is not chooosen");
                }

                ImportProgressText.Visibility = Visibility.Visible;
                var filePath = Path.Combine(workDir.FullName, "merged.txt");
                var lines = FileManipulations.CountLines(filePath);
                ImportProgress.Maximum = lines;
                ImportProgress.Value = 0;
                int value = 0;
                ImportProgressText.Text = $"{value}/{lines}";
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream) 
                    {
                        var recordString = await reader.ReadLineAsync();
                        var record = Deserializer.DeserializeRecord(recordString);
                        await _recordRepository.AddInstance(record);
                        ImportProgress.Value += 1;
                        ImportProgressText.Text = $"{++value}/{lines}";
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            ImportProgress.Visibility = Visibility.Hidden;
            ImportProgressText.Text = "Done";
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MakeVisible(FrameworkElement[] controls)
        {
            foreach(var control in controls)
            {
                control.Visibility = Visibility.Visible;
            }
        }
    }
}
