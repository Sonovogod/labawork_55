using LabaWork.Models;
using LabaWork.Services.ViewModels;

public interface IBrandService
{
    public List<BrandViewModel> GetAll();
    public Brand? GetById(int id);
    public void Add(Brand? section);
    public void Delete(Brand? section);
    public bool IsExist(string name);
}