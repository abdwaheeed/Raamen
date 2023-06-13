﻿using Raamen.Controller;
using Raamen.Model.Database;
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
                onLoad();

            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

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
    }
}