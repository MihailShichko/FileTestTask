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
    public class AccountClassRepository : IRepository<AccountClass>
    {
        private readonly ApplicationDbContext _context;
        public AccountClassRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddInstance(AccountClass instance)
        {
            await _context.AccountClasses.AddAsync(instance);
            return await Save();
        }

        public bool DeleteInstance(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountClass>> GetAll()
        {
            return await _context.AccountClasses.ToListAsync();
        }

        public Task<AccountClass> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UpdateInstance(AccountClass instance)
        {
            throw new NotImplementedException();
        }
    }
}
