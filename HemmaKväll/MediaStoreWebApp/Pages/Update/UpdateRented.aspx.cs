using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieStore.EF;
using MovieStore.Models;

namespace MediaStoreWebApp
{
    public partial class UpdateRented : System.Web.UI.Page
    {
        RepoRentedMovies context;
        RepoCustomer cxtCustomer;
        RepoMovie ctxMovie;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoRentedMovies();
            cxtCustomer = new RepoCustomer();
            ctxMovie = new RepoMovie();
            if (!IsPostBack)
            {

                GetRented();

            }
        }
        protected void _btnUpdateRentedMovie_Click(object sender, EventArgs e)
        {
            //Get Rented Entry to compare
            int rentedID;
            string rentedIDString = Session["RentedToUpdate"].ToString();
            Int32.TryParse(rentedIDString, out rentedID);
            var rentedMovie = context.GetRentedMovie(rentedID);

            //Get Customer From DropDown
            int customerID;
            Int32.TryParse(_dropDownCustomers.SelectedValue, out customerID);

            //Get MovieID
            int movieID;
            Int32.TryParse(_dropDownMovies.SelectedValue, out movieID);

            
            if (movieID != rentedMovie.MovieID)
            {
                //Check if movie available for rent
                bool isRent = context.GetAllMovieIfINRentedList(movieID);

                //Ckect date limit
                DateTime limit = DateTime.Now.AddDays(7);
                DateTime inputDate;
                DateTime.TryParse(_txtBoxRentedTo.Text, out inputDate);
                if (inputDate > limit)
                {
                    System.Windows.Forms.MessageBox.Show("Max rent days: 7");
                }
                else if (inputDate < DateTime.Now)
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a present or future date (max 7 days)");
                }
                else
                {
                    if (isRent == false)
                    {
                        isRent = context.HireMovieUpdateEntry(new RentedMovies(rentedID, customerID, movieID, inputDate));
                        Response.Redirect("~/Pages/Rented");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Movie not available, please choose another one");

                    }
                }
            }
            else
            {
                DateTime limit = DateTime.Now.AddDays(7);
                DateTime inputDate;
                DateTime.TryParse(_txtBoxRentedTo.Text, out inputDate);
                if (inputDate > limit)
                {
                    System.Windows.Forms.MessageBox.Show("Max rent days: 7");
                }
                else if (inputDate < DateTime.Now)
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a present or future date (max 7 days)");
                }
                else
                {

                    bool isRent = context.HireMovieUpdateEntry(new RentedMovies(rentedID, customerID, movieID, inputDate));
                    Response.Redirect("~/Pages/Rented");

                }
            }

        }
        public void GetRented()
        {

            string RentedToUpdate = Session["RentedToUpdate"].ToString();
            int rentedID;
            Int32.TryParse(RentedToUpdate, out rentedID);
            var rentedMovie = context.GetRentedMovie(rentedID);
            _dropDownCustomers.SelectedValue = rentedMovie.CustomerID.ToString();
            _dropDownMovies.SelectedValue = rentedMovie.MovieID.ToString();
            _txtBoxRentedTo.Text = rentedMovie.RentedTo.ToString();
        }
        public IQueryable<Customer> GetCustomers()
        {
            var customers = cxtCustomer.GetAllCustomers();
            return customers;
        }
        public IQueryable<Movie> GetAllMovies()
        {
            var movies = ctxMovie.GetAllMovies();
            return movies;
        }
    }
}