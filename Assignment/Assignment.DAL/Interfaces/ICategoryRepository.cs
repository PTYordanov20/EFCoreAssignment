using Assignment.DM.Models;

public interface ICategoryRepository
{
   Task<IEnumerable<Category>> GetAllCategoriesAsync();
   Task<Category> GetCategoryByIdAsync(int id);
   Task<Category> CreateCategoryAsync(Category category);
   Task<Category> UpdateCategoryAsync(int id, Category category);
   Task<bool> DeleteCategoryAsync(int id);
}