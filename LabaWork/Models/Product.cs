namespace LabaWork.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public DateTime DateOfCreate { get; set; }
    public DateTime DateOfUpdate { get; set; }
    public string NormalizeName { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}