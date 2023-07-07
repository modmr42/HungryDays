using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HungryItemController : ControllerBase
    {
        private readonly HungryItemService _hungryItemService;
        private readonly HungryItemFactory _hungryItemFactory;
        private readonly ILogger<HungryItemController> _logger;

        public HungryItemController(ILogger<HungryItemController> logger,
            HungryItemService hungryItemService, HungryItemFactory hungryItemFactory)
        {
            _logger = logger;
            _hungryItemService = hungryItemService;
            _hungryItemFactory = hungryItemFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _hungryItemService.GetAll();
            var model = entities.Select(x => _hungryItemFactory.ToDto(x));
            if (model == null)
                return NoContent();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var entity = await _hungryItemService.Get(id);
            if (entity == null)
                return NotFound();

            var model = _hungryItemFactory.ToDto(entity);
            return Ok(model);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(HungryItemDto dto)
        {
            if (dto == null)
                return BadRequest();

            var entity = _hungryItemFactory.ToEntity(dto);
            var entityFromDb = await _hungryItemService.Get(dto.Id);
            if(entityFromDb == null)
                return NotFound(dto.Id);

            entityFromDb.Update(entity);
            await _hungryItemService.Update(entityFromDb);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HungryItemDto dto)
        {
            if (dto == null)
                return BadRequest();

            var entity = _hungryItemFactory.ToEntity(dto);

            await _hungryItemService.Add(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var entity = await _hungryItemService.Get(id);

            if (entity == null)
                return NotFound();

            await _hungryItemService.Delete(id);

            return Ok();
        }
    }
}