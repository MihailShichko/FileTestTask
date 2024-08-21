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
    public class OriginFileRepository: IRepository<OriginFile>
    {
        private readonly ApplicationDbContext _context;
        public OriginFileRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddInstance(OriginFile instance)
        {
            await _context.OriginFiles.AddAsync(instance);
            return await Save();
        }

        public bool DeleteInstance(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OriginFile>> GetAll()
        {
            return await _context.OriginFiles.ToListAsync();
        }

        public Task<OriginFile> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;//tut
        }

        public bool UpdateInstance(OriginFile instance)
        {
            throw new NotImplementedException();
        }

    }
}
