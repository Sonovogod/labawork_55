namespace LabaWork.Models.ModelAndErrors;

public class CategoryAndErrors
{
    public ErrorViewModel ErrorViewModel { get; set; }
    public Category Category { get; set; }
    public List<Category> Categories { get; set; }

    public CategoryAndErrors()
    {
        ErrorViewModel = new ErrorViewModel();
    }
}