using Connect4Library.DAL.Context;
using Connect4Library.DAL.Interfaces.IWinnerRepositories;
using Connect4Library.DAL.Repositories;
using Connect4Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Connect4Library.Configuration
{
    public static class Configuration
    {
        public static void ConfigureDAL(this IServiceCollection services)
        {
            string connectionString = GetConnectionString("appsettings.json", "WinnerConnection");
            services.AddScoped<IWinnerRepository, WinnerRepository>();
            services.AddDbContext<WinnerContext>(options => options.UseSqlServer(connectionString));
        }
        private static string GetConnectionString(string jsonFileName, string connectionStringName)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(jsonFileName);
            var config = builder.Build();
            return config.GetConnectionString(connectionStringName);
        }
    }
}
