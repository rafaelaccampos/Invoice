using Invoice.Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Data.Payments.Mappers;

public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .ToTable("payments");
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id_payment");
        builder
            .Property(x => x.IdContract)
            .HasColumnName("id_contract");
        builder
            .Property(x => x.Amount)
            .HasColumnName("amount");
        builder
            .Property(x => x.Date)
            .HasColumnName("created_date");
        builder
            .HasOne(x => x.Contract)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.IdContract)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
