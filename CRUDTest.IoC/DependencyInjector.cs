using CRUDTest.Application;
using CRUDTest.Application.Mapper;
using CRUDTest.Data;
using CRUDTest.Data.Repositories;
using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.IoC
{
    public static class DependencyInjector
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            //DBContext
            services.AddDbContext<MyDBContext>(options =>
            {
                options.UseSqlServer(connectionString: configuration.GetConnectionString("Default"));
            });

            //MediatR
            services.AddMediatR(typeof(ApplicationLayerEntryPoint).Assembly);

            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //AutoMapper
            services.AddAutoMapper(options =>
            {
                options.AddProfile(new MapperProfile());
            }, typeof(ApplicationLayerEntryPoint));

        }
    }
}
