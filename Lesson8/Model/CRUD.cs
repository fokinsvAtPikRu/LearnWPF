using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lesson8.Model
{
    internal class CRUD
    {
        internal ApplicationContext GetDBContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config=builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlite(connectionString).Options;
        }
        internal static void Create(Product product)
        {
            using (ApplicationContext db= new ApplicationContext())
            { }
        }
    }
}
