using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieStore.EF;
using MovieStore.Models;
using System.Windows.Forms;


namespace MediaStoreWebApp
{
    public partial class _Default : Page
    {
        RepoMovie context;
        RepoCustomer ctxCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoMovie();
            ctxCustomer = new RepoCustomer();
            
        }
        public IQueryable<Movie> GetAllMovies()
        {
            return context.GetAllMovies();
        }

        protected void _btnLogUser_Click(object sender, EventArgs e)
        {
            
            var customerToLog = ctxCustomer.GetCustomerByName(_txtBoxUser.Text);
            if (customerToLog != null)
            {
                Session["User"] = customerToLog.CustomerName;
                if (_txtBoxUser.Text == "Admin")
                {
                    Response.Redirect("~/Pages/LoggedAdmin.aspx");
                }
                else
                {
                    Response.Redirect("~/Pages/LoggedUser.aspx");
                }
                
            }
            else
            {
                MessageBox.Show("Please Login");
                
                //Response.Redirect("~/Default.aspx");
            }
                
            

        }
        protected void _btnUpdateMovie_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            Session["MovieToUpdate"] = id;
            Response.Redirect("~/Pages/Update/UpdateMovie.aspx");
        }
        protected void _btnHyreMovie_Click(object sender, EventArgs e)
        {

        }
        protected void _btnDeleteMovie_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)sender;
            string IdMovieToDelete = btn.Attributes["Value"];
            int id;
            Int32.TryParse(IdMovieToDelete, out id);
            context.DeleteMovie(id);
            Response.Redirect("~/Default.aspx");
        }
        
    }
}