using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.SaleNumber);
        builder.Property(s => s.SaleDate).IsRequired();
        builder.Property(s => s.Customer).IsRequired().HasMaxLength(100);
        builder.Property(s => s.TotalSaleAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(s => s.Branch).IsRequired().HasMaxLength(50);
        builder.Property(s => s.IsCancelled).IsRequired();

        builder.HasMany(s => s.Items)
               .WithOne()
               .HasForeignKey(i => i.Id)
               .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsMany(s => s.Items, item =>
        {
            item.Property(i => i.Product).IsRequired().HasMaxLength(100);
            item.Property(i => i.Quantity).IsRequired();
            item.Property(i => i.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            item.Property(i => i.Discount).IsRequired().HasColumnType("decimal(18,2)");
            item.Property(i => i.IsCancelled).IsRequired();
        }).ToTable("SaleItems");
    }
}
