using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets
{
    public static class WalletMap
    {
        public static void Configure(this EntityTypeBuilder<Wallet> wallet)
        {
            wallet.ToTable("wallet");

            wallet.HasKey(p => p.Id);

            wallet.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

            wallet.Property(p => p.AssetId)
                  .ValueGeneratedNever();

            wallet.Property(p => p.CustomerId)
                  .ValueGeneratedNever();

            wallet.Property(p => p.CreatedAt)
                       .IsRequired();

            wallet.HasMany(p => p.DebitTransactions)
                  .WithOne(p => p.DebitWallet)
                  .HasForeignKey(p => p.DebitWalletId);

            wallet.HasMany(p => p.CreditTransactions)
                  .WithOne(p => p.CreditWallet)
                  .HasForeignKey(p => p.CreditWalletId);
        }
    }
}
