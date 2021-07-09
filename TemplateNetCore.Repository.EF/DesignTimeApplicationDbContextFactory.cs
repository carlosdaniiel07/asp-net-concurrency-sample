using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TemplateNetCore.Repository.EF
{
    public class DesignTimeApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer("Server=DESKTOP-52NHAEM;Database=asp-net-concurrency-sample;Trusted_Connection=True;");

            return new ApplicationDbContext(builder.Options);
        }
    }
}
