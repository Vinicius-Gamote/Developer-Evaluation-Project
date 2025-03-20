using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> GetSaleByIdAsync(int id)
    {
        return await _context.Set<Sale>().FindAsync(id);
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync()
    {
        return await _context.Set<Sale>().ToListAsync();
    }

    public async Task AddSaleAsync(Sale sale)
    {
        await _context.Set<Sale>().AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSaleAsync(Sale sale)
    {
        _context.Set<Sale>().Update(sale);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSaleAsync(int id)
    {
        var sale = await GetSaleByIdAsync(id);
        if (sale != null)
        {
            _context.Set<Sale>().Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}

