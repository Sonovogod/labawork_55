using FluentValidation;
using LabaWork.Models;

namespace LabaWork.Validators;

public class BrandValidator : AbstractValidator<Brand>
{
    private readonly ProductContext _db;
    public BrandValidator(ProductContext db)
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
                    if (_db.Brands.Any(x=> x.NormalizeName.Equals(name.Trim().ToUpper())))
                        return false;
                }
                return true;
            }).WithMessage("Такое название уже есть");
    }
    
}