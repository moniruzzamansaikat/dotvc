using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;
using YourProjectName.Models;
namespace YourProjectName.Controllers;
public class ItemsController : Controller
{

  private readonly ApplicationDbContext _context;

  public ItemsController(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index()
  {
    var items = await _context.Items.Include(i => i.SerialNumber).Include(i => i.Category).ToListAsync();
    return View(items);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create([Bind("Name,Price,Description,SerialNumber")] Item item)
  {
    if (ModelState.IsValid)
    {
      if (item.SerialNumber == null)
      {
        item.SerialNumber = new SerialNumber();
      }
      _context.Items.Add(item);
      await _context.SaveChangesAsync();
      TempData["SuccessMessage"] = "Item created successfully";
      return RedirectToAction(nameof(Index));
    }

    return View(item);
  }


  public async Task<IActionResult> Edit(int id)
  {
    var item = await _context.Items.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
    var categories = await _context.Categories.ToListAsync();
    ViewBag.Categories = categories;
    return View(item);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("Id, Name,Price,Description,SerialNumber,CategoryId")] Item item)
  {
    if (ModelState.IsValid)
    {
      _context.Update(item);
      await _context.SaveChangesAsync();
      TempData["SuccessMessage"] = "Item updated successfully";
      return RedirectToAction(nameof(Index));
    }

    return View(item);
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id)
  {
    Console.WriteLine("Deleting item with ID: " + id);
    var item = await _context.Items.Include(i => i.SerialNumber).FirstOrDefaultAsync(i => i.Id == id);

    if (item == null)
    {
      return RedirectToAction(nameof(Index));
    }

    if (item.SerialNumber != null)
    {
      _context.SerialNumbers.Remove(item.SerialNumber);
    }

    _context.Items.Remove(item);
    await _context.SaveChangesAsync();
    TempData["SuccessMessage"] = "Item successfully removed";

    return RedirectToAction(nameof(Index));
  }
}
