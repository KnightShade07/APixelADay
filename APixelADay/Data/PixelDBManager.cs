using APixelADay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Data
{
    /// <summary>
    /// This class is responsible for managing Database
    /// transactions with the PixelArt Database
    /// In order to keep as much database code out
    /// of the controllers as possible.
    /// </summary>
    public  static class PixelDBManager
    {
        //The methods do not have to be async right now, just get them down on paper...err, computer screen!
        /// <summary>
        /// Gets all pixels from the database.
        /// </summary>
        public async static  Task<int> GetTotalPixelsAsync(PixelDBContext _context)
        {
            return await (from p in _context.PixelArts
                    select p).CountAsync();
        }
        /// <summary>
        /// Gets a page of pixel arts from the database.
        /// </summary>
       public async static Task <List<PixelArt>> GetPageOfPixelsAsync(PixelDBContext _context, int PageSize, int pageNum)
        {
            List<PixelArt> pixelArts =  await (from p in _context.PixelArts
                                        select p).Skip(PageSize * (pageNum - 1)) // Skip() must be before Take()
                                        .Take(PageSize)
                                        .ToListAsync();
            return pixelArts;
        }
        /// <summary>
        /// Gets a single piece of pixel art from the database.
        /// </summary>
        public static async Task<PixelArt>  GetSinglePixelAsync(int id, PixelDBContext _context)
        {
            //get pixel art with corrosponding id
            return  await(from pixel in _context.PixelArts
                          where pixel.PixelArtID == id
                          select pixel).SingleAsync(); //gets a single item from the database
            
        }


    }
}
