using Microsoft.Extensions.DependencyInjection;
using NZSBH.Application.Dxos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using NZSBH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Api
{
    public static class IoCExtentions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Book>, Repository<Book>>();
            services.AddTransient<IRepository<Publisher>, Repository<Publisher>>();
            services.AddTransient<IRepository<BookCategory>, Repository<BookCategory>>();
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IPublishersService, PublishersService>();
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IPublishersRepository, PublishersRepository>();
            services.AddTransient<IBookCategoriesService, BookCategoriesService>();
            services.AddTransient<IBookCategoriesDxos, BookCategoriesDxos>();
            services.AddTransient<IBookCategoriesRepository, BookCategoriesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
