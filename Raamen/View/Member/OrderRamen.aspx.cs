using Raamen.Handler;
using Raamen.Model.Output;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Raamen.View.Member
{
    public partial class Ramen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !Raamen.Controller.UserController.isMember(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else if (!IsPostBack)
            {
                LoadRamenGridView();
                LoadCartGridView();
            }
        }

        protected void LoadRamenGridView()
        {
            RamenGV.DataSource = RamenRepository.getAllRamen();
            RamenGV.DataBind();
        }

        protected void LoadCartGridView()
        {
            List<CartResponse> cart = GetCart();
            CartGV.DataSource = cart;
            CartGV.DataBind();
        }

        protected void RamenGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = RamenGV.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells[1].Text);

                CartResponse selectedRamen = CartRepository.findRamen(id);

                List<CartResponse> cart = GetCart();
                 
                bool isExist = false;
                
                foreach(CartResponse item in cart)
                {
                    if(item.RamenId == selectedRamen.RamenId)
                    {
                        item.Quantity++;
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    cart.Add(selectedRamen);
                }

                SaveCart(cart);
                LoadCartGridView();
            }


        }

        protected List<CartResponse> GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<CartResponse>();
            }
            return (List<CartResponse>)Session["Cart"];
        }

        protected void SaveCart(List<CartResponse> cart)
        {
            Session["Cart"] = cart;
        }

        protected void CartGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveFromCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<CartResponse> cart = GetCart();

                if (rowIndex >= 0 && rowIndex < cart.Count)
                {
                    cart.RemoveAt(rowIndex);
                    SaveCart(cart);
                    LoadCartGridView();
                }
            }
        }

        protected void clearCart()
        {
            List<CartResponse> cart = GetCart();
            cart.Clear();
            SaveCart(cart);
            LoadCartGridView();
        }
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            clearCart();
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            List<CartResponse> cart = GetCart();
            int idUser = Int32.Parse(Session["user"].ToString());

            foreach (GridViewRow row in CartGV.Rows)
            {
                int rowIndex = row.RowIndex;
                CartResponse selectedRamen = cart[rowIndex];

                TransactionHandler.createOrder(selectedRamen, idUser);
            }
            clearCart();
        }
    }
}
