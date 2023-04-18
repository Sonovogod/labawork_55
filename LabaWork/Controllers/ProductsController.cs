using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ProductValidator _productValidator;
    private readonly CreateProduct _createProduct;
    private readonly ISectionService<Brand> _brandService;
    private readonly ISectionService<Category> _categoryService;
    private readonly IFileService _fileService;

    public ProductsController(
        IProductService productService, 
        ProductValidator productValidator, 
        CreateProduct createProduct,
        ISectionService<Brand> brandService, 
        ISectionService<Category> categoryService, IFileService fileService)
    {
        _productService = productService;
        _productValidator = productValidator;
        _createProduct = createProduct;
        _brandService = brandService;
        _categoryService = categoryService;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult AllProducts()
    {
        List<Product> products = _productService.GetAll();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        GetBrandsAndCategories();
        return View(_createProduct);
    }
    
    [HttpPost]
    public IActionResult Create(Product? product, IFormFile uploadedFile)
    {
        if (product == null) return NotFound();

        var validResult = _productValidator.Validate(product);
        if (validResult.IsValid)
        {
            _fileService.Upload($"{product.Brand}_{product.ProductName}.txt");
            product.Image = _fileService.SaveFileAndGetPath(product, uploadedFile);
            _productService.Add(product);
        }
        else
        {
            GetBrandsAndCategories();
            _createProduct.ErrorViewModel.Errors = validResult.Errors;
            return View(_createProduct); 
        }
        return RedirectToAction("AllProducts");
    }

    [NonAction]
    private void GetBrandsAndCategories()
    {
        _createProduct.Categories = _categoryService.GetAll();
        _createProduct.Brands = _brandService.GetAll();
    }

    [HttpGet]
    public IActionResult About(int id)
    {
        var product = _productService.GetById(id);
        if (product is null) return NotFound();

        return View(product);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        Product? product = _productService.GetById(id);
        if (product is null) return NotFound();
        _productService.DeleteProduct(product);
        
        return RedirectToAction("AllProducts");
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Product? product = _productService.GetById(id);
        if (product is null) return NotFound();

        GetBrandsAndCategories();
        _createProduct.Product = product;
        return View(_createProduct);
    }
    
    [HttpPost]
    public IActionResult Edit(Product? product)
    {
        if (product == null) return NotFound();
        var validResult = _productValidator.Validate(product);
        if (validResult.IsValid)
        {
            _productService.EditProduct(product);
        }
        else
        {
            Product? newProduct = _productService.GetById(product.Id);
            if (newProduct is null) return NotFound();
            
            GetBrandsAndCategories();
            _createProduct.Product = newProduct;
            _createProduct.ErrorViewModel.Errors = validResult.Errors;
            return View(_createProduct);
        }

        return RedirectToAction("AllProducts");
    }
}