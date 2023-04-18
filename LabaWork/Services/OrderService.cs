using LabaWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabaWork.Services;

public class OrderService
{
    private readonly ProductContext _db;

    public OrderService(ProductContext db)
    {
        _db = db;
    }

    public List<Order> GetAll()
    {
        var orders = _db.Orders.Include(x => x.Product).ToList();
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