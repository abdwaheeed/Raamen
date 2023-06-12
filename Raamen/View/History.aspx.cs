using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class History : System.Web.UI.Page
    {
        protected void onLoadMember()
        {
            if (!IsPostBack)
            {
                int idUser = Int32.Parse(Session["user"].ToString());
                HistoryGV.DataSource = HistoryRepository.getHistory(idUser);
                HistoryGV.DataBind();

            }
        }

        protected void onloadAdmin()
        {
            if (!IsPostBack)
            {
                HistoryGV.DataSource = HistoryRepository.getAllHistory();
                HistoryGV.DataBind();

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["user"] == null || Raamen.Controller.UserController.isStaff(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else if (UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                onloadAdmin();
            }
            else
            {
                onLoadMember();
            }
        }

        protected void HistoryGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Detail")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = HistoryGV.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells[1].Text);

                Response.Redirect("~/View/HistoryDetail.aspx?id=" + id);
            }
        }
    }
}