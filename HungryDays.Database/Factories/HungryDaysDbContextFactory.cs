using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Factories
{
    public class HungryDaysDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public HungryDaysDbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public HungryDaysDbContext CreateDatabaseContext()
            => _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<HungryDaysDbContext>();
    }
}
