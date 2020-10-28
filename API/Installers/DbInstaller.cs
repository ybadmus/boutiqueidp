using API.Services;
using CoreFlogger;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.Data;
using src.Models;

namespace API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var configs = new LogConfig();
            configuration.Bind("Weblog", configs);
            services.AddSingleton(configs);

            var connectionString = configuration["connectionStrings:DefaultConnection"];
            services.AddDbContext<BoutiqueContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<AuthenticationContext>(o => o.UseSqlServer(connectionString));

            services.AddDefaultIdentity<ApplicationUser>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AuthenticationContext>();

            services.AddScoped<IUserRepo, UserRepo>();
            //services.AddScoped<IDatabaseRepo, DatabaseRepo>();
            //services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
