using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Transacitons
{
    public static class TransactionMap
    {
         public static void Configure(this EntityTypeBuilder<Transaction> transaction)
        {
            transaction.ToTable("transaction");

            transaction.HasKey(p => p.Id);

            transaction.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

            transaction.Property(p => p.CreditWalletId)
                       .ValueGeneratedNever();

            transaction.Property(p => p.DebitWalletId)
                       .ValueGeneratedNever();

            transaction.Property(p => p.Amount)
                       .IsRequired();

            transaction.Property(p => p.CreatedAt)
                       .IsRequired();
        }
    }
}
