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
            //redirect back to Gallery Page
            return RedirectToAction("Gallery");
        }
    }
}
