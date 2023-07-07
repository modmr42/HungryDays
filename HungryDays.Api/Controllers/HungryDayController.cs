﻿using HungryDays.Domain.Factories;
using HungryDays.Domain.Models;
using HungryDays.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HungryDayController : ControllerBase
    {
        private readonly HungryDayService _hungryDayService;
        private readonly HungryDayFactory _hungryDayFactory;

        private readonly ILogger<HungryDayController> _logger;

        public HungryDayController(ILogger<HungryDayController> logger,
            HungryDayService hungryDayService, HungryDayFactory hungryDayFactory)
        {
            _logger = logger;
            _hungryDayService = hungryDayService;
            _hungryDayFactory = hungryDayFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _hungryDayService.GetAll();
            var model = entities.Select(x => _hungryDayFactory.ToDto(x));
            if(model == null)
                return NoContent();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entityFromDb = await _hungryDayService.Exists(id);

            if (!entityFromDb)
                return BadRequest();

            var entity = await _hungryDayService.Get(id);
            if(entity == null)
                return NotFound();

            var model = _hungryDayFactory.ToDto(entity);
            return Ok(model);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(HungryDayDto dto)
        {
            var entityFromDb = await _hungryDayService.Exists(dto.Id);

            if (!entityFromDb)
                return BadRequest();

            var entity =  _hungryDayFactory.ToEntity(dto);
            await _hungryDayService.Update(entity);

            return Ok();//Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Reset(Guid id)
        {
            var entityFromDb = await _hungryDayService.Exists(id);

            if (!entityFromDb)
                return BadRequest();

            var entity = await _hungryDayService.Get(id);

            if(entity != null)
                await _hungryDayService.Reset(id);

            return Ok();
        }


    }
}