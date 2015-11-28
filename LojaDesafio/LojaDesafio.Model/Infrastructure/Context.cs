using LojaDesafio.Model.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Model.Infrastructure
{
    public class Context : DbContext
    {
        public Context () : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<TransactionProduct> TransactionProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().HasRequired(t => t.CreditCard);

            modelBuilder.Entity<CreditCard>().HasKey(c => c.Id);

            modelBuilder.Entity<TransactionProduct>().HasKey(tp => tp.Id);
            modelBuilder.Entity<TransactionProduct>().HasRequired(tp => tp.Transaction);
            modelBuilder.Entity<TransactionProduct>().HasRequired(tp => tp.Product);

            base.OnModelCreating(modelBuilder);
        }
    }
}
