using Lab_1.DAL.Context;
using Lab_1.DAL.Entities;
using Lab_1.Extensions;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace Lab_1.Controllers;

public class ProductController : Controller
{
    ApplicationDbContext _context;

    int _pageSize;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
        _pageSize = 3;
    }

    [Route("Catalog")]
    [Route("Catalog/Page_{pageNo}")]
    public IActionResult Index(int? group, int pageNo = 1)
    {
        var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);

        // Поместить список групп во ViewData
        ViewData["Groups"] = _context.DishGroups;
        // Получить id текущей группы и поместить в TempData
        ViewData["CurrentGroup"] = group ?? 0;

        var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
        if (Request.Headers.XRequestedWith.Equals("XMLHttpRequest"))
            return PartialView("_listpartial", model);
        else
            return View(model);
    }
}