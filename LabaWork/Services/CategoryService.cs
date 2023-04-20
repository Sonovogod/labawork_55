using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;

namespace LabaWork.Services;

public class CategoryService : ICategoryService
{
    private readonly ProductContext _db;

    public CategoryService(ProductContext db)
    {
        _db = db;
    }

    public List<CategoryViewModel> GetAll()
    {
        return _db.Category.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
 

    public Category? GetById(int id)
        => _db.Category.FirstOrDefault(x=> x.Id == id);

    public void Add(Category? section)
    {
        if (section == null) return;
        _db.Category.Add(section);
        _db.SaveChanges();
    }

    public void Delete(Category? section)
    {
        if (section == null) return;
        _db.Category.Remove(section);
        _db.SaveChanges();
    }

    public bool IsExist(string name)
        => _db.Category.Any(x => x.NormalizeName.Equals(name));
    
}