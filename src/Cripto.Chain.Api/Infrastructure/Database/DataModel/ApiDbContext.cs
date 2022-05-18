using Cripto.Chain.Api.Infrastructure.Database.DataModel.Assets;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Customers;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Transacitons;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets;
using Microsoft.EntityFrameworkCore;

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
