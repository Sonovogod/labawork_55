using LabaWork.Extensions;
using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public OrdersController(IOrderService orderService, IProductService productService)
    {
        _orderService = orderService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        List<OrderViewModel> orders = _orderService.GetAll();
        return View(orders);
    }
    
    [HttpGet]
    public IActionResult Create(int id)
    {
        ProductViewModel? productViewModel = _productService.GetById(id);
        if (productViewModel == null) return NotFound();
        Product? product = ProductExtension.MapToProductModel(productViewModel);
        CreateOrderViewModel createOrderViewModel = new CreateOrderViewModel()
        {
            ShortProduct = ProductExtension.MapToShortProductViewModel(product)
        };

        return View(createOrderViewModel);
    }
    
    [HttpPost]
    public IActionResult Create(CreateOrderViewModel createOrderViewModel)
    {
        if (ModelState.IsValid)
        {
            Order order = OrderExtension.MapToOrderModel(createOrderViewModel.Order);
            ProductViewModel? productViewModel = _productService.GetById(order.ProductId);
            Product? product = ProductExtension.MapToProductModel(productViewModel);
            order.Product = product;
            _orderService.Add(order);
            return RedirectToAction("GetAllOrders");
        }

        return RedirectToAction("Create", new {id = createOrderViewModel.ShortProduct.Id});
    }
}