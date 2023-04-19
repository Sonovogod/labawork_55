using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Services.Abstract;

public interface ICategoryService
{
    public List<CategoryViewModel> GetAll();
    public Category? GetById(int id);
    public void Add(Category? section);
    public void Delete(Category? section);
    public bool IsExist(string name);
}