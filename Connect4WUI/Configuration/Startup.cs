using Connect4Library.Configuration;
using Connect4Library.Interfaces;
using Connect4WUI.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Connect4WUI.Configuration
{
    public class Startup
    {
        public static void Configure(IServiceCollection services)
        {
            services.ConfigureDAL();
            services.AddScoped<IWinEngine<Ellipse>, WinEngine>();
        }
    }
}
