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
    public partial class Movies : System.Web.UI.Page
    {
        RepoMovie context;
        RepoRentedMovies ctxRented;
        RepoCustomer ctxCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoMovie();
            ctxRented = new RepoRentedMovies();
            ctxCustomer = new RepoCustomer();
            _CreateLabel_Load();

        }
        public IQueryable<Movie> GetAllMovies()
        {
           
                

                return context.GetAllMovies();
        }
        protected void _btnCreateMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Create/CreateMovie.aspx");
        }
        protected void _btnUpdateMovie_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            Session["MovieToUpdate"] = id;
            Response.Redirect("~/Pages/Update/UpdateMovie.aspx");
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
                Response.Redirect("~/Pages/Rented");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Movie not available, please choose another one");

            }

        }
        protected void _btnDeleteMovie_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            context.DeleteMovie(id);
            Response.Redirect("~/Pages/Movies.aspx");
        }
        protected string OnLayoutCreated_Load(object sender, EventArgs e)
        {
            //test
            string keys = "";
            foreach (var item in MovieListView.Attributes.Keys)
            {
                keys += item.ToString();
                 
            }
            return keys;




            //var lbl = (MovieListView.FindControl("_lblHired"));
            //lbl.Controls.
            //lbl.Text = "Hola";
            //string available = "Available";
            //string notAvailable = "Not Available";
            //var labeltoControl = (MovieListView.FindControl("_lblHired") as Label);
            //string movieIDText = labeltoControl.Text;
            //int movieID;
            //Int32.TryParse(movieIDText, out movieID);

            //bool status = context.CheckState(movieID);
            //if (status == false)
            //{
            //    labeltoControl.Text = notAvailable;
            //}
            //else
            //{
            //    labeltoControl.Text = available;
            //}
        }
        protected void _CreateLabel_Load()
        {

            foreach (var movie in context.GetAllMovies())
            {
                PlaceHolder PlaceHolderLabel = new PlaceHolder();
                Label availability = new Label();
                availability.ID = "_lblHired";
                availability.Visible = true;
                

                string available = "Available";
                string notAvailable = "Not Available";

                bool checkState = context.CheckState(movie.MovieId);
                if (checkState == false)
                {

                    availability.Text = available;
                    availability.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    availability.Text = notAvailable;
                    availability.ForeColor = System.Drawing.Color.Red;

                }
                PlaceHolderLabel.Controls.Add(availability);

                // Set the label's Text and ID properties.

            }
        }
    }
}
