using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using FunnyTranslator.Core.Entities;

namespace FunnyTranslator.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppLog> Logs { get; set; }

        public AppDbContext() : base("AppDbContext")
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
