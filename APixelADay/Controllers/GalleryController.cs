using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APixelADay.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
