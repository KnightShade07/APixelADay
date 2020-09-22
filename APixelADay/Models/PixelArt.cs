using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// The title given to pixel art
        /// </summary>

        public string Title  { get; set; }

        /// <summary>
        /// The date that this pixel art was created.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The amount of time that was taken in creating the pixel art, some pieces can
        /// take 30 mins, others several days.
        /// </summary>

        public string TimeTaken { get; set; }

        /// <summary>
        /// How big the canvas was for the pixel art.
        /// </summary>

        public string Dimensions { get; set; }
    }
}
