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
    public partial class UpdateMovie : System.Web.UI.Page
    {
        RepoMovie context;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            context = new RepoMovie();
            if (!IsPostBack)
            {
                GetMovieToUpdate();
            }
            
        }
        protected void _btnUpdateMovie_Click(object sender, EventArgs e)
        {
            int movieIdToUpdate;
            string idToUpdate = Session["MovieToUpdate"].ToString();
            Int32.TryParse(idToUpdate, out movieIdToUpdate);

            int genreID;
            Int32.TryParse(_dropDownGender.SelectedValue, out genreID);

            DateTime releasedYear;
            DateTime.TryParse(_txtBoxReleaseYear.Text, out releasedYear);
            context.UpdateMovie(new Movie(movieIdToUpdate, _txtBoxMovieName.Text, _txtBoxDirector.Text, releasedYear, genreID));
            Response.Redirect("~/Pages/Movies.aspx");
        }
        protected void GetMovieToUpdate()
        {
            var movieToUpdate = new Movie();
            int id;
            string idToUpdate = Session["MovieToUpdate"].ToString();
            Int32.TryParse(idToUpdate, out id);
            //int genreID;            
            //Int32.TryParse(_dropDownGender.SelectedValue, out genreID);
            movieToUpdate = context.GetMovie(id);

            _dropDownGender.SelectedValue = movieToUpdate.GenreID.ToString();
            _txtBoxReleaseYear.Text = movieToUpdate.ReleaseDate.ToString();
            _txtBoxMovieName.Text = movieToUpdate.MovieName;
            _txtBoxDirector.Text = movieToUpdate.DirectorName;



        }
    }
}