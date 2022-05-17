using Cripto.Chain.DataAccess.DataModel.Assets;
using Cripto.Chain.Domain.Assets;
using Cripto.Chain.Domain.Customers;
using Cripto.Chain.Domain.Transactions;
using Cripto.Chain.Domain.Wallets;
using Microsoft.EntityFrameworkCore;
using Cripto.Chain.DataAccess.DataModel.Customers;
using Cripto.Chain.DataAccess.DataModel.Transacitons;
using Cripto.Chain.DataAccess.DataModel.Wallets;

namespace Cripto.Chain.DataAccess.Context
{
    public class ApiDbContext : DbContext
    {
        public const string Schema = "criptochain";

        public ApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Asset>().Configure();
            modelBuilder.Entity<Customer>().Configure();
            modelBuilder.Entity<Transaction>().Configure();
            modelBuilder.Entity<Wallet>().Configure();
        }
    }
}
