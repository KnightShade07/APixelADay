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
        /// </summary>
        
        [NotMapped]
        public IFormFile PixelArtPhoto { get; set; }

        /// <summary>
        /// The name of the pixel art, not actually the full URL.
        /// </summary>
        public string PixelArtURL { get; set; }

        /// <summary>
        /// The title given to pixel art
        /// </summary>
        [DisplayName("Title: ")]
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
        [DisplayName("Dimensions: ")]
        public string Dimensions { get; set; }
        /// <summary>
        /// This is the variable that will keep track of the day count
        /// for pixel art. It is a string instead of an int because
        /// some pixel art pieces can take multiple days, so you would have to say
        /// "Day 32 - 33", for example. 
        /// </summary>
        
        [DisplayName("Day Count: ")]
        public string DayCount { get; set; }
        /// <summary>
        /// Description of what the pixel art is and where it's from.
        /// </summary>
        [DisplayName("Description: ")]
        public string Description { get; set; }
    }
}
