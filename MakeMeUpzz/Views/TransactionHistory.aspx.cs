using MakeMeUpzz.Controller;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderUser.Visible = false;
            HeaderAdmin.Visible = false;
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

            
            List<TransactionHeader> the = null;
            TransactionHController t = new TransactionHController();
            if (currentuser.UserRole.Equals("User"))
            {

                HeaderUser.Visible = true;
                the = t.getbyuserid(currentuser.UserID);

            }
            else if (currentuser.UserRole.Equals("Admin"))
            {
                HeaderAdmin.Visible = true;
                the = t.getAllTransactionHeaders();

            }

            if (!IsPostBack)
            {
                TransactionHController th = new TransactionHController();
                HeaderUser.DataSource = the;
                HeaderUser.DataBind();
                HeaderAdmin.DataSource = the;
                HeaderAdmin.DataBind();
            }
        }

        protected void TransactionDetailsButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string transactionId = button.CommandArgument;
            Response.Redirect("~/Views/TransactionDetail.aspx?TransactionID=" + transactionId);
        }

    }
}