using LabaWork.Models;
using LabaWork.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LabaWork.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _db;

    public ProductService(ProductContext db)
    {
        _db = db;
    }


    public List<Product> GetAll()
    {
        var products = _db.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToList();

        return products;
    }

    public Product? GetById(int id)
    {
        var products = GetAll();
        return products.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Product? product)
    {
        if (product == null) return;
        product.NormalizeName = product.ProductName.Trim().ToUpper();
        product.DateOfCreate = DateTime.Now;
        product.DateOfUpdate = DateTime.Now;
        _db.Products.Add(product);
        _db.SaveChanges();
    }

    public void EditProduct(Product? product)
    {
        if (product == null) return;
        product.NormalizeName = product.ProductName.Trim().ToUpper();
        product.DateOfUpdate = DateTime.Now;
        _db.Products.Update(product);
        _db.SaveChanges();
    }

    public void DeleteProduct(Product? product)
    {
        if (product == null) return;
        _db.Products.Remove(product);
        _db.SaveChanges();
    }
}