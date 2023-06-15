using Raamen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View.Guest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void GenderButtons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderButtons.Text;
            string password = PasswordTxt.Text;
            string confirmPassword = ConfirmPasswordTxt.Text;

            string error = UserController.register(username, email, gender, password, confirmPassword);

            if(error == "")
            {
                Response.Redirect("./Login.aspx");
            }
            else
            {
                Error.Text = error;
            }
        }
    }
}