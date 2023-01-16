using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testowyKolos
{
    class bazaKlientow : DbContext
    {
        public DbSet<clients> clients { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<products> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=bazaKlientow.db");
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
