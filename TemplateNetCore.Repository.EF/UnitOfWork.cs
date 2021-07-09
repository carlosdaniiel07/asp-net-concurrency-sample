using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Repository.EF.Repositories.Users;
using TemplateNetCore.Repository.EF.Repositories.Vouchers;
using TemplateNetCore.Repository.Interfaces;
using TemplateNetCore.Repository.Interfaces.Users;
using TemplateNetCore.Repository.Interfaces.Vouchers;

namespace TemplateNetCore.Repository.EF
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext context;

        private UserRepository _userRepository;
        private VoucherRepository _voucherRepository;
        private UserVoucherRepository _userVoucherRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }

                return _userRepository;
            }
        }

        public IVoucherRepository VoucherRepository
        {
            get
            {
                if (_voucherRepository == null)
                {
                    _voucherRepository = new VoucherRepository(context);
                }

                return _voucherRepository;
            }
        }

        public IRepository<UserVoucher> UserVoucherRepository
        {
            get
            {
                if (_userVoucherRepository == null)
                {
                    _userVoucherRepository = new UserVoucherRepository(context);
                }

                return _userVoucherRepository;
            }
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(context);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
