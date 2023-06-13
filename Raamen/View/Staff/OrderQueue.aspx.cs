using Raamen.Handler;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View.Staff
{
    public partial class OrderQueue : System.Web.UI.Page
    {
        protected void render()
        {

            UnhandleGV.DataSource = TransactionRepository.getUnhandleOrder();
            UnhandleGV.DataBind();

            HandledGV.DataSource = TransactionRepository.getHandleOrder();
            HandledGV.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null || Raamen.Controller.UserController.isMember(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("~/View/Home.aspx");
            }

            render();
        }

        protected void UnhandleGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "HandleOrder")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = UnhandleGV.Rows[rowIndex];
                int idRow = Convert.ToInt32(row.Cells[1].Text);
                int idUser = Int32.Parse(Session["user"].ToString());

                TransactionHandler.handleOrder(idRow, idUser);

                render();
            }
        }

        protected void HandledGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}