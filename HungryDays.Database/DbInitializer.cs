using HungryDays.Database.Entities;
using HungryDays.Database.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database
{
    public static class DbInitializer
    {
        //public static void WaitOnDbCreated(ILogger logger)
        //{
        //    logger.LogDebug("Waiting on database...");
        //    Task.Delay(5000).Wait();
        //    logger.LogDebug("Done waiting on database...");
        //}

        public static void Initialize(HungryDaysDbContextFactory factory)
        {
            var context = factory.CreateDatabaseContext();

            //Apply migrations to the database
            context.Database.Migrate();

            return;//test

            //If dummy data already exists return;
            if (context.HungryDays.Any())
                return;

            #region DbFill
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var hungryDays = new List<HungryDayEntity>();
            for (int i = 0; i < days.Length; i++) //todo delete auto increment of hungrydays id
            {
                hungryDays.Add(
                    new HungryDayEntity
                    {
                        Day = days[i],
                        Diner = "Still not decided",
                        HungryItems = new List<HungryItemEntity>()
                        {
                                new HungryItemEntity()
                                {
                                    Name ="Ingredient",
                                    Quantity = 1,
                                    Store = "Ah",
                                    Bought = true,
                                }
                        }
                    });
            }

            context.HungryDays.AddRange(hungryDays);
            #endregion

            context.SaveChanges();

            return;
        }
    }
}
