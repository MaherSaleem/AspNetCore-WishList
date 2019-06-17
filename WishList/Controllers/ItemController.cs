using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = _context.items.Find(id);
            return View("Edit", item);
        }

        [HttpPost]
        public IActionResult Update(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            var item = _context.items.Find(Id);
            _context.items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
