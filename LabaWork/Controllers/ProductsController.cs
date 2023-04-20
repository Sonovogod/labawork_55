using LabaWork.Extensions;
using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IBrandService _brandService;
    private readonly ICategoryService _categoryService;
    private readonly IFileService _fileService;

    public ProductsController(
        IProductService productService,
        IBrandService brandService, 
        ICategoryService categoryService, IFileService fileService)
    {
        _productService = productService;
        _brandService = brandService;
        _categoryService = categoryService;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult AllProducts()
    {
        List<ProductViewModel> products = _productService.GetAll();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        CreateProductViewModel createProductViewModel = new CreateProductViewModel()
        {
            Categories = _categoryService.GetAll(),
            Brands = _brandService.GetAll()
        };
  
        return View(createProductViewModel);
    }
    
    [HttpPost]
    public IActionResult Create(CreateProductViewModel? createProductViewModel, IFormFile uploadedFile)
    {
        if (ModelState.IsValid)
        {
            Product product = ProductExtension.MapToProductModel(createProductViewModel.Product);
            _fileService.Upload($"{product.Brand}_{product.ProductName}.txt");
            product.Image = _fileService.SaveFileAndGetPath(product, uploadedFile);
            _productService.Add(product);
            return RedirectToAction("AllProducts");
        }
  
        return RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult About(int id)
    {
        ProductViewModel? productViewModel = _productService.GetById(id);
        if (productViewModel is null) return NotFound();
        
        return View(productViewModel);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        ProductViewModel? productViewModel = _productService.GetById(id);
        if (productViewModel is null) return NotFound();
        Product? product = ProductExtension.MapToProductModel(productViewModel);
        _productService.DeleteProduct(product);
        
        return RedirectToAction("AllProducts");
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ProductViewModel? productViewModel = _productService.GetById(id);
        if (productViewModel is null) return NotFound();

        CreateProductViewModel createProductViewModel = new CreateProductViewModel()
        {
            Product = productViewModel,
            Brands = _brandService.GetAll(),
            Categories = _categoryService.GetAll()
        };
        
        return View(createProductViewModel);
    }
    
    [HttpPost]
    public IActionResult Edit(CreateProductViewModel? createProductViewModel)
    {
        if (ModelState.IsValid)
        {
            Product product = ProductExtension.MapToProductModel(createProductViewModel.Product);
            _productService.EditProduct(product);
            return RedirectToAction("About", new { id = product.Id });
        }

        return RedirectToAction("Edit", new {id = createProductViewModel.Product.Id});
    }
}