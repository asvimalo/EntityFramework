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
    
    public partial class LoggedUser : System.Web.UI.Page
    {
        RepoMovie context;
        RepoRentedMovies ctxRented;
        RepoCustomer ctxCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoMovie();
            ctxRented = new RepoRentedMovies();
            ctxCustomer = new RepoCustomer();
        }
        public IQueryable<Movie> GetAllMovies()
        {
            return context.GetAllMovies();
        }
        protected void _btnHyreMovie_Click(object sender, EventArgs e)
        {
            //Get UserName And Id Movie to Hyre
            string userName = Session["User"].ToString();

            var custThatWillHire = ctxCustomer.GetCustomerByName(userName);


            Button btn = (Button)sender;
            string IdMovieToHyre = btn.Attributes["Value"];
            int idmovie;
            Int32.TryParse(IdMovieToHyre, out idmovie);
            ///////////////
            //Check if movie available:
            bool isRented = ctxRented.GetAllMovieIfINRentedList(idmovie);


            if (isRented == false)
            {
                var rentedMovie = ctxRented.HireMovieNewEntry(idmovie, custThatWillHire.CustomerID);
                Response.Redirect("~/Pages/UserRentedMovies");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Movie not available, please choose another one");

            }

        }
        protected void _btnCheckRentedMovies_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/UserRentedMovies");
        }
        protected void _btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}