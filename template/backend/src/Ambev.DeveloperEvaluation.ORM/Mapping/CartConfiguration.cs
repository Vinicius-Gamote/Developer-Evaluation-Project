using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(c => c.Id);
        builder.HasKey(c => c.UserId);
        builder.Property(c => c.Date).IsRequired();

        builder.OwnsOne(c => c.CartProducts, item =>
        {
            item.Property(i => i.ProductId).IsRequired();
            item.Property(i => i.Quantity).IsRequired();
        }).ToTable("CartProducts");

    }
}
