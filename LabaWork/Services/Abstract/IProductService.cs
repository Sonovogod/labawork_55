using LabaWork.Models;

namespace LabaWork.Services.Abstract;

public interface IProductService
{
    public List<Product> GetAll();
    public Product? GetById(int id);
    public void Add(Product? product);
    public void EditProduct(Product? product);
    public void DeleteProduct(Product product);
}
