using MakeMeUpzz.Controller;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionHandler : System.Web.UI.Page
    {
        


        public List<TransactionHeader> transactionHeaders = null;
        TransactionHController tc = new TransactionHController();
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
                transactionHeaders = tc.getunhandledtransaction("Unhandled");
                thgv.DataSource = transactionHeaders;
                thgv.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void thgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = thgv.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            int TransactionID = Convert.ToInt32(id);
            TransactionHeader th = tc.search(TransactionID);
            String Newstatus = "handled";

            tc.updatestatusbyID(TransactionID, Newstatus);

            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}