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
        public IActionResult Gallery(int? id)
        {
            int pageNum = id ?? 1;
            const int PageSize = 3;
            //Refactor into PixelDBManager class later,
            //for now, just get it working.

            //gets all the pixel art from the database.
            List<PixelArt> pixelArts = _context.PixelArts.ToList();
            return View(pixelArts);
        }

        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }

        [HttpPost]

        public IActionResult Add(PixelArt p)
        {
            //add to DB
            _context.PixelArts.Add(p);
            //makes sure the changes are saved/executed.
            _context.SaveChanges();
            //redirect back to Gallery Page
            return RedirectToAction("Gallery");
        }
    }
}
