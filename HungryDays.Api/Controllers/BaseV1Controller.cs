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
            var identity = User.Identity as ClaimsIdentity;
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            return _context.Users.FirstOrDefault(u => u.Id == identityClaim.Value);
        }
    }
}
