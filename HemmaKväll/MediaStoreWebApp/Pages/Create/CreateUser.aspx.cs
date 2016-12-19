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
    public partial class CreateUser : System.Web.UI.Page
    {
        RepoCustomer context;

        protected void Page_Load(object sender, EventArgs e)
        {
            context = new RepoCustomer();
        }
        protected void _btnCreateUser_Click(object sender, EventArgs e)
        {  
            context.CreateCustomer(new Customer(_txtBoxUserName.Text, _txtBoxUserAddress.Text, _txtBoxPhone.Text));
            Response.Redirect("~/Pages/Users.aspx");
        }

    }
}