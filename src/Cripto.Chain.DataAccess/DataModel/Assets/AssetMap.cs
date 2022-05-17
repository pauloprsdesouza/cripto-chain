using Cripto.Chain.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cripto.Chain.DataAccess.DataModel.Assets
{
    public static class AssetMap
    {
        public static void Configure(this EntityTypeBuilder<Asset> asset)
        {
            asset.ToTable("asset");

            asset.HasKey(p => p.Id);

            asset.Property(p => p.Id)
                 .ValueGeneratedOnAdd();

            asset.Property(p => p.Currency)
                 .IsRequired();

            asset.Property(p => p.CreatedAt)
                 .IsRequired();

            asset.HasMany(p => p.Wallets)
                 .WithOne(p => p.Asset)
                 .HasForeignKey(p => p.AssetId);
        }
    }
}
