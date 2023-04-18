using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class CategoriesController : Controller
{
    private readonly ISectionService<Category> _categoryService;
    private readonly CategoryValidator _categoryValidator;
    private readonly CategoryAndErrors _categoryAndErrors;

    public CategoriesController(ISectionService<Category> categoryService, CategoryValidator categoryValidator, CategoryAndErrors categoryAndErrors)
    {
        _categoryService = categoryService;
        _categoryValidator = categoryValidator;
        _categoryAndErrors = categoryAndErrors;
    }


    [HttpGet]
    public IActionResult CreateCategory()
    {
        _categoryAndErrors.Categories = _categoryService.GetAll();
        return View(_categoryAndErrors);
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category? category)
    {
        if (category == null) return NotFound();
        
        var validResult = _categoryValidator.Validate(category);
        if (validResult.IsValid)
        {
            category.NormalizeName = category.Name.Trim().ToUpper();
            _categoryService.Add(category);
        }
        else
        {
            _categoryAndErrors.Categories = _categoryService.GetAll();
            _categoryAndErrors.ErrorViewModel.Errors = validResult.Errors;
            return View(_categoryAndErrors);
        }
        
        return RedirectToAction("CreateCategory");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        Category? category = _categoryService.GetById(id);
        if (category is null) return NotFound();
        _categoryService.Delete(category);

        return RedirectToAction("CreateCategory");
    }
}