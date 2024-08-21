using FileTestTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Record> Records { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountClass> AccountClasses { get; set; }

        public DbSet<OriginFile> OriginFiles { get; set; }
    }
}
