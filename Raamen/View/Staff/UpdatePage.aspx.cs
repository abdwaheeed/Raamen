using Raamen.Controller;
using Raamen.Model.Database;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View.Staff
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        public int meatid;
        protected void loadMeat()
        {
            MeatGv.DataSource = RamenRepository.getAllListMeat();
            MeatGv.DataBind();
        }

        protected void onLoad()
        {

            int id = int.Parse(Request.QueryString["id"]);
            Raman ramen = RamenController.findRamenWithId(id);
            meatTxt.Text = ramen.MeatId.ToString();
            ramenTxt.Text = ramen.Name;
            brothTxt.Text = ramen.Broth;
            priceTxt.Text = ramen.Price;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                meatTxt.Enabled = false;
                meatTxt.Text = "1";
                onLoad();
                loadMeat();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

          
            //int meatid = int.Parse(meatTxt.Text);
            string name = ramenTxt.Text;
            string broth = brothTxt.Text;
            string price = priceTxt.Text;

            string error = RamenController.updateRamen(id, meatid, name, broth, price);

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