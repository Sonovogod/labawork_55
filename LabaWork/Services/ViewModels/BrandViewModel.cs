using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Services.ViewModels;

public class BrandViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckUniqueName", "BrandValidation", ErrorMessage = "Такое наименоване бренда уже есть", AdditionalFields = "Name, Id")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    public string Name { get; set; }
}