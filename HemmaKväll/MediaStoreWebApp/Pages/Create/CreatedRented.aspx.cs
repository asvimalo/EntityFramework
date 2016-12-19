using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieStore.EF;
using MovieStore.Models;
using System.Windows.Forms.ComponentModel;

namespace MediaStoreWebApp
{
    public partial class CreatedRented : System.Web.UI.Page
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
                _txtBoxRentedTo.Text = DateTime.Now.AddDays(7).ToString();

            }
        }
        protected void _btnCreateRentedMovie_Click(object sender, EventArgs e)
        {
            //Get Date From TextBox
            //DateTime date = new DateTime();
            //DateTime.TryParse(_txtBoxRentedTo.Text, out date);

            //Get Customer From DropDown
            int customerID;
            Int32.TryParse(_dropDownCustomers.SelectedValue, out customerID);
            //Get MovieID
            int movieID;
            Int32.TryParse(_dropDownMovies.SelectedValue, out movieID);

            bool isRent = context.GetAllMovieIfINRentedList(movieID);

            if (isRent == false)
            {
                var rentedMovie = context.HireMovieNewEntry(movieID, customerID);
                Response.Redirect("~/Pages/Rented");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Movie not available, please choose another one");
               
            }





                //var rentedMovie = context.HireMovie(movieID, customerID);
                //Response.Redirect("~/Pages/Rented.aspx");


                //int genre;
                //Int32.TryParse(_dropDownGender.SelectedValue, out genre);
                //DateTime releasedYear;
                //DateTime.TryParse(_txtBoxReleaseYear.Text, out releasedYear);
                //context.CreateMovie(new Movie(_txtBoxMovieName.Text, _txtBoxDirector.Text, releasedYear, genre));
                //Response.Redirect("~/Pages/Movies.aspx");
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