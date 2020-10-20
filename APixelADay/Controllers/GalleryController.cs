using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APixelADay.Models;
using Microsoft.AspNetCore.Mvc;

namespace APixelADay.Controllers
{
    public class GalleryController : Controller
    {
        private readonly PixelDBContext _context;
        public GalleryController(PixelDBContext context)
        {
            _context = context;
        }
        public IActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }

        [HttpPost]

        public IActionResult AddPixel()
        {
            //missing DB Context Object, Suggestion: Come back to this issue later and instead, create a PixelArtDB Class
            //redirect back to Gallery Page
            return RedirectToAction("Gallery");
        }
    }
}
