using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Models
{
    public class Record
    {
        public DateTime Date { get; }

        public string LatinString { get; }

        public string CyrillicString { get; }

        public int OddNum { get; }

        public double FractionalNum { get; }

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
                Date.ToString("0:dd.mm.yy"),
                LatinString,
                CyrillicString,
                OddNum,
                FractionalNum,
                "");
        }

    }
}
