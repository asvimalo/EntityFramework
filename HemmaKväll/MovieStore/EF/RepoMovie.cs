using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Models;
using System.Data.Entity;

namespace MovieStore.EF
{
    public class RepoMovie
    {
        MediaContext context;
        public RepoMovie()
        {
            context = new MediaContext();
        }
        public IQueryable<Movie> GetAllMovies()
        {
            var query = context.Movies.OrderBy(x => x.MovieId).AsQueryable();
            return query;
        }
        public Movie GetMovie(int id)
        {
            var movie = context.Movies.FirstOrDefault(x => x.MovieId == id);
            return movie;
        }
        public void CreateMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public void UpdateMovie(Movie movie)
        {
            var movieToUpdate = context.Movies.FirstOrDefault(x => x.MovieId == movie.MovieId);
            movieToUpdate.MovieName = movie.MovieName;
            movieToUpdate.DirectorName = movie.DirectorName;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.GenreID = movie.GenreID;

            //context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            var movieToDelete = context.Movies.Find(id);
            context.Movies.Remove(movieToDelete);
            context.SaveChanges();

        }
        public bool CheckState(int movieId)
        {
            bool isAvailable = false;
            if (String.IsNullOrEmpty(context.RenteredSetMovies.Any(x => x.MovieID==movieId).ToString()))
            {
                isAvailable = true;
                
            }
            else if(!String.IsNullOrEmpty(context.RenteredSetMovies.Any(x => x.MovieID == movieId).ToString()))
            {
                isAvailable = false;
                
            }
            return isAvailable;

            /*var moviesList = context.RenteredSetMovies.Where(x => x.MovieID == movieId).ToString();*/ /*context.RenteredSetMovies.Select(x => x.RentedTo).ToString();*/
        }
        //public IQueryable<Movie> GetAllMoviesAvailable()
        //{
        //    List<Movie> moviesAvailable = new List<Movie>();
        //    context.Configuration.LazyLoadingEnabled = false;
        //    var movies = context.Movies.Include("RenteredMovies");
        //    foreach (var movie in movies)
        //    {
        //        moviesAvailable = movie.RenteredMovies.Where(x => x.RentedTo == null).Select(x => x.Movie).ToList();
               
        //    }
            
        //    //var RentedMovies = movies.Include(x => x.RenteredMovies.Where(y => y.RentedTo==null)).ToList();
            
        //    return moviesAvailable as IQueryable<Movie>;
        //}
    }
}
