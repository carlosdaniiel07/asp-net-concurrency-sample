using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Repository.Interfaces.Vouchers;

namespace TemplateNetCore.Repository.EF.Repositories.Vouchers
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
