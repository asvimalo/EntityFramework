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
    public partial class Rented : System.Web.UI.Page
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
        public IOrderedQueryable<RentedMovies> GetAllRentedMovies()
        {
            
            return ctxRented.GetAllRentedMovies();
        }
        protected void _btnAddRent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Create/CreatedRented.aspx");
        }
        protected void _btnUpdateRentMovie_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string IdMovieToUpdate = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToUpdate, out id);
            Session["RentedToUpdate"] = id;
            Response.Redirect("~/Pages/Update/UpdateRented.aspx");
        }
        //protected void _btnRentMovie_Click(object sender, EventArgs e)
        //{
        //    //Get UserName And Id Movie to Hyre
        //    string userName = Session["User"].ToString();
        //    var custThatWillHire = ctxCustomer.GetCustomerByName(userName);

        //    //Retrie
        //    Button btn = (Button)sender;
        //    string IdRenteredEntry = btn.Attributes["Value"];
        //    int idmovie;
        //    Int32.TryParse(IdMovieToHyre, out idmovie);


        //    bool isRent = ctxRented.GetAllMovieIfINRentedList(idmovie);
        //    //TODO
        //    if (isRent == false)
        //    {
        //        bool rented = ctxRented.HireMovieNewEntry(custThatWillHire.CustomerID, idmovie);
        //        Response.Redirect("~/Pages/Rented");
        //    }
        //    else
        //    {
        //        System.Windows.Forms.MessageBox.Show("Movie not available, please choose another one");

        //    }


        //}
        protected void _btnDeleteRentMovie_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            ctxRented.DeleteRentedMovie(id);
            Response.Redirect("~/Pages/Rented.aspx");
        }
    }
}
