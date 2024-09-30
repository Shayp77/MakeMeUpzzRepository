using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        public List<User> users = null;

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

            Welcomelabel.Text = "Welcome back, " + currentuser.Username + ". Role: " + currentuser.UserRole + ".";
            if (currentuser.UserRole == "Admin")
            {
                if (!IsPostBack)
                {
                    users = UserController.GetUsers();
                    UserData.DataSource = users;
                    UserData.DataBind();
                }
            }
        }
    }
}
