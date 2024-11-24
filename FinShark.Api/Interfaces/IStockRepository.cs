using FinShark.Api.Dtos.Stock;
using FinShark.Api.Models;

namespace FinShark.Api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id,UpdateStockRequestDto requestDto);
        Task<Stock?> DeleteAsync(int id);
    }
}
