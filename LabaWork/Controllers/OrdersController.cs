using FluentValidation.Results;
using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class OrdersController : Controller
{
    private readonly OrderService _orderService;
    private readonly OrderValidator _orderValidator;
    private readonly OrderAndErrors _orderAndErrors;
    private readonly IProductService _productService;

    public OrdersController(OrderService orderService, OrderValidator orderValidator, OrderAndErrors orderAndErrors, IProductService productService)
    {
        _orderService = orderService;
        _orderValidator = orderValidator;
        _orderAndErrors = orderAndErrors;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAll();
        return View(orders);
    }
    
    [HttpGet]
    public IActionResult Create(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        _orderAndErrors.Order.Product = product;
        
        return View(_orderAndErrors);
    }
    
    [HttpPost]
    public IActionResult Create(Order order)
    {
        ValidationResult validResult = _orderValidator.Validate(order);
        if (validResult.IsValid)
        {
            order.Product = _productService.GetById(order.Product.Id);
            _orderService.Add(order);
            return RedirectToAction("GetAllOrders");
        }
        _orderAndErrors.ErrorViewModel.Errors = validResult.Errors;
        var product = _productService.GetById(order.Product.Id);
        _orderAndErrors.Order.Product = product;
        
        
        return View(_orderAndErrors);
    }
}