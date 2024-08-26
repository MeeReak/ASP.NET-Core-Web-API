using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.stock;
using api.Interface;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> Create(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> Delete(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null)
            {
                return null;
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAll()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetById(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> Update(int id, UpdateStockDto stockModel)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null)
            {
                return null;
            }

            stock.Symbol = stockModel.Symbol;
            stock.CompanyName = stockModel.CompanyName;
            stock.Industry = stockModel.Industry;
            stock.LastDiv = stockModel.LastDiv;
            stock.MarketCap = stockModel.MarketCap;
            stock.Purchase = stockModel.Purchase;

            await _context.SaveChangesAsync();

            return stock;
        }
    }
}