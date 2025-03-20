using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<Cart> GetCartByIdAsync(int id)
    {
        return await _context.Set<Cart>().FindAsync(id);
    }

    public async Task<IEnumerable<Cart>> GetAllCartsAsync()
    {
        return await _context.Set<Cart>().ToListAsync();
    }

    public async Task AddCartAsync(Cart cart)
    {
        await _context.Set<Cart>().AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        _context.Set<Cart>().Update(cart);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCartAsync(int id)
    {
        var cart = await GetCartByIdAsync(id);
        if (cart != null)
        {
            _context.Set<Cart>().Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
