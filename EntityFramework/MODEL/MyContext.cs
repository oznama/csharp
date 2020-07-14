using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
    class MyContext:DbContext
    {
        public MyContext()
        {

        }
        public DbSet<Table01> Table01 { get; set; }
        public DbSet<Table02> Table02 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ServerOziel"].ConnectionString);
            }
        }
    }
}
