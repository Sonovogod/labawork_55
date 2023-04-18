using FluentValidation;
using LabaWork.Models;

namespace LabaWork.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Name)
            .MinimumLength(1).WithMessage("Слишком короткое имя")
            .MaximumLength(20).WithMessage("Слишком длинное имя")
            .NotEmpty().WithMessage("Имя не должно быть пустым");
        RuleFor(order => order.PhoneNumber)
            .NotEmpty().WithMessage("Номер должен быть указан");
        RuleFor(order => order.Adress)
            .MinimumLength(1).WithMessage("Слишком короткий адрес")
            .MaximumLength(50).WithMessage("Слишком длинный адрес")
            .NotEmpty().WithMessage("Адрес не должен быть пустым");
    }
}