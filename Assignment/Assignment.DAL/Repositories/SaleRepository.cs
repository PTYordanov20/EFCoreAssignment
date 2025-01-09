using Assignment.DAL.Interfaces;
using Assignment.DM.Models;

public class SaleRepository : ISaleRepository
{
    private readonly List<Sale> _sales = new()
    {
        new Sale { SaleId = 1, CustomerId = 1, ProductId = 1, Quantity = 1, SaleDate = DateTime.Parse("2023-11-20"), TotalPrice = 699.99 },
        new Sale { SaleId = 2, CustomerId = 2, ProductId = 2, Quantity = 2, SaleDate = DateTime.Parse("2023-11-22"), TotalPrice = 240.00 },
        new Sale { SaleId = 3, CustomerId = 3, ProductId = 3, Quantity = 3, SaleDate = DateTime.Parse("2023-11-25"), TotalPrice = 256.50 }
    };

    public Task<IEnumerable<Sale>> GetAllSalesAsync() => Task.FromResult((IEnumerable<Sale>)_sales);

    public Task<Sale> GetSaleByIdAsync(int id) => Task.FromResult(_sales.FirstOrDefault(s => s.SaleId == id));

    public Task<Sale> CreateSaleAsync(Sale sale)
    {
        sale.SaleId = _sales.Max(s => s.SaleId) + 1;
        _sales.Add(sale);
        return Task.FromResult(sale);
    }

    public Task<Sale> UpdateSaleAsync(int id, Sale updatedSale)
    {
        var sale = _sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null) return Task.FromResult<Sale>(null);
        sale.CustomerId = updatedSale.CustomerId;
        sale.ProductId = updatedSale.ProductId;
        sale.Quantity = updatedSale.Quantity;
        sale.SaleDate = updatedSale.SaleDate;
        sale.TotalPrice = updatedSale.TotalPrice;
        return Task.FromResult(sale);
    }

    public Task<bool> DeleteSaleAsync(int id)
    {
        var sale = _sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null) return Task.FromResult(false);
        _sales.Remove(sale);
        return Task.FromResult(true);
    }
}