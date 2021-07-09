using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Repository.Interfaces;

namespace TemplateNetCore.Repository.EF.Repositories.Vouchers
{
    public class UserVoucherRepository : Repository<UserVoucher>, IRepository<UserVoucher>
    {
        public UserVoucherRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
