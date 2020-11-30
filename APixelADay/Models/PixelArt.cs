using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class PixelArt
    {
        /// <summary>
        /// The ID the database assigns to a piece of pixel art.
        /// </summary>
        [Key]
        public int PixelArtID { get; set; }
        /// <summary>
        /// The datatype used for storing images. Storied in Binary numbers (0,1s)
        /// NOTE: Mr Ortiz uses a PhotoURL Variable instead, consult him on Monday for possible courses of action.
        /// This Image variable was a relic from before I started this quarter.
        /// </summary>
        
        [NotMapped]
        public IFormFile PixelArtPhoto { get; set; }

        //This results in an invalid column name, for now just comment this out and get help from Mr.
        //Ortiz on Monday

        public string PixelArtURL { get; set; }

        /// <summary>
        /// The title given to pixel art
        /// </summary>

        public string Title  { get; set; }

        /// <summary>
        /// The date that this pixel art was created.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Date Created:")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The amount of time that was taken in creating the pixel art, some pieces can
        /// take 30 mins, others several days.
        /// </summary>
        [DisplayName("Time Taken:")]
        public string TimeTaken { get; set; }

        /// <summary>
        /// How big the canvas was for the pixel art.
        /// </summary>

        public string Dimensions { get; set; }
        /// <summary>
        /// This is the variable that will keep track of the day count
        /// for pixel art. It is a string instead of an int because
        /// some pixel art pieces can take multiple days, so you would have to say
        /// "Day 32 - 33", for example. Commented out for now because it produces an error.
        /// </summary>
        //public string DayCount { get; set; }
    }
}
