using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Services.Abstract;

public interface IOrderService
{
    public List<OrderViewModel> GetAll();
    public void Add(Order? order);
}