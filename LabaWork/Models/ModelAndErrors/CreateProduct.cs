namespace LabaWork.Models.ModelAndErrors;

public class CreateProduct
{
    public Product Product { get; set; }
    public List<Category> Categories { get; set; }
    public List<Brand> Brands { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public CreateProduct()
    {
        ErrorViewModel = new ErrorViewModel();
    }
}