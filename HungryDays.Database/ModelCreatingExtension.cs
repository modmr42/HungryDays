using HungryDays.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database
{
    public static class ModelCreatingExtension
    {
        public static void ConfigureModels(ModelBuilder modelBuilder)
        {
            HungryDayEntity.OnModelCreating(modelBuilder.Entity<HungryDayEntity>());
        }
    }
}
