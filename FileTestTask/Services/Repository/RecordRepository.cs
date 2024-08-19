using FileTestTask.DataBase;
using FileTestTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Services.Repository
{
    public class RecordRepository : IRepository<Record>
    {
        private readonly ApplicationDbContext _context;
        public RecordRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddInstance(Record instance)
        {
            await _context.Records.AddAsync(instance);
            return await Save();
        }

        public bool DeleteInstance(int id)
        {
            //var oldRecord = _context.Records.FirstOrDefault(r => r.Id == id);
            //_context.Records.Remove(oldRecord);
            //return Save();
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Record>> GetAll()
        {
            return await _context.Records.ToListAsync();
        }

        public async Task<Record> GetByIdAsync(int id)
        {
            return await _context.Records.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UpdateInstance(Record instance)
        {
            //var oldRecord = _context.Records.FirstOrDefault(r => r.Id == instance.Id);
            //oldRecord.FractionalNum = instance.FractionalNum;
            //oldRecord.OddNum = instance.OddNum;
            //oldRecord.CyrillicString = instance.CyrillicString;
            //oldRecord.LatinString = instance.LatinString;
            //oldRecord.Date = instance.Date;
            //return Save();
            throw new NotImplementedException();
        }
    }
}
