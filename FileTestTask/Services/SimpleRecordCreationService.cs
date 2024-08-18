using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Services
{
    public class SimpleRecordCreationService : IRecordCreationService
    {
        private Random rand = new Random();

        public int getOddNum()
        {
            return rand.Next(1, 100000000) * 2;
        }

        public DateTime getDate(int years)
        {
            DateTime start = DateTime.Today.AddYears(-years);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        public string getString(string alphabet, int length)
        {
            return new string(Enumerable.Repeat(alphabet, length)
                .Select(s => s[rand.Next(s.Length)])
                .ToArray());
        }

        public double getFractional(int signs, int range)
        {
            return Math.Round((double)rand.Next(range) + rand.NextDouble(), signs);
        }
    }
}
