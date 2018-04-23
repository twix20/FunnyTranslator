using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Core.Entities;

namespace FunnyTranslator.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppLog> Logs { get; set; }

        public AppDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppLog>().HasKey(m => m.Id);
            builder.Entity<AppLog>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
