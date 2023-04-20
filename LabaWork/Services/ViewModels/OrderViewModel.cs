using System.ComponentModel.DataAnnotations;
using LabaWork.Models;

namespace LabaWork.Services.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Phone(ErrorMessage = "Введите номер телефона")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Address { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}