using System;
using TemplateNetCore.Domain.Entities.Users;

namespace TemplateNetCore.Domain.Entities.Vouchers
{
    public class UserVoucher : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid VoucherId { get; set; }
        public Voucher Voucher { get; set; }
    }
}
