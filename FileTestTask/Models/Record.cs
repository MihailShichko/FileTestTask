using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string LatinString { get; set; }

        public string CyrillicString { get; set; }

        public int OddNum { get; set; }

        public double FractionalNum { get; set; }

        public Record(DateTime date, string latinString, string cyrillicString, int oddNum, double fractionalNum)
        {
            Date = date;
            LatinString = latinString;
            CyrillicString = cyrillicString;
            OddNum = oddNum;
            FractionalNum = fractionalNum;
        }

        public override string ToString()
        {
            return string.Join("||",
                Date.ToString("dd.mm.yyyy"),
                LatinString,
                CyrillicString,
                OddNum,
                FractionalNum,
                "");
        }

    }
}
