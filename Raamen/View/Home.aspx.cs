using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logout(object sender, EventArgs e)
        {
            HttpCookie user = Request.Cookies["remember_user"];
            user = new HttpCookie("remember_user");
            user.Value = "";
            user.Expires = DateTime.Now.AddYears(-1);
            Response.SetCookie(user);

            Session.Clear();
            Session.Abandon();
            Response.Redirect("/View/Home.aspx");
        }
    }
}