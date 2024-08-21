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
    public class AccountRepository : IRepository<Account>
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddInstance(Account instance)
        {
            await _context.Accounts.AddAsync(instance);
            return await Save();
        }

        public bool DeleteInstance(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UpdateInstance(Account instance)
        {
            throw new NotImplementedException();
        }
    }
}
