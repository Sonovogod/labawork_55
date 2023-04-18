using FluentValidation;
using LabaWork.Models;

namespace LabaWork.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    private readonly ProductContext _db;
    public CategoryValidator(ProductContext db)
    {
        _db = db;
        RuleFor(section => section.Name)
            .NotNull().WithMessage("Поле не должно быть пустым")
            .MinimumLength(1).WithMessage("Поле не должно быть меньше 1 символа")
            .MaximumLength(20).WithMessage("Поле не должно быть больше 20 символов")
        .Must(name =>
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (_db.Categories.Any(x=> x.NormalizeName.Equals(name.Trim().ToUpper())))
                    return false;
            }
            return true;
        }).WithMessage("Такое название уже есть");
    }
    
}