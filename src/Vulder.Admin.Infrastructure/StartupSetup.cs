using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vulder.Admin.Infrastructure.Data;

namespace Vulder.Admin.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDb(this IServiceCollection collection, string connectionString)
            => collection.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }
}
