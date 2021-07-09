using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;

namespace TemplateNetCore.Repository.Interfaces.Vouchers
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> GetAvailableVoucher();
    }
}
