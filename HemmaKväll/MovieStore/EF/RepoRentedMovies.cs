using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.EF
{
    public class RepoRentedMovies
    {
        MediaContext context;
        public RepoRentedMovies()
        {
            context = new MediaContext();
        }
        public void DeleteRentedMovie(int id)
        {
            var retedMovie = context.RenteredSetMovies.Find(id);
            context.RenteredSetMovies.Remove(retedMovie);
            context.SaveChanges();
        }
        public RentedMovies GetRentedMovie(int id)
        {
            var retedMovie = context.RenteredSetMovies.Find(id);
            return retedMovie;
        }
        public bool HireMovieNewEntry(int movieID, int customerID)
        {
            bool isRent = false;

            DateTime limitDate = DateTime.Now.AddDays(7);

            context.RenteredSetMovies.Add(new RentedMovies(customerID, movieID, limitDate));
            context.SaveChanges();
            isRent = true;


            return isRent;
        }
        public bool HireMovieUpdateEntry(RentedMovies rentedMovie)
        {
            bool isRent = false;
            
           
            var checkRentedTo = context.RenteredSetMovies.FirstOrDefault(x => x.RentedID == rentedMovie.RentedID);

            checkRentedTo.CustomerID = rentedMovie.CustomerID;
            checkRentedTo.MovieID = rentedMovie.MovieID;
            checkRentedTo.RentedTo = rentedMovie.RentedTo;
            context.SaveChanges();
            isRent = true;

            return isRent;
        }

        public bool ReturnMovie(int movieID, int customerID)
        {
            bool lateReturn = false;


            var movieToReturn = context.RenteredSetMovies.FirstOrDefault(x => x.MovieID == movieID && x.CustomerID == customerID);
            if (DateTime.Now > movieToReturn.RentedTo)
            {
                context.RenteredSetMovies.Remove(movieToReturn);
                context.SaveChanges();
                lateReturn = false;

            }
            else if (movieToReturn.RentedTo > DateTime.Now)
            {
                context.RenteredSetMovies.Remove(movieToReturn);
                context.SaveChanges();
                lateReturn = false;

            }
            return lateReturn;

        }
        public bool CheckStatus(int movieID)
        {
            bool hired = false;

            var movieToCheck = context.RenteredSetMovies.FirstOrDefault(x => x.MovieID == movieID);
            if (movieToCheck.RentedTo == null)
            {
                hired = false;
            }
            else
                hired = true;
            return hired;
        }
        public IOrderedQueryable<RentedMovies> GetAllRentedMovies()
        {
            var rentedMovies = context.RenteredSetMovies.OrderByDescending(x => x.RentedTo);
            return rentedMovies;
        }
        public IOrderedQueryable<Customer> GetAllCustomers()
        {
            var customers = context.Customers.OrderBy(x => x.CustomerID);
            return customers;
        }
        public bool GetAllMovieIfINRentedList(int movieID)
        {
            bool isRent = false;

            var Rentedentries = context.RenteredSetMovies.Where(x => x.MovieID == movieID);
            foreach (var rented in Rentedentries)
            {
                if (rented.RentedTo == null)
                {
                    isRent = false;
                    return isRent;
                }
                else if (rented.RentedTo != null)
                {
                    isRent = true;
                    return isRent;
                }
                else
                {
                    isRent = false;
                    return isRent;
                }
                    
            }
            return isRent;
        }

        public IQueryable<RentedMovies> GetMoviesRented(string name)
        {
            var movie = context.RenteredSetMovies.Where(x => x.Customer.CustomerName == name);
            return movie;
        }
    }
}
