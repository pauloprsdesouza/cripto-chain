using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Customers
{
    public static class CustomerMap
    {
        public static void Configure(this EntityTypeBuilder<Customer> customer)
        {
            customer.ToTable("customer");

            customer.HasKey(p => p.Id);

            customer.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

            customer.Property(p => p.Name)
                    .IsRequired();

            customer.Property(p => p.CreatedAt)
                    .IsRequired();

            customer.HasMany(p => p.Wallets)
                    .WithOne(p => p.Customer)
                    .HasForeignKey(p => p.CustomerId);
        }
    }
}
