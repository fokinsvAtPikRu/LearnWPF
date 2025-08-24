using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Lesson8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lesson8.Domain.Interfaces;
using Lesson8.Infrastructure.Data.Repositories;
using Lesson8.Presentation.ViewsModels;
using Lesson8.Presentation.Views;


namespace Lesson8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Database
            var builder = new ConfigurationBuilder();            
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");            
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // ViewsModels
            services.AddTransient<ProductViewModel>();

            // Views
            services.AddTransient<MainWindow>();
        }

    }

}
