using AzureFunction.DependyInjection.Sample.Repository.Books;
using AzureFunction.DependyInjection.Sample.Repository.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AzureFunction.DependyInjection.Sample
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DBContext>(options =>
                    {
                        options.UseSqlServer(Environment.GetEnvironmentVariable("DbConnectionString"));
                    });
                    services.AddTransient<ICatalogRepository, CatalogRepository>();
                    services.AddTransient<IBookRepository, BookRepository>();
                })
                .Build();


            host.Run();
        }
    }
}