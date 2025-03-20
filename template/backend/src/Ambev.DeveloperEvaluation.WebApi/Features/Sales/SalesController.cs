using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private static readonly List<Sale> Sales = new();
    private static int _nextSaleNumber = 1;

    [HttpPost]
    public IActionResult CreateSale([FromBody] Sale sale)
    {
        sale.SaleNumber = _nextSaleNumber++;
        sale.SaleDate = DateTime.UtcNow;
        Sales.Add(sale);

        foreach (var item in sale.Items)
            item.Validate();

        sale.SaleEventPublished += OnSaleEventPublished;
        sale.PublishEvent(new SaleCreatedEvent(sale));

        return CreatedAtAction(nameof(GetSale), new { id = sale.SaleNumber }, sale);
    }

    [HttpGet("{id}")]
    public IActionResult GetSale(int id)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleNumber == id);
        if (sale == null)
            return NotFound();

        return Ok(sale);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSale(int id, [FromBody] Sale updatedSale)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleNumber == id);
        if (sale == null)
            return NotFound();
        
        foreach (var item in updatedSale.Items)
            item.Validate();

        sale.Customer = updatedSale.Customer;
        sale.Branch = updatedSale.Branch;
        sale.Items = updatedSale.Items;
        sale.CalculateTotal();

        sale.PublishEvent(new SaleModifiedEvent(sale));

        return Ok(sale);
    }

    [HttpDelete("{id}")]
    public IActionResult CancelSale(int id)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleNumber == id);
        if (sale == null)
            return NotFound();

        sale.CancelSale();

        return Ok(new { Message = "Sale cancelled successfully" });
    }

    [HttpDelete("{saleId}/items/{itemId}")]
    public IActionResult CancelItem(int saleId, int itemId)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleNumber == saleId);
        if (sale == null)
            return NotFound();

        sale.CancelItem(itemId);

        return Ok(new { Message = "Item cancelled successfully" });
    }

    private void OnSaleEventPublished(SaleEvent saleEvent)
    {
        // Handle event publishing logic (e.g., logging, messaging, etc.)
        Console.WriteLine($"Event published: {saleEvent.GetType().Name}");
    }
}
