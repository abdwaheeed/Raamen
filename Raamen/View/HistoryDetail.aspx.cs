using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class HistoryDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] == null)
            {
                Response.Redirect("~/View/History.aspx");
            }

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                DetailGV.DataSource = TransactionRepository.getHandleOrderById(id);
                DetailGV.DataBind();
            
            }


        }
    }
}