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
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName([Bind(Prefix = "Brand.Name")]string name, [Bind(Prefix = "Brand.Id")]int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Brand.Any(x => x.Id != id && x.Name == name);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Brand.Any(x => x.Name == name);
    }
}