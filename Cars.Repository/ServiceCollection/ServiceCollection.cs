using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Repository.ServiceCollection
{
    public static class ServiceCollection
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CarsConnection")));
            services.AddScoped<ICarRepository, CarRepository>();
            //services.AddScoped<ICarRepository, CarRepository>);
        }

    }
}
