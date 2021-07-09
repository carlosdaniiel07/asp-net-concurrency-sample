using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Vouchers;
using TemplateNetCore.Domain.Interfaces.Users;
using TemplateNetCore.Domain.Interfaces.Vouchers;

namespace TemplateNetCore.Api.Controllers.Vouchers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;

        public VouchersController(IVoucherService voucherService, IUserService userService, IHttpContextAccessor httpContext)
        {
            _voucherService = voucherService;
            _userService = userService;
            _httpContext = httpContext;
        }

        [HttpPost("redeem")]
        public async Task<ActionResult<GetRedeemVoucherDto>> Redeem()
        {
            var userId = _userService.GetLoggedUserId(_httpContext.HttpContext.User);
            var voucher = await _voucherService.Redeem(userId);

            return Ok(new GetRedeemVoucherDto { Code = voucher.Code });
        }
    }
}
