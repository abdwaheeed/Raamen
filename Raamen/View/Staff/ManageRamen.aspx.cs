using Raamen.Controller;
using Raamen.Repository;
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
        public int meatid;
        protected void onLoad()
        {
            raamenView.DataSource = RamenController.getAllRamen1();
            raamenView.DataBind();
        }

        protected void loadMeat()
        {
            MeatGv.DataSource = RamenRepository.getAllListMeat();
            MeatGv.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Raamen.Controller.UserController.isMember(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("~/View/Home.aspx");
            }
                meatTxt.Enabled = false;
                meatTxt.Text = "1";
                onLoad();
                loadMeat();
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
            //int meatid;
            //if (!int.TryParse(meatTxt.Text, out meatid))
            //{
            //    Error.Text = "Meat type must be chosen!";
            //}
            //else
            //{
            //    meatid = int.Parse(meatTxt.Text);
            //}
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

        protected void MeatList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void MeatGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = MeatGv.Rows[rowIndex];
                string id = row.Cells[1].Text;

                meatTxt.Text = id;
                meatid = Convert.ToInt32(id);
            }
        }
    }
}