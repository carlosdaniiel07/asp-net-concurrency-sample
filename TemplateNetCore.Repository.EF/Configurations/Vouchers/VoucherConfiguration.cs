using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TemplateNetCore.Domain.Entities.Vouchers;

namespace TemplateNetCore.Repository.EF.Configurations.Users
{
    public class VoucherConfiguration : BaseEntityConfiguration<Voucher>
    {
        public override void Configure(EntityTypeBuilder<Voucher> builder)
        {
            base.Configure(builder);

            builder.ToTable("voucher");

            builder.HasIndex(entity => entity.Code)
                .IsUnique();

            builder.Property(entity => entity.Code)
                .HasColumnName("code")
                .HasMaxLength(7)
                .HasColumnType("CHAR(7)")
                .IsRequired();
        }
    }
}
