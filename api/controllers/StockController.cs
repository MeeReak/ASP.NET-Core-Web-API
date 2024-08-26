using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.stock;
using api.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using api.Interface;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock = await _stockRepo.GetAll();

            var stk = stock.Select(m => m.ToStockDto());
            return Ok(stk);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetById(id);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createDto)
        {
            var stock = createDto.ToStockFromCreateDto();
            await _stockRepo.Create(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto)
        {
            var stock = await _stockRepo.Update(id, updateDto);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            return Ok(stock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepo.Delete(id);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            return NoContent();
        }
    }
}