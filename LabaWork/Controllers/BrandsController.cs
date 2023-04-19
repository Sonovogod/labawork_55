using LabaWork.Extensions;
using LabaWork.Models;
using LabaWork.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public IActionResult CreateBrand()
    {
        CreateBrandViewModel CreateBrandViewModel = new CreateBrandViewModel()
        {
            Brands = _brandService.GetAll()
        };
        return View(CreateBrandViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateBrand(CreateBrandViewModel? createBrandViewModel)
    {
        if (ModelState.IsValid)
        {
            Brand brand = BrandExtension.MapToBrandModel(createBrandViewModel.Brand);
            brand.NormalizeName = brand.Name.Trim().ToUpper();
            _brandService.Add(brand);
        }
        
        return RedirectToAction("CreateBrand");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        Brand? brand = _brandService.GetById(id);
        if (brand is null) return NotFound();
        _brandService.Delete(brand);

        return RedirectToAction("CreateBrand");
    }
    
}