using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class PixelDBContext : DbContext
    {
        public PixelDBContext(DbContextOptions<PixelDBContext> options) 
            : base(options)
        {

        }

        public DbSet<PixelArt> PixelArts { get; set; }
    }
}
