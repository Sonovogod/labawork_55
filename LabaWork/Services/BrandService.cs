using LabaWork.Models;
using LabaWork.Services.Abstract;

namespace LabaWork.Services;

public class BrandService : ISectionService<Brand>
{
    private readonly ProductContext _db;

    public BrandService(ProductContext db)
    {
        _db = db;
    }

    public List<Brand> GetAll()
        => _db.Brands.ToList();
 

    public Brand? GetById(int id)
        => _db.Brands.FirstOrDefault(x=> x.Id == id);

    public void Add(Brand? section)
    {
        if (section == null) return;
        _db.Brands.Add(section);
        _db.SaveChanges();
    }

    public void Delete(Brand? section)
    {
        if (section == null) return;
        _db.Brands.Remove(section);
        _db.SaveChanges();
    }

    public bool IsExist(string name) 
        => _db.Brands.Any(x => x.NormalizeName.Equals(name));
    
}