using LabaWork.Extensions;
using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LabaWork.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _db;

    public ProductService(ProductContext db)
    {
        _db = db;
    }


    public List<ProductViewModel> GetAll()
    {
        var products = _db.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .Select(product => ProductExtension.MapToProductViewModel(product))
            .ToList();

        return products;
    }

    public ProductViewModel? GetById(int id)
    {
        List<ProductViewModel> productViewModels = GetAll();
        ProductViewModel productViewModel = productViewModels.FirstOrDefault(x => x.Id == id);
        
        return productViewModel;
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