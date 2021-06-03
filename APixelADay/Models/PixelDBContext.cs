using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class PixelDBContext : IdentityDbContext
    {
        public PixelDBContext(DbContextOptions<PixelDBContext> options) 
            : base(options)
        {

        }
        //used for database communication
        public DbSet<PixelArt> PixelArts { get; set; }
    }
}
