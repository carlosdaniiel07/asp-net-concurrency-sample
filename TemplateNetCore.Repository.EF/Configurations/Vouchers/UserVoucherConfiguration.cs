using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TemplateNetCore.Domain.Entities.Vouchers;

namespace TemplateNetCore.Repository.EF.Configurations.Users
{
    public class UserVoucherConfiguration : BaseEntityConfiguration<UserVoucher>
    {
        public override void Configure(EntityTypeBuilder<UserVoucher> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_voucher");

            builder.Property(entity => entity.VoucherId)
                .HasColumnName("voucher_id")
                .IsRequired();

            builder.Property(entity => entity.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(entity => entity.Voucher)
                .WithMany(dest => dest.UserVouchers)
                .HasForeignKey(entity => entity.VoucherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_user_voucher_voucher")
                .IsRequired();

            builder.HasOne(entity => entity.User)
                .WithMany()
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_user_voucher_user")
                .IsRequired();
        }
    }
}
