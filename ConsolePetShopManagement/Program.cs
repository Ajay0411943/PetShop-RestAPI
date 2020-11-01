using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.DomainService;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.ApplicationService.Impl;
using PetShopApp.Infrastructure.Data.Repositories;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
