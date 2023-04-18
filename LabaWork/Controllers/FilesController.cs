using LabaWork.DataObjects;
using LabaWork.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class FilesController : Controller
{
    private readonly IFileService _fileService;
    private readonly IProductService _productService;

    public FilesController(IFileService fileService, IProductService productService)
    {
        _fileService = fileService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetFile(int id)
    {
        var product = _productService.GetById(id);
        if (product is null) return NotFound();
        var filename = $"{product.Brand}_{product.ProductName}.txt";
        FileDataObject fileData = _fileService.Download(filename);
        
        return File(fileData.FileStream, fileData.FileType, filename);
    }
}