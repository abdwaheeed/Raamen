using Raamen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View.Staff
{
	public partial class ManageRamen : System.Web.UI.Page
	{
        protected void onLoad()
        {
            raamenView.DataSource = RamenController.getAllRamen1();
            raamenView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            onLoad();

        }

        protected void raamenView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = raamenView.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[1].Text);
            RamenController.deleteRamen(id);
            onLoad();
        }

        protected void raamenView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = raamenView.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[1].Text);
            onLoad();
            Response.Redirect("~/View/Staff/UpdatePage.aspx?id=" + id);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            int meatid;
            if (!int.TryParse(meatTxt.Text, out meatid))
            {
                Error.Text = "Meat type must be chosen!";
            }
            else
            {
                meatid = int.Parse(meatTxt.Text);
            }
            //int meatid = int.Parse(meatTxt.Text);
            string name = ramenTxt.Text;
            string broth = brothTxt.Text;
            string price = priceTxt.Text;

            string error = RamenController.insertRamen(meatid, name, broth, price);

            if (error == "Ramen has been added")
            {
                Error.Text = error;
            }
            else
            {
                Error.Text = error;
            }
            onLoad();
        }


    }
}