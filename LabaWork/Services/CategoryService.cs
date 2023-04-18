using LabaWork.Models;
using LabaWork.Services.Abstract;

namespace LabaWork.Services;

public class CategoryService : ISectionService<Category>
{
    private readonly ProductContext _db;

    public CategoryService(ProductContext db)
    {
        _db = db;
    }

    public List<Category> GetAll()
        => _db.Categories.ToList();
 

    public Category? GetById(int id)
        => _db.Categories.FirstOrDefault(x=> x.Id == id);

    public void Add(Category? section)
    {
        if (section == null) return;
        _db.Categories.Add(section);
        _db.SaveChanges();
    }

    public void Delete(Category? section)
    {
        if (section == null) return;
        _db.Categories.Remove(section);
        _db.SaveChanges();
    }

    public bool IsExist(string name)
        => _db.Categories.Any(x => x.NormalizeName.Equals(name));
    
}