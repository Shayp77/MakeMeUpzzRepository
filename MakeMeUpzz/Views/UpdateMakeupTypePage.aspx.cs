using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateMakeupTypeView.Visible = false;

            if (Session["user_session"] == null && Response.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user = new User();
                if (Session["user_session"] == null)
                {
                    int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserController.findbyid(userID);
                    Session["user_session"] = user;
                }
                else
                {
                    user = (User)Session["user_session"];
                }
                if (user.UserRole.Equals("Admin") && !IsPostBack)
                {
                    UpdateMakeupTypeView.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    MakeupType makeupType = MakeupController.FindMakeupTypeByID(id);

                    if (makeupType != null)
                    {
                        MakeupTypeNameTB.Text = makeupType.MakeupTypeName;
                    }
                    else
                    {
                        Response.Redirect("~/Views/ManageMakeup.aspx");
                    }
                }
            }
        }

        protected void UpdateMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            String MakeupTypeName = MakeupTypeNameTB.Text;

            string errmess = MakeupController.MakeupTypeValidation(MakeupTypeName);


            if (!string.IsNullOrEmpty(errmess))
            {
                ErrorLbl.Text = errmess;
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MakeupController.updateMakeupType(id, MakeupTypeName);

                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
        }

    }
}