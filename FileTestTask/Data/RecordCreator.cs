using FileTestTask.Models;
using FileTestTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FileTestTask.Data
{
    public class RecordCreator
    {
        public Record CreateRecord(IRecordCreationService recordCreationService)
        {
            return new Record(recordCreationService.getDate(5),
                recordCreationService.getString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 10),
                recordCreationService.getString("абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ", 10),
                recordCreationService.getOddNum(),
                recordCreationService.getFractional(8, 20));
        }
    }
}
