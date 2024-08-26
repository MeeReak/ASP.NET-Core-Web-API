using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.stock;
using api.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stock = _context.Stocks.ToList().Select(m => m.ToStockDto());
            return Ok(stock);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockDto createDto)
        {
            var stock = createDto.ToStockFromCreateDto();
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            stock.Symbol = updateDto.Symbol;
            stock.CompanyName = updateDto.CompanyName;
            stock.Industry = updateDto.Industry;
            stock.LastDiv = updateDto.LastDiv;
            stock.MarketCap = updateDto.MarketCap;
            stock.Purchase = updateDto.Purchase;

            _context.SaveChanges();

            return Ok(stock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stock == null)
            {
                return NotFound("Not Found Stock with this id");
            }

            _context.Stocks.Remove(stock);

            _context.SaveChanges();

            return NoContent();
        }
    }
}