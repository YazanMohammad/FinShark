using FinShark.Api.Data;
using FinShark.Api.Dtos.Stock;
using FinShark.Api.Interfaces;
using FinShark.Api.Mappers;
using FinShark.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IStockRepository _stockRepo;

        public StockController(IStockRepository stockRepo)
        {

            _stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stocks = await _stockRepo.GetAllAsync();
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStock)
        {
            var stockModel = createStock.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateReq)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateReq);
            if (stockModel == null) { return NotFound(); }
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
