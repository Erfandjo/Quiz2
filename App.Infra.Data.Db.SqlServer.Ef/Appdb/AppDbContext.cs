using App.Domain.Core.Quiz2.Card.Entities;
using App.Domain.Core.Quiz2.Transaction.Entities;
using App.Domain.Core.Quiz2.User.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Configuration;
using Microsoft.EntityFrameworkCore;


namespace App.Infra.Data.Db.SqlServer.Ef.Appdb
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.Configuration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}