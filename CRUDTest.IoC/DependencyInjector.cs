using CRUDTest.Application;
using CRUDTest.Data.DBContext;
using CRUDTest.Data.Repositories;
using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Repositories;
using MediatR;
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
        public static void Inject(IServiceCollection services)
        {
            //DBContext
            services.AddSingleton<IDBContext, MyDBContext>();

            //MediatR
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);

            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();


        }
    }
}
