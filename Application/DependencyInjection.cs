using MediatR; // mediator library
using Microsoft.Extensions.DependencyInjection; //aseembly
using System;
using System.Collections.Generic;// iservices collection
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
