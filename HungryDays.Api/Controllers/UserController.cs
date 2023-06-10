using HungryDays.Database.Entities;
using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<HungryUserEntity> _userManager;

        private readonly ILogger<HungryDayController> _logger;

        public UserController(ILogger<HungryDayController> logger,
            UserManager<HungryUserEntity> userManager)
        {
            _logger = logger;

            _userManager = userManager;
        }

        [HttpPost]
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