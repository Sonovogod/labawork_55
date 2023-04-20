using LabaWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabaWork.Controllers;

public class CategoryValidationController : Controller
{
    private readonly ProductContext _db;

    public CategoryValidationController(ProductContext db)
    {
        _db = db;
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName([Bind(Prefix = "Category.Name")]string name, [Bind(Prefix = "Category.Id")]int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Brand.Any(x => x.Id != id && x.Name == name);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Category.Any(x => x.Name.Equals(name));
    }
}