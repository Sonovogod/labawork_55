using LabaWork.Models;
using LabaWork.Services.ViewModels;

namespace LabaWork.Extensions;

public static class BrandExtension
{
    public static Brand MapToBrandModel( BrandViewModel brandViewModel)
    {
        Brand brand = new Brand()
        {
            Id = brandViewModel.Id,
            Name = brandViewModel.Name
        };
        return brand;
    }
    
}