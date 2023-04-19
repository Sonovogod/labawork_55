using LabaWork.Models;

namespace LabaWork.Services.ViewModels;

public class CreateBrandViewModel
{
    public BrandViewModel Brand { get; set; }
    public List<Brand>? Brands { get; set; }
    
}