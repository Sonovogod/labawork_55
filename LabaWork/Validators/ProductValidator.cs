using FluentValidation;
using LabaWork.Models;

namespace LabaWork.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.ProductName)
            .MinimumLength(1).WithMessage("Слишком короткое название продукта")
            .MaximumLength(20).WithMessage("Слишком длинное название продукта")
            .NotEmpty().WithMessage("Название продукта не должно быть пустым");
        RuleFor(product => product.BrandId)
            .GreaterThan(0).WithMessage("Бренд должен быть указан");
        RuleFor(product => product.Model)
            .MinimumLength(1).WithMessage("Слишком короткое название продукта")
            .MaximumLength(20).WithMessage("Слишком длинное название продукта")
            .NotEmpty().WithMessage("Название продукта не должно быть пустым");
        RuleFor(product => product.CategoryId)            
            .GreaterThan(0).WithMessage("Категория должна быть указана");
        RuleFor(product => product.Description)
            .MaximumLength(100).WithMessage("Описание не более 100 символов")
            .MinimumLength(10).WithMessage("Описание не менее 10 символов")
            .NotEmpty().WithMessage("Описание не должно быть пустым");
        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Стоимость должна быть больше 0");
        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Добавьте ссылку на картинку");
    }
}