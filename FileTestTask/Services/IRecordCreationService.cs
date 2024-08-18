using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Services
{
    public interface IRecordCreationService
    {
        public int getOddNum();

        public DateTime getDate(int years);

        public string getString(string alphabet, int length);

        public double getFractional(int signs, int range);
    }
}
