using Raamen.Controller;
using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View.Guest
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie rememberUserCookie = Request.Cookies["remember_user"];
            if (Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            else if (rememberUserCookie != null
                && !String.IsNullOrEmpty(rememberUserCookie.Value))
            {
                String[] rememberUser = rememberUserCookie.Value.ToString().Split('\\');
                User login = UserController.DoLogin(rememberUser);
                Session["user"] = login.Id;
                Response.Redirect("Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
            string error = "";
            User login = null;

            try
            {
                login = UserController.login(username, password);
            }
            catch(MemberAccessException ex)
            {
                error = ex.Message;
            }

            if (login != null)
            {
                Session["user"] = login.Id;
                if (RememberMe.Checked)
                {
                    String remember_user = username + "\\" + password;
                    HttpCookie cookie = new HttpCookie("remember_user", remember_user);
                    cookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("Home.aspx");
            }

            else
            {
                Error.Text = error;
            }
        }
    }
}