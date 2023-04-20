using LabaWork.Extensions;
using LabaWork.Models;
using LabaWork.Services.Abstract;
using LabaWork.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet]
    public IActionResult CreateCategory()
    {
        CreateCategoryViewModel createCategoryViewModel = new CreateCategoryViewModel()
        {
            Categories = _categoryService.GetAll()
        };
        return View(createCategoryViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryViewModel createCategoryViewModel)
    {
        if (ModelState.IsValid)
        {
            Category category = CategoryExtension.MapToBrandModel(createCategoryViewModel.Category);
            category.NormalizeName = category.Name.Trim().ToUpper();
            _categoryService.Add(category);
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