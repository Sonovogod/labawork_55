using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabaWork.Services;

public class OrderService : IOrderService
{
    private readonly ProductContext _db;

    public OrderService(ProductContext db)
    {
        _db = db;
    }

    public List<OrderViewModel> GetAll()
    {
        List<OrderViewModel> orders = _db.Orders.Include(x => x.Product)
            .Select(order => new OrderViewModel
            {
                Id = order.Id,
                Address = order.Adress,
                Name = order.Name,
                PhoneNumber = order.PhoneNumber,
                Product = order.Product,
                ProductId = order.ProductId
            }).ToList();
        return orders;
    }

    public void Add(Order? order)
    {
        if (order == null) return;
        order.NormalizeName = order.Name.Trim().ToUpper();
        order.DateOfCreate = DateTime.Now;
        _db.Orders.Add(order);
        _db.SaveChanges();
    }
}