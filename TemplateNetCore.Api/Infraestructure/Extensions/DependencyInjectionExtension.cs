using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TemplateNetCore.Domain.Interfaces.Users;
using TemplateNetCore.Domain.Interfaces.Vouchers;
using TemplateNetCore.Repository;
using TemplateNetCore.Repository.EF;
using TemplateNetCore.Repository.EF.Repositories;
using TemplateNetCore.Repository.Interfaces;
using TemplateNetCore.Service.Users;
using TemplateNetCore.Service.Vouchers;

namespace TemplateNetCore.Api.Infraestructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging();
            });
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnityOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHashService, HashService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IVoucherService, VoucherService>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, string secretKey)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            return services;
        }
    }
}
