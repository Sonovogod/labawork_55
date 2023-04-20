using LabaWork.Enums;

namespace LabaWork.Services.ViewModels;

public class ProductPageViewModel
{
    public List<ProductViewModel> Products { get; set; }
    public ProductSortState NameSort { get; set; }
    public ProductSortState BrandSort { get; set; }
    public ProductSortState DateOfCreateSort { get; set; }
    public ProductSortState CategorySort { get; set; }
    public ProductSortState PriceSort { get; set; }
}