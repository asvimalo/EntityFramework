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
    public partial class CreateMovie : System.Web.UI.Page
    {
        RepoMovie context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoMovie();
        }

        protected void _btnCreateMovie_Click(object sender, EventArgs e)
        {
            int genre;
            Int32.TryParse(_dropDownGender.SelectedValue, out genre);
            DateTime releasedYear;
            DateTime.TryParse(_txtBoxReleaseYear.Text, out releasedYear); 
            context.CreateMovie(new Movie(_txtBoxMovieName.Text,_txtBoxDirector.Text, releasedYear, genre));
            Response.Redirect("~/Pages/Movies.aspx");
        }

        
    }
}