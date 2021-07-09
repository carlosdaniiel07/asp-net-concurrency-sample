using System.Collections.Generic;

namespace TemplateNetCore.Domain.Entities.Vouchers
{
    public class Voucher : BaseEntity
    {
        public string Code { get; set; }
        public IEnumerable<UserVoucher> UserVouchers { get; set; }
    }
}
