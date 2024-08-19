using FileTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FileTestTask.Data
{
    public class Deserializer
    {
        public static Record DeserializeRecord(string serialized)
        {
            var props = serialized.Split("||");
            if (props.Length != 6)
            {
                throw new ArgumentException("Wrong record");
            }

            return new Record(DateTime.ParseExact(props[0], "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                props[1], props[2], int.Parse(props[3]), double.Parse(props[4]));
        }
    }
}
