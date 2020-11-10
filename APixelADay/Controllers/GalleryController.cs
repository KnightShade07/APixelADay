using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APixelADay.Data;
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
        public async Task<IActionResult> Gallery(int? id)
        {
            int pageNum = id ?? 1;
            const int PageSize = 3;
            ViewData["CurrentPage"] = pageNum;

            int numPixels =  await PixelDBManager.GetTotalPixelsAsync(_context);
            //prevents integer division.

            int totalPages = (int)Math.Ceiling((double)numPixels / PageSize);
            //passes the page data to the view.
            ViewData["MaxPage"] = totalPages;
            //Refactor into PixelDBManager class later,
            //for now, just get it working.

            //gets all the pixel art from the database.
            List<PixelArt> pixelArts = PixelDBManager.GetPageOfPixelsAsync(_context, PageSize, pageNum);
            return View(pixelArts);
        }

        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }

        [HttpPost]

        public async Task <IActionResult> Add(PixelArt p)
        {
            //add to DB
            _context.PixelArts.Add(p);
            //makes sure the changes are saved/executed.
            await _context.SaveChangesAsync();
            //redirect back to Gallery Page
           return RedirectToAction("Gallery");
        }

        public IActionResult Edit(int id)
        {
            //get pixel art with corrosponding id
            PixelArt p = PixelDBManager.GetSinglePixelAsync(id, _context);

            //pass pixel art to view
            return View(p);
        }
        [HttpPost]
        public async Task <IActionResult> Edit(PixelArt p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = "Pixel Art updated successfully!";
            }

            return View(p);
        }
        [HttpGet]
        public  async Task<IActionResult> Delete(int id)
        {
            PixelArt p = await PixelDBManager.GetSinglePixelAsync(id, _context);

            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task <IActionResult> DeleteConfirmed (int id)
        {
            PixelArt p =  await PixelDBManager.GetSinglePixelAsync(id, _context);

            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

             await _context.SaveChangesAsync();

            TempData["Message"] = $"{p.Title} was deleted successfully!";

            return RedirectToAction("Gallery");
        }

        public IActionResult PixelArtOfTheDay()
        {
            return View();
        }
    }
}
