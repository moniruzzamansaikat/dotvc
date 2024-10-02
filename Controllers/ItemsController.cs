using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YourProjectName.Models;
namespace YourProjectName.Controllers;
public class ItemsController : Controller
{
  public IActionResult Overview()
  {
    var item = new Item()
    {
      Id = 1,
      Name = "My Laptop 404",
      Price = 1000
    };

    return View(item);
  }

  public IActionResult Edit(int id)
  {
    var item = new Item()
    {
      Id = id,
      Name = "My Laptop 404",
      Price = 1000
    };

    return View(item);
  }

}