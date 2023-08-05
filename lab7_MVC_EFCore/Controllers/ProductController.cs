using lab7_MVC_EFCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace lab7_MVC_EFCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly MVC_NIIE_LabContext _context;
        public ProductController(MVC_NIIE_LabContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Products.Include(a=>a.Category).Include(a=>a.Supplier).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Suppliers = new SelectList( _context.Suppliers.ToList(),"Id","Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(),"Id","Name") ;

            return View();
        }

    }
}
