using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NZSBH.Application.Dxos;
using NZSBH.Contracts;
using NZSBH.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Application.Extentions
{
    public static class ApplicationExtentions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationExtentions)));
            services.AddScoped<IBooksDxos, BooksDxos>();
            services.AddScoped<IPublishersDxos, PublishersDxos>();
            AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>().ForEach(pair =>
            {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                services.Add(ServiceDescriptor.Transient(pair.ValidatorType, pair.ValidatorType));

            });
        }
    }
}
