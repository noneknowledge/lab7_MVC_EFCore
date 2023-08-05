using lab7_MVC_EFCore.Data;
using lab7_MVC_EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab7_MVC_EFCore.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly MVC_NIIE_LabContext _context;
        public SuppliersController(MVC_NIIE_LabContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Suppliers != null ? _context.Suppliers.ToList() : new List<Supplier>();

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier model,IFormFile FileLogo)
        {
            if (FileLogo != null)

            {

                //upload và cập nhật field Logo

                model.Logo = MyTool.UploadImageToFolder(FileLogo, "Suppliers");

            }

            _context.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
       
        }



    }
}
