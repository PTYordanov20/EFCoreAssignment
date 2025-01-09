using Assignment.DM.Models;

public interface ISaleRepository
{
   Task<IEnumerable<Sale>> GetAllSalesAsync();
   Task<Sale> GetSaleByIdAsync(int id);
   Task<Sale> CreateSaleAsync(Sale sale);
   Task<Sale> UpdateSaleAsync(int id, Sale sale);
   Task<bool> DeleteSaleAsync(int id);
}