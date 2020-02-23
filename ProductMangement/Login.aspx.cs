using ProductMangementBusiness.interfaces;
using ProductMangementBusiness.repository;
using ProductMangementBusiness.vmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductMangement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            UserVMModel vmModel = new UserVMModel();
            IUserRepository iUserRepository = new UserRepository();
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            vmModel.Name = Username.Text.Trim();
            vmModel.Password = password.Text.Trim();
            bool msg = iUserRepository.LoginUser(vmModel);
            if (msg)
            {

                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}