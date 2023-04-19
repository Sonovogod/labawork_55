using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Extensions;

public class CategoryExtension
{
    public static Category MapToBrandModel( CategoryViewModel categoryViewModel)
    {
        Category category = new Category()
        {
            Id = categoryViewModel.Id,
            Name = categoryViewModel.Name
        };
        return category;
    }
}