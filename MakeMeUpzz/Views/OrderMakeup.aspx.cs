using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class OrderMakeup : System.Web.UI.Page
    {
        public List<Makeup> makeup = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            User currentuser = null;
            if (Session["user_session"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }

            if (Session["user_session"] == null)
            {
                string id = Request.Cookies["user_cookie"].Value;

                if (int.TryParse(id, out int nid))
                {
                    currentuser = UserController.findbyid(nid);
                    Session["user_session"] = currentuser;
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }
            }
            else
            {
                currentuser = Session["user_session"] as User;
            }

            if (!IsPostBack)
            {
                makeup = OrderController.getAllMakeups();
                MakeUpGV.DataSource = makeup;
                MakeUpGV.DataBind();
            }
        }
        protected void cleartransaction_Click(object sender, EventArgs e)
        {
            OrderController.DeleteAllItemsFromCart();

        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {

        }

        protected void MakeUpGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = MakeUpGV.Rows[rowIndex];

                TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                if (quantityTextBox != null)
                {
                    int quantity;
                    if (int.TryParse(quantityTextBox.Text, out quantity) && quantity > 0)
                    {
                        int makeupId = Convert.ToInt32(MakeUpGV.DataKeys[rowIndex].Value);
                        User currentUser = Session["user_session"] as User;
                        if (currentUser != null)
                        {
                            int userId = currentUser.UserID;
                            CartController.InsertToCart(userId, makeupId, quantity);

                            Response.Redirect("~/Views/OrderMakeup.aspx");
                        }
                        else
                        {
                            Debug.WriteLine("User is not logged in.");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Invalid quantity entered.");
                    }
                }
                else
                {
                    Debug.WriteLine("QuantityTextBox not found.");
                }
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            User currentUser = Session["user_session"] as User;
            DateTime dt = DateTime.Now;
            int userid = currentUser.UserID;
            string status = "Unhandled";
            int tid = TransactionHController.generatetransactionid();
            TransactionHController th = new TransactionHController();
            th.InsertTransactionHeader(tid,userid, dt, status);
            List<Cart> cartitems = CartController.getallcart();
            foreach (var item in cartitems)
            {
                TransactionDController td = new TransactionDController();
                td.InsertTransactionDetail( tid,item.MakeupID, item.Quantity);
            }
            OrderController.DeleteAllItemsFromCart();
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}