using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieStore.EF;
using MovieStore.Models;
using System.ComponentModel;

namespace MediaStoreWebApp
{
    public partial class Users : System.Web.UI.Page
    {
        RepoCustomer context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoCustomer();
        }
        public IQueryable<Customer> GetAllCustomers()
        {
            return context.GetAllCustomers();
        }
        public ICollection<RentedMovies> GetAllRentedMovies()
        {
            BindingList<RentedMovies> rented = new BindingList<RentedMovies>();
            var rentedMovies = context.GetAllCustomers();
            
            foreach (Customer customer in rentedMovies)
            {
                rented = customer.RenteredMoviesCustomer as BindingList<RentedMovies>;
                //return rented;
                //foreach (RentedMovies rented in customer.RenteredMoviesCustomer)
                //{

                //}
            }
            return rented as ICollection<RentedMovies>;

        }



        protected void _btnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Create/CreateUser.aspx");
        }

        protected void _btnDeleteUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Attributes["Value"];

            int idToDelete;
            Int32.TryParse(id, out idToDelete);
            context.DeleteCustomer(idToDelete);
            Response.Redirect("~/Pages/Users.aspx");
        }
        protected void _btnUpdateUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Attributes["Value"];

            int idToUpdate;
            Int32.TryParse(id, out idToUpdate);
            Session["UserToUpdate"] = id;


            Response.Redirect("~/Pages/Update/UpdateUser.aspx");
        }
    }
}