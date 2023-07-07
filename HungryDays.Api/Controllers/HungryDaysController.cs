using HungryDays.Database;
using HungryDays.Database.Entities;
using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HungryDays.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HungryDaysController : BaseV1Controller
    {
        private readonly HungryDayService _hungryDayService;
        private readonly HungryDayFactory _hungryDayFactory;
        private readonly UserManager<HungryUserEntity> _userManager;
        private readonly ILogger<HungryDaysController> _logger;

        public HungryDaysController(ILogger<HungryDaysController> logger,
            HungryDayService hungryDayService, HungryDayFactory hungryDayFactory, HungryDaysDbContext context, UserManager<HungryUserEntity> userManager) : base(context)
        {
            _logger = logger;
            _hungryDayService = hungryDayService;
            _hungryDayFactory = hungryDayFactory;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = GetCurrentUser();
            var entities = await _hungryDayService.GetAll(user.Id);
            var model = entities.Select(x => _hungryDayFactory.ToDto(x));
            if(model == null)
                return NoContent();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = GetCurrentUser();
            var entityFromDb = await _hungryDayService.Exists(id, user.Id);

            if (!entityFromDb)
                return BadRequest();

            var entity = await _hungryDayService.Get(id, user.Id);
            if(entity == null)
                return NotFound();

            var model = _hungryDayFactory.ToDto(entity);
            return Ok(model);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(HungryDayDto dto)
        {
            var user = GetCurrentUser();
            var entityFromDb = await _hungryDayService.Exists(dto.Id, user.Id);

            if (!entityFromDb)
                return BadRequest();

            var entity =  _hungryDayFactory.ToEntity(dto);
            await _hungryDayService.Update(entity);

            return Ok();//Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Reset(Guid id)
        {
            var user = GetCurrentUser();
            var entityFromDb = await _hungryDayService.Exists(id, user.Id);

            if (!entityFromDb)
                return BadRequest();

            var entity = await _hungryDayService.Get(id);

            if(entity != null)
                await _hungryDayService.Reset(id);

            return Ok();
        }


    }
}