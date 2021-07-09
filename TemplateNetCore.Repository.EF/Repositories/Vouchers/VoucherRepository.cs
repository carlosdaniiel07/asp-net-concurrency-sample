using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Repository.Interfaces.Vouchers;

namespace TemplateNetCore.Repository.EF.Repositories.Vouchers
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Voucher> GetAvailableVoucher()
        {
            return await dbSet.FirstOrDefaultAsync(voucher => !voucher.UserVouchers.Any());
        }
    }
}
