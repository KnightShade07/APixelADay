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
            ViewData["CurrentPage"] = pageNum;

            int numPixels = (from p in _context.PixelArts
                             select p).Count();
            //prevents integer division.

            int totalPages = (int)Math.Ceiling((double)numPixels / PageSize);
            //passes the page data to the view.
            ViewData["MaxPage"] = totalPages;
            //Refactor into PixelDBManager class later,
            //for now, just get it working.

            //gets all the pixel art from the database.
            List<PixelArt> pixelArts = (from p in _context.PixelArts
                                        select p).Skip(PageSize * (pageNum - 1)) // Skip() must be before Take()
                                        .Take(PageSize)
                                        .ToList();
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

        public IActionResult Edit(int id)
        {
            //get pixel art with corrosponding id
            PixelArt p = (from pixel in _context.PixelArts
                          where pixel.PixelArtID == id
                          select pixel).Single(); //gets a single item from the database

            //pass pixel art to view
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(PixelArt p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return View(p);
        }
    }
}
