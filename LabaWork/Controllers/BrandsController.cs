using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class BrandsController : Controller
{
    private readonly ISectionService<Brand> _brandService;
    private readonly BrandAndErrors _brandAndErrors;
    private readonly BrandValidator _brandValidator;

    public BrandsController(ISectionService<Brand> brandService, BrandAndErrors brandAndErrors, BrandValidator brandValidator)
    {
        _brandService = brandService;
        _brandAndErrors = brandAndErrors;
        _brandValidator = brandValidator;
    }

    [HttpGet]
    public IActionResult CreateBrand()
    {
        _brandAndErrors.Brands = _brandService.GetAll();
        return View(_brandAndErrors);
    }
    
    [HttpPost]
    public IActionResult CreateBrand(Brand? brand)
    {
        if (brand == null) return NotFound();
        
        var validResult = _brandValidator.Validate(brand);
        if (validResult.IsValid)
        {
            brand.NormalizeName = brand.Name.Trim().ToUpper();
            _brandService.Add(brand);
        }
        else
        {
            _brandAndErrors.Brands = _brandService.GetAll();
            _brandAndErrors.ErrorViewModel.Errors = validResult.Errors;
            return View(_brandAndErrors);
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