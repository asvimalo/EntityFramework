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
    public partial class UpdateUser : System.Web.UI.Page
    {
        RepoCustomer context;
        protected void Page_Load(object sender, EventArgs e)
        {

            context = new RepoCustomer();
            if (!IsPostBack)
            {
                GetUserToUpdate();
            }

        }
        protected void _btnUpdateUser_Click(object sender, EventArgs e)
        {
            int UserIdToUpdate;
            string idToUpdate = Session["UserToUpdate"].ToString();
            Int32.TryParse(idToUpdate, out UserIdToUpdate);

            
            
            context.UpdateCustomer(new Customer(UserIdToUpdate, _txtBoxUserName.Text, _txtBoxUserAddress.Text, _txtBoxPhone.Text));
            Response.Redirect("~/Pages/Users.aspx");
        }
        protected void GetUserToUpdate()
        {
            var UserToUpdate = new Customer();
            int id;
            string idToUpdate = Session["UserToUpdate"].ToString();
            Int32.TryParse(idToUpdate, out id);
          
            UserToUpdate = context.GetCustomer(id);

            _txtBoxUserName.Text = UserToUpdate.CustomerName;
            _txtBoxUserAddress.Text = UserToUpdate.CustomerAdress;
            _txtBoxPhone.Text = UserToUpdate.CustomerPhone;
            



        }
    }
}