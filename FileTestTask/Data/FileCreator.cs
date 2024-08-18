using FileTestTask.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Data
{
    public class FileCreator
    {
        private readonly DirectoryInfo directory;

        private readonly RecordCreator recordCreator;

        private readonly IRecordCreationService _recordCreationService;
        public FileCreator(string workDir, RecordCreator recordCreator, IRecordCreationService recordCreationService)
        {
            directory = new DirectoryInfo(workDir);
            if (!directory.Exists)
            {
                directory.Create();
            }
            this.recordCreator = recordCreator;
            _recordCreationService = recordCreationService;
        }

        public async Task Create()
        {
            for (int i = 0; i < 100; i++)
            {
                await GenerateFileAsync(GenerateFilename(i + 1));
            }
        }

        private string GenerateFilename(int fileNum)
        {
            return Path.Combine(directory.FullName, fileNum.ToString()) + ".txt";
        }

        private async Task GenerateFileAsync(string filename)
        {

            using (var writer = new StreamWriter(filename))
            {
                for (int i = 0; i < 100000; i++)
                {
                    await writer.WriteLineAsync(recordCreator.CreateRecord(_recordCreationService)
                        .ToString());
                }
            }
        }


    }
}
