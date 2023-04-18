namespace LabaWork.Models.ModelAndErrors;

public class OrderAndErrors
{
    public ErrorViewModel ErrorViewModel { get; set; }
    public Order Order { get; set; }

    public OrderAndErrors()
    {
        ErrorViewModel = new ErrorViewModel();
        Order = new Order();
    }
}