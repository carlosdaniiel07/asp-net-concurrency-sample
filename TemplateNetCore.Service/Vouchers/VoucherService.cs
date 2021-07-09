using System;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Vouchers;
using TemplateNetCore.Domain.Interfaces.Users;
using TemplateNetCore.Domain.Interfaces.Vouchers;
using TemplateNetCore.Repository;
using TemplateNetCore.Service.Exceptions;

namespace TemplateNetCore.Service.Vouchers
{
    public class VoucherService : IVoucherService
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IUserService _userService;

        public VoucherService(IUnityOfWork unityOfWork, IUserService userService)
        {
            _unityOfWork = unityOfWork;
            _userService = userService;
        }

        public async Task<Voucher> Redeem(Guid userId)
        {
            var user = await _userService.GetById(userId);
            var voucher = await _unityOfWork.VoucherRepository.GetAvailableVoucher();

            if (voucher == null)
            {
                throw new NotFoundException("Nenhum voucher disponível");
            }

            var userVoucher = new UserVoucher
            {
                User = user,
                Voucher = voucher,
            };

            await _unityOfWork.UserVoucherRepository.AddAsync(userVoucher);
            await _unityOfWork.CommitAsync();

            return voucher;
        }
    }
}
