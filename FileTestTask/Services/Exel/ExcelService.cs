using FileTestTask.Models;
using FileTestTask.Services.Repository;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Services.Exel
{
    public class ExcelService
    {
        private readonly AccountRepository _accountRepository;
        private readonly AccountClassRepository _accountClassRepository;
        private readonly OriginFileRepository _originFileRepository;

        public ExcelService(IRepository<AccountClass> accountClassRepository, IRepository<Account> accountRepository, IRepository<OriginFile> originFileRepository)
        {
            this._accountClassRepository = (AccountClassRepository)accountClassRepository;
            this._accountRepository = (AccountRepository)accountRepository;
            this._originFileRepository = (OriginFileRepository)originFileRepository;
        }

        public async Task Import(string path)
        {
            var stream = new FileInfo(path);
            using var excelPackage = new ExcelPackage(stream);

            var filename = Path.GetFileName(path);  
            
            var accounts = new List<Account>();
            var classes = new List<AccountClass>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var worksheet = excelPackage.Workbook.Worksheets[0];

            var rows = worksheet.Dimension.End.Row;

            var startColumn = findStartColumn(worksheet);
            var startRow = findStartRow(worksheet, startColumn);

            var OriginFile = new OriginFile
            {
                Name = filename
            };

            string value;

            for (int i = startRow; i < rows; i++)
            {
                if (worksheet.Cells[i, startColumn, i, startColumn].Merge) //Class
                {
                    value = worksheet.Cells[i, startColumn, i, startColumn].Text;

                    var className = getClassName(value);
                    var classIndex = getClassIndex(value);
                    classes.Add(new AccountClass
                    {
                        ClassIndex = classIndex,
                        ClassName = className,
                        OriginFile = OriginFile
                    });
                    for (int j = i + 1; j < rows; j++) //Accounts
                    {
                        var cell = worksheet.Cells[j, startColumn, j, startColumn];
                        if (cell.Merge) //if next class
                        {
                            j--;
                            i = j;
                            break;
                        }
                        if (cell.Style.Font.Bold)//if result 
                        {
                            continue;
                        }

                        var account = new Account
                        {
                            Number = int.Parse(worksheet.Cells[j, startColumn, j, startColumn].Value.ToString()),
                            OpeningBalanceActive = double.Parse(worksheet.Cells[j, startColumn + 1, j, startColumn + 1].Value.ToString()),
                            OpeningBalancePassive = double.Parse(worksheet.Cells[j, startColumn + 2, j, startColumn + 2].Value.ToString()),
                            DebitTurnover = double.Parse(worksheet.Cells[j, startColumn + 3, j, startColumn + 3].Value.ToString()),
                            CreditTurnover = double.Parse(worksheet.Cells[j, startColumn + 4, j, startColumn + 4].Value.ToString()),
                            ClosingBalanceActive = double.Parse(worksheet.Cells[j, startColumn + 5, j, startColumn + 5].Value.ToString()),
                            ClosingBalancePassive = double.Parse(worksheet.Cells[j, startColumn + 6, j, startColumn + 6].Value.ToString()),
                            Class = new AccountClass
                            {
                                ClassIndex = classIndex,
                                ClassName = className,
                                OriginFile = OriginFile
                            }
                        };

                        accounts.Add(account);
                    }



                }
            }


            await importOriginFile(OriginFile);
            await importClasses(classes);
            await importAcounts(accounts);
        }

        private async Task importOriginFile(OriginFile file)
        {
            if (!(await _originFileRepository.AddInstance(file)))
            {
                throw new Exception("Trouble with adding origin file");
            }
        }

        private async Task importAcounts(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                if (!(await _accountRepository.AddInstance(account)))
                {
                    throw new Exception("Trouble with Adding account instance");
                }
            }

        }

        private async Task importClasses(List<AccountClass> classes)
        {
            foreach (var accountClass in classes)
            {
                if (!(await _accountClassRepository.AddInstance(accountClass)))
                {
                    throw new Exception("Trouble with Adding account class instance");
                }
            }
        }

        private async Task importOriginFiles(OriginFile file)
        {
            if (!(await _originFileRepository.AddInstance(file)))
            {
                throw new Exception("Trouble with Adding account class instance");
            }
        }

        private int findStartColumn(ExcelWorksheet worksheet)
        {
            int column = 1;
            for (int i = 1; i < worksheet.Columns.EndColumn; i++)
            {
                if (string.IsNullOrEmpty(worksheet.Cells[1, i, 1, i].Value.ToString())) 
                {
                    column++;
                }
                else
                {
                    break;
                }
            }

            return column;
        }

        private int findStartRow(ExcelWorksheet worksheet, int startColumn)
        {
            int row = 1;
            for (int i = 1; i < worksheet.Rows.EndRow; i++)
            {
                if(worksheet.Cells[i, startColumn, i, startColumn].Value == null)
                {
                    row++;
                }
                else if (isClassRow(worksheet.Cells[i, startColumn, i, startColumn + 6]))
                {
                    break;
                }
                else
                {
                    row++;
                }
            }

            return row;
        }

        private bool isClassRow(ExcelRange excelRange)
        {
            return excelRange.Text.Contains("КЛАСС");
        }

        private int getClassIndex(string value)
        {
            string cleanedInput = new string(value.Where(c => char.IsDigit(c) || c == '.').ToArray());
            if (string.IsNullOrWhiteSpace(cleanedInput))
            {
                return 0;
            }

            if (int.TryParse(cleanedInput, out int result))
                return result;
            else
                return 0;
        }
        private string getClassName(string value)
        {
            int spaceIndex = value.IndexOf(' ', value.IndexOf(' ') + 2);
            if (spaceIndex == -1)
                return string.Empty;

            return value.Substring(spaceIndex + 1).Trim();
        }
    }
}
