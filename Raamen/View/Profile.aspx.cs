using Raamen.Controller;
using Raamen.Model.Database;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void onLoad()
        {
            int id = int.Parse(Request.QueryString["id"]);
            profileGV.DataSource = UserRepository.getUserByID(id);
            profileGV.DataBind();

            User user = UserRepository.getUserByID(id);
            usernameTxt.Text = user.UserName;
            emailTxt.Text = user.Email;
            GenderButtons.Text = user.Gender;
            passwordTxt.Text = user.Password;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        protected void GenderButtons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string gender = GenderButtons.Text;
            string password = passwordTxt.Text;

            string error = UserController.updateProfile(id, username, email, gender, password);

            if (error == "Update profile success")
            {
                Error.Text = error;
            }
            else
            {
                Error.Text = error;
            }
        }
    }
}