using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCSA_Movies.Arashi256.Models;

namespace TCSA_Movies.Arashi256.Data
{
    public class TCSA_MoviesArashi256Context : DbContext
    {
        public TCSA_MoviesArashi256Context (DbContextOptions<TCSA_MoviesArashi256Context> options)
            : base(options)
        {
        }

        public DbSet<TCSA_Movies.Arashi256.Models.Movie> Movie { get; set; } = default!;
    }
}
