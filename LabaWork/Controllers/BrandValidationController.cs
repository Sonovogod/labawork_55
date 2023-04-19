using LabaWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class BrandValidationController : Controller
{
    private readonly ProductContext _db;

    public BrandValidationController(ProductContext db)
    {
        _db = db;
    }
    
    //ToDo проверить какие данные приходят
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName(string name, int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Brands.Any(x => x.Id != id && x.Name == name);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Brands.Any(x => x.Name == name);
    }
}