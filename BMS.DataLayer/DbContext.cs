using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BMS.DataLayer
{
   public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;database=BookManagement;trusted_connection=true");
        }

        public DbSet<DataModel.Publisher> Publishers { get; set; }
        public DbSet<DataModel.Author> Authors { get; set; }
        public DbSet<DataModel.Book> Books { get; set; }
        public DbSet<DataModel.User> AppUser { get; set; }
    }
}
