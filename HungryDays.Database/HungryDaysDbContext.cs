using HungryDays.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database
{
    public class HungryDaysDbContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public DbSet<HungryDayEntity> HungryDays { get; set; }

        public DbSet<HungryItemEntity> HungryItems { get; set; }


        public HungryDaysDbContext(DbContextOptions<HungryDaysDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelCreatingExtension.ConfigureModels(modelBuilder);
        }
    }
}
