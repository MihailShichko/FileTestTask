using WinForms = System.Windows.Forms;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FileTestTask.Data;
using FileTestTask.Services;





namespace FileTestTask.Views
{
    public partial class TaskOne : Page
    {
        DirectoryInfo workDir = null;
        public TaskOne()
        {
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
            if (workDir == null)
            {
                MessageBox.Show("Error, you have to choose directory", "ERROR",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DirText.Text = "In process...";

            var fileCreator = new FileCreator(workDir.FullName, new RecordCreator(), new SimpleRecordCreationService());
            await fileCreator.Create();
            
            DirText.Text = "Done";
            
            MergeFilesButton.Visibility = Visibility.Visible;
            FilterTextBlock.Visibility = Visibility.Visible;
            FilterTextBox.Visibility = Visibility.Visible;
        }

        private async void MergeFilesButton_Click(object sender, RoutedEventArgs e)
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

            if(count != null) 
            {
                MergingResultTextBlock.Text = "Deleted lines: " + count.ToString();
            }
            else
            {
                MergingResultTextBlock.Text = "Done Merging";
            }

        }

        private async void ImportButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
