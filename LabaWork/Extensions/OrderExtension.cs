using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Extensions;

public static class OrderExtension
{
    public static Order MapToOrderModel(OrderViewModel orderViewModel)
    {
        Order order = new Order()
        {
            Id = orderViewModel.Id,
            Adress = orderViewModel.Address,
            Name = orderViewModel.Name,
            PhoneNumber = orderViewModel.PhoneNumber,
            ProductId = orderViewModel.ProductId
        };
        return order;
    }
}