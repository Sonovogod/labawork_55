using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;

namespace LabaWork.Services;

public class BrandService : IBrandService
{
    private readonly ProductContext _db;

    public BrandService(ProductContext db)
    {
        _db = db;
    }

    public List<BrandViewModel> GetAll()
    {
        return _db.Brand.Select(b => new BrandViewModel
        {
            Id = b.Id,
            Name = b.Name
        }).ToList();
    }
 

    public Brand? GetById(int id)
        => _db.Brand.FirstOrDefault(x=> x.Id == id);

    public void Add(Brand? section)
    {
        if (section == null) return;
        _db.Brand.Add(section);
        _db.SaveChanges();
    }

    public void Delete(Brand? section)
    {
        if (section == null) return;
        _db.Brand.Remove(section);
        _db.SaveChanges();
    }

    public bool IsExist(string name) 
        => _db.Brand.Any(x => x.NormalizeName.Equals(name));
    
}