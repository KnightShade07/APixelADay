﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APixelADay.Data;
using APixelADay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APixelADay.Controllers
{
    public class GalleryController : Controller
    {
        private readonly PixelDBContext _context;
        private readonly IConfiguration _config;
        public GalleryController(PixelDBContext context, IConfiguration config)
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
            List<PixelArt> pixelArts =  await PixelDBManager.GetPageOfPixelsAsync(_context, PageSize, pageNum);
            return View(pixelArts);
        }

        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }

        [HttpPost]
        [RequestSizeLimit(31457280)] //30 MB for now, change it later based on the size of the pixel art's data consumption.
        public async Task <IActionResult> Add(PixelArt p)
        {

            //TODO: Validate Product Photo.
            IFormFile Pixel = p.PixelArtPhoto;

            if(Pixel.Length > 0)
            {
                //Add Error.
                //return view.
            }

            string extension = Path.GetExtension(Pixel.FileName).ToLower();
            string[] permittedExtensions = { ".png", ".gif" };

            if (!permittedExtensions.Contains(extension))
            {
                //Add error message
                //return view.
            }

            //Generate Unique file name.
            //Save to storage.



            //add to DB
            _context.PixelArts.Add(p);
            //makes sure the changes are saved/executed.
            await _context.SaveChangesAsync();
            //redirect back to Gallery Page
           return RedirectToAction("Gallery");
        }

        public  async Task <IActionResult> Edit(int id)
        {
            //get pixel art with corrosponding id
            PixelArt p =  await PixelDBManager.GetSinglePixelAsync(id, _context);

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
