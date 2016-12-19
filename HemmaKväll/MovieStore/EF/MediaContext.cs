using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieStore.Models;

namespace MovieStore.EF
{
    public class MediaContext : DbContext
    {
        public MediaContext():base("name=MediaConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentedMovies> RenteredSetMovies { get; set; }
    }
}
