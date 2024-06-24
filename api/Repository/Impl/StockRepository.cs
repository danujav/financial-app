
using Microsoft.EntityFrameworkCore;

namespace api;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();

        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stockModel == null) return null;

        _context.Stocks.Remove(stockModel);

        await _context.SaveChangesAsync();

        return stockModel;
    }

    public async Task<List<Stock>> GetAllAsync(QueryObject queryObject)
    {
        var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));
        }
        if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(queryObject.CompanyName));
        }
        if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
        {
            if (queryObject.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = queryObject.IsDescending ? stocks.OrderByDescending(s => s.Symbol)
                : stocks.OrderBy(s => s.Symbol);
            }
        }

        return await stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> StockExists(int id)
    {
        return _context.Stocks.AnyAsync(s => s.Id == id);
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stockModel == null) return null;

        stockModel.Symbol = stockDto.Symbol;
        stockModel.CompanyName = stockDto.CompanyName;
        stockModel.Purchase = stockDto.Purchase;
        stockModel.Lastdiv = stockDto.Lastdiv;
        stockModel.Industry = stockDto.Industry;
        stockModel.MarketCap = stockDto.MarketCap;

        await _context.SaveChangesAsync();

        return stockModel;
    }
}
