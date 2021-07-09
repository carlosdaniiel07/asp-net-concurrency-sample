using System;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;

namespace TemplateNetCore.Domain.Interfaces.Vouchers
{
    public interface IVoucherService
    {
        Task<Voucher> Redeem(Guid userId);
    }
}
