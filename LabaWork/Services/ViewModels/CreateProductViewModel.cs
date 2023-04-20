namespace LabaWork.Services.ViewModels;

public class CreateProductViewModel
{
    public ProductViewModel Product { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }
    public List<BrandViewModel>? Brands { get; set; }
}