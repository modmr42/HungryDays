using HungryDays.Database.Entities;
using HungryDays.Database;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HungryDays.Api.Controllers
{
    public abstract class BaseV1Controller : ControllerBase
    {
        private readonly HungryDaysDbContext _context;
        public BaseV1Controller(HungryDaysDbContext context) //todo make userrepository out of this
        {
            _context = context;
        }

        [NonAction]
        public HungryUserEntity GetCurrentUser()
        {
            var identity = User.Identity.Name;

            return _context.Users.FirstOrDefault(u => u.UserName == identity) ?? throw new Exception("No user found with this name");
        }
    }
}
