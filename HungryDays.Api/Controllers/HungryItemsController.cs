using HungryDays.Database;
using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HungryItemsController : BaseV1Controller
    {
        private readonly HungryItemService _hungryItemService;
        private readonly HungryItemFactory _hungryItemFactory;
        private readonly ILogger<HungryItemsController> _logger;
        public HungryItemsController(ILogger<HungryItemsController> logger,
            HungryItemService hungryItemService, HungryItemFactory hungryItemFactory, HungryDaysDbContext context) : base(context)
        {
            _logger = logger;
            _hungryItemService = hungryItemService;
            _hungryItemFactory = hungryItemFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = GetCurrentUser();
            var entities = await _hungryItemService.GetAll(user.Id);
            var model = entities.Select(x => _hungryItemFactory.ToDto(x));
            if (model == null)
                return NoContent();

            return Ok(model);
        }

        [HttpGet("hungryitem/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var user = GetCurrentUser();

            var entity = await _hungryItemService.Get(id, user.Id);
            if (entity == null)
                return NotFound();

            var model = _hungryItemFactory.ToDto(entity);
            return Ok(model);
        }

        [HttpPost("hungryitem/{id}")]
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

        [HttpPost("hungryitem")]
        public async Task<IActionResult> Create(HungryItemDto dto)
        {
            if (dto == null)
                return BadRequest();

            var entity = _hungryItemFactory.ToEntity(dto);

            await _hungryItemService.Add(entity);

            return Ok();
        }
    }
}