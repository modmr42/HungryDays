using HungryDays.Database;
using HungryDays.Database.Entities;
using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Models.Auth;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseV1Controller
    {
        private readonly UserManager<HungryUserEntity> _userManager;
        private readonly HungryDayService _hungryDayService;
        private readonly JwtService _jwtService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger,
            UserManager<HungryUserEntity> userManager, JwtService jwtService, HungryDayService hungryDayService, HungryDaysDbContext dbContext) : base(dbContext)
        {
            _logger = logger;
            _jwtService = jwtService;
            _userManager = userManager;
            _hungryDayService = hungryDayService;
        }

        // POST: api/Users/Create
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(HungryUserDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var entity = HungryUserFactory.ToEntity(dto);

            try
            {
                var result = await _userManager.CreateAsync(entity, dto.Password);
                
                if(!result.Succeeded)
                    return BadRequest(result.Errors);

                var user = await _userManager.FindByNameAsync(dto.UserName);
                await _hungryDayService.CreateHungryDaysForNewUserAsync(user.Id);


                dto.Password = String.Empty;
                return Created("",dto);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex);
#endif
                return BadRequest();
            }
        }

        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var entityFromDb = await _hungryDayService.Exists(id);

        //    if (!entityFromDb)
        //        return BadRequest();

        //    var entity = await _hungryDayService.Get(id);
        //    if(entity == null)
        //        return NotFound();

        //    var model = _hungryDayFactory.ToDto(entity);
        //    return Ok(model);
        //}

        //[HttpPost("{id}")]
        //public async Task<IActionResult> Update(HungryDayDto dto)
        //{
        //    var entityFromDb = await _hungryDayService.Exists(dto.Id);

        //    if (!entityFromDb)
        //        return BadRequest();

        //    var entity =  _hungryDayFactory.ToEntity(dto);
        //    await _hungryDayService.Update(entity);

        //    return Ok();//Created();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Reset(Guid id)
        //{
        //    var entityFromDb = await _hungryDayService.Exists(id);

        //    if (!entityFromDb)
        //        return BadRequest();

        //    var entity = await _hungryDayService.Get(id);

        //    if(entity != null)
        //        await _hungryDayService.Reset(id);

        //    return Ok();
        //}


    }
}