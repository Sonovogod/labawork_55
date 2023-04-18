namespace LabaWork.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Adress { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string NormalizeName { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}