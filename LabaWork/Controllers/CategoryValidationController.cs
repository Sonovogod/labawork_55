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
    
    //ToDo проверить какие данные приходят
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName(string name, int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Category.Any(x => x.Id != id && x.Name == name);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Category.Any(x => x.Name == name);
    }
}