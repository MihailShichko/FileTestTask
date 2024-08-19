using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Automation;

namespace FileTestTask.Data
{
    public static class FileManipulations
    {
        public static async Task MergeFiles(string dirPath, string fileName)
        {
            var directory = new DirectoryInfo(dirPath);
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException("Directory can not be found");
            }

            var combinedFile = Path.Combine(directory.FullName, fileName);
            using (var writer = new StreamWriter(combinedFile))
            {
                foreach (var file in directory.GetFiles())
                {
                    if (file.Name == fileName) continue;
                    string filePath = Path.Combine(directory.FullName, file.Name);
                    using (var reader = new StreamReader(filePath))//пытается мердж сделать с мерждем
                    {
                        await writer.WriteLineAsync(reader.ReadToEnd());
                    }
                }
            }

           //return combinedFile;
        }

        public static async Task<int> RemoveSubstringFromFiles(string dirPath, string substring, string filename)
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException("Directory can not be found.");
            }

            int counter = 0;
            string combinedFile = Path.Combine(directory.FullName, filename);
            using (var writer = new StreamWriter(combinedFile))
            {
                foreach (var file in directory.GetFiles())
                {
                    if (file.Name == filename) continue;
                    string filePath = Path.Combine(directory.FullName, file.Name);


                    using (var reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            if (!line.Contains(substring))
                            {
                                await writer.WriteLineAsync(line);
                            }
                            else counter++;
                        }
                    }

                }
            }

            return counter;
        }

        public static int CountLines(string path)
        {
            return File.ReadAllLines(path).Count();
        }
    }
}
