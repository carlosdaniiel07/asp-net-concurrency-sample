using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Repository.Interfaces;
using TemplateNetCore.Repository.Interfaces.Users;
using TemplateNetCore.Repository.Interfaces.Vouchers;

namespace TemplateNetCore.Repository
{
    public interface IUnityOfWork
    {
        IUserRepository UserRepository { get; }
        IVoucherRepository VoucherRepository { get; }
        IRepository<UserVoucher> UserVoucherRepository { get; }

        IDatabaseTransaction BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}
