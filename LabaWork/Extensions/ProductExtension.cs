using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Extensions;

public static class ProductExtension
{
    public static ShortProductViewModel MapToShortProductViewModel(Product product)
    {
        return new ShortProductViewModel()
        {
            Id = product.Id,
            ProductName = product.ProductName
        };
    }

    public static Product MapToProductModel(ProductViewModel productViewModel)
    {
        return new Product()
        {
            Id = productViewModel.Id,
            BrandId = productViewModel.BrandId,
            CategoryId = productViewModel.CategoryId,
            DateOfCreate = productViewModel.DateOfCreate,
            Description = productViewModel.Description,
            Image = productViewModel.Image,
            Model = productViewModel.Model,
            Price = productViewModel.Price,
            DateOfUpdate = productViewModel.DateOfUpdate,
            ProductName = productViewModel.ProductName,
            Brand = productViewModel.Brand,
            Category = productViewModel.Category
        };
    }
    
    public static ProductViewModel MapToProductViewModel(Product product)
    {
        return new ProductViewModel()
        {
            Id = product.Id,
            Brand = product.Brand,
            BrandId = product.BrandId,
            Category = product.Category,
            CategoryId = product.CategoryId,
            DateOfCreate = product.DateOfCreate,
            Description = product.Description,
            Image = product.Image,
            Model = product.Model,
            Price = product.Price,
            DateOfUpdate = product.DateOfUpdate,
            ProductName = product.ProductName
        };
    }
}