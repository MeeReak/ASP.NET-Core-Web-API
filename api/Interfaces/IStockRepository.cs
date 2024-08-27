using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.stock;
using api.models;
using api.utils;

namespace api.Interface
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAll(QueryObject query);
        Task<Stock?> GetById(int id);
        Task<Stock> Create(Stock stockModel);
        Task<Stock?> Update(int id, UpdateStockDto stockModel);
        Task<Stock?> Delete(int id);
        Task<bool> StockExist(int id);
    }
}