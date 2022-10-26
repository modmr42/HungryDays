using HungryDays.Database.Entities;
using HungryDays.Database.Repositories;
using HungryDays.Domain.Factories;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HungryDayController : ControllerBase
    {
        private readonly HungryDayRepository _hungryDayRepository;
        private readonly HungryDayFactory _hungryDayFactory;

        private readonly ILogger<HungryDayController> _logger;

        public HungryDayController(ILogger<HungryDayController> logger,
            HungryDayRepository hungryDayRepository, HungryDayFactory hungryDayFactory)
        {
            _logger = logger;
            _hungryDayRepository = hungryDayRepository;
            _hungryDayFactory = hungryDayFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _hungryDayRepository.GetHungryDaysAsync();
            var model = entities.Select(x => _hungryDayFactory.ToDto(x));
            if(model == null)
                return NoContent();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id < 0)
                return BadRequest();

            var entity = await _hungryDayRepository.GetHungryDayAsync(id);
            if(entity == null)
                return NotFound();

            var model = _hungryDayFactory.ToDto(entity);
            return Ok(model);
        }


    }
}