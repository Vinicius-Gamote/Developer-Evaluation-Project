using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new();
    public bool IsCancelled { get; set; }

    public event Action<SaleEvent> SaleEventPublished;

    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        CalculateTotal();
        PublishEvent(new SaleModifiedEvent(this));
    }

    public void CancelSale()
    {
        IsCancelled = true;
        PublishEvent(new SaleCancelledEvent(this));
    }

    public void CancelItem(int itemId)
    {
        var item = Items.Find(i => i.Id == itemId);
        if (item != null)
        {
            item.IsCancelled = true;
            CalculateTotal();
            PublishEvent(new ItemCancelledEvent(this, item));
        }
    }

    private void CalculateTotal()
    {
        TotalSaleAmount = 0;
        foreach (var item in Items)
        {
            if (!item.IsCancelled)
                TotalSaleAmount += item.TotalAmount;
        }
    }

    private void PublishEvent(SaleEvent saleEvent)
    {
        SaleEventPublished?.Invoke(saleEvent);
    }
}

public class SaleItem
{
    public int Id { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount => (UnitPrice * Quantity) - Discount;
    public bool IsCancelled { get; set; }
}

public abstract class SaleEvent
{
    public Sale Sale { get; }

    protected SaleEvent(Sale sale)
    {
        Sale = sale;
    }
}

public class SaleCreatedEvent : SaleEvent
{
    public SaleCreatedEvent(Sale sale) : base(sale) { }
}

public class SaleModifiedEvent : SaleEvent
{
    public SaleModifiedEvent(Sale sale) : base(sale) { }
}

public class SaleCancelledEvent : SaleEvent
{
    public SaleCancelledEvent(Sale sale) : base(sale) { }
}

public class ItemCancelledEvent : SaleEvent
{
    public SaleItem Item { get; }

    public ItemCancelledEvent(Sale sale, SaleItem item) : base(sale)
    {
        Item = item;
    }
}
