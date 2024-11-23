using Invoice.Domain.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Data.Mappers;

public class ContractMap : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder
            .ToTable("contracts");
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id_contract");
        builder
            .Property(x => x.Description)
            .HasColumnName("description");
        builder
            .Property(x => x.Amount)
            .HasColumnName("amount");
        builder
            .Property(x => x.Periods)
            .HasColumnName("periods");
        builder
            .Property(x => x.Date)
            .HasColumnName("created_date");
    }
}
