using FinShark.Api.Data;
using FinShark.Api.Dtos.Stock;
using FinShark.Api.Interfaces;
using FinShark.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Api.Repos
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context) { _context = context; }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }
        //Delete Item by ID
        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }
        //Get all items
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }
        //Get an item by ID
        public async Task<Stock?> GetByIdAsync(int id)
        {
            var result = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(Stock => Stock.Id == id);
            if (result == null) { return null; }
            return result;
        }
        //Update
        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateReq)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(st => st.Id == id);
            if (stock == null) { return null; };

            stock.Symbol = updateReq.Symbol;
            stock.CompanyName = updateReq.CompanyName;
            stock.Purchase = updateReq.Purchase;
            stock.LastDiv = updateReq.LastDiv;
            stock.Industry = updateReq.Industry;
            stock.MarketCap = updateReq.MarketCap;

            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
