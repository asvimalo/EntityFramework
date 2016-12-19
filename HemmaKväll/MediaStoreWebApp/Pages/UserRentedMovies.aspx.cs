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
    public partial class UserRentedMovies : System.Web.UI.Page
    {
        RepoMovie context;
        RepoRentedMovies ctxRented;
        RepoCustomer ctxCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoMovie();
            ctxRented = new RepoRentedMovies();
            ctxCustomer = new RepoCustomer();
            _lblUserName.Text = Session["User"].ToString();
        }
        protected void _btnReturnMovie_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            ctxRented.DeleteRentedMovie(id);
            Response.Redirect("~/Pages/UserRentedMovies.aspx");
        }
        public IQueryable<RentedMovies> GetAllRentedMovies()
        {

            string user = Session["User"].ToString();
            var rentedList = ctxRented.GetMoviesRented(user);
            
            return rentedList;
        }
        protected void _btnReturnToMovies_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedUser.aspx");
        }
    }
}