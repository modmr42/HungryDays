using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database
{
    class HungryDaysDbContext : DbContext
    {
        private IConfiguration Configuration { get; }


        public HungryDaysDbContext(DbContextOptions<HungryDaysDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

    }
}
