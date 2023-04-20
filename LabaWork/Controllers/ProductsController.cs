using LabaWork.Enums;
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
    public IActionResult AllProducts(ProductSortState sortState = ProductSortState.NameAsc)
    {
        var products = _productService.GetQueryableProduct();
        switch (sortState)
        {
            case ProductSortState.NameAsc:
                products = products.OrderBy(x => x.ProductName);
                break;
            case ProductSortState.NameDesc:
                products = products.OrderByDescending(x => x.ProductName);
                break;
            case ProductSortState.BrandAsc:
                products = products.OrderBy(x => x.Brand);
                break;
            case ProductSortState.BrandDesc:
                products = products.OrderByDescending(x => x.Brand);
                break;
            case ProductSortState.DateOfCreateAsc:
                products = products.OrderBy(x => x.DateOfCreate);
                break;
            case ProductSortState.DateOfCreateDesc:
                products = products.OrderByDescending(x => x.DateOfCreate);
                break;
            case ProductSortState.CategoryAsc:
                products = products.OrderBy(x => x.Category);
                break;
            case ProductSortState.CategoryDesc:
                products = products.OrderByDescending(x => x.Category);
                break;
            case ProductSortState.PriceAsc:
                products = products.OrderBy(x => x.Price);
                break;
            case ProductSortState.PriceDesc:
                products = products.OrderByDescending(x => x.Price);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sortState), sortState, null);
        }

        ProductPageViewModel productPageViewModel = new ProductPageViewModel
        {
            Products = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Brand = p.Brand,
                Category = p.Category,
                DateOfCreate = p.DateOfCreate,
                Image = p.Image,
                Model = p.Model,
                Price = p.Price
            }).ToList(),
            NameSort = sortState is ProductSortState.NameAsc? ProductSortState.NameDesc : ProductSortState.NameAsc,
            BrandSort = sortState is ProductSortState.BrandAsc? ProductSortState.BrandDesc : ProductSortState.BrandAsc,
            DateOfCreateSort = sortState is ProductSortState.DateOfCreateAsc? ProductSortState.DateOfCreateDesc : ProductSortState.DateOfCreateAsc,
            CategorySort = sortState is ProductSortState.CategoryAsc? ProductSortState.CategoryDesc : ProductSortState.CategoryAsc,
            PriceSort = sortState is ProductSortState.PriceAsc? ProductSortState.PriceDesc : ProductSortState.PriceAsc,
        };
        return View(productPageViewModel);
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