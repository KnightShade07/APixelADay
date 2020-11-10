using APixelADay.Models;
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
    public class PixelDBManager
    {
        //The methods do not have to be async right now, just get them down on paper...err, computer screen!
        /// <summary>
        /// Gets a page of pixel arts from the database.
        /// </summary>
       public static void GetPageOfPixels()
        {

        }
        /// <summary>
        /// Gets a single piece of pixel art from the database.
        /// </summary>
        public static void GetSinglePixel(int id, PixelDBContext _context)
        {
            //get pixel art with corrosponding id
            PixelArt p = (from pixel in _context.PixelArts
                          where pixel.PixelArtID == id
                          select pixel).Single(); //gets a single item from the database
        }


    }
}
