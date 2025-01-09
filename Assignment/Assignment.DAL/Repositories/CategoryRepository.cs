using Assignment.DAL.Interfaces;
using Assignment.DM.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new()
    {
        new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and gadgets" },
        new Category { CategoryId = 2, Name = "Furniture", Description = "Home and office furniture" },
        new Category { CategoryId = 3, Name = "Clothing", Description = "Apparel and accessories" }
    };

    public Task<IEnumerable<Category>> GetAllCategoriesAsync() => Task.FromResult((IEnumerable<Category>)_categories);

    public Task<Category> GetCategoryByIdAsync(int id) => Task.FromResult(_categories.FirstOrDefault(c => c.CategoryId == id));

    public Task<Category> CreateCategoryAsync(Category category)
    {
        category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
        _categories.Add(category);
        return Task.FromResult(category);
    }

    public Task<Category> UpdateCategoryAsync(int id, Category updatedCategory)
    {
        var category = _categories.FirstOrDefault(c => c.CategoryId == id);
        if (category == null) return Task.FromResult<Category>(null);
        category.Name = updatedCategory.Name;
        category.Description = updatedCategory.Description;
        return Task.FromResult(category);
    }

    public Task<bool> DeleteCategoryAsync(int id)
    {
        var category = _categories.FirstOrDefault(c => c.CategoryId == id);
        if (category == null) return Task.FromResult(false);
        _categories.Remove(category);
        return Task.FromResult(true);
    }
}