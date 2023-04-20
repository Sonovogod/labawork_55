using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Services.Abstract;

public interface IProductService
{
    public List<ProductViewModel>  GetAll();
    public ProductViewModel? GetById(int id);
    public void Add(Product? product);
    public void EditProduct(Product? product);
    public void DeleteProduct(Product product);
}
