using System.ComponentModel.DataAnnotations;
using LabaWork.Models;

namespace LabaWork.Services.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 50")]
    public string Model { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Минимальное количество знаков: 10, Максимальное - 500")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Range(50, 5000, ErrorMessage = "Стоимость не должна быть ниже 50 у.е и не дороже 5000 у.е.")]
    public double Price { get; set; }
    public string? Image { get; set; }
    public DateTime DateOfCreate { get; set; }
    public DateTime DateOfUpdate { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}