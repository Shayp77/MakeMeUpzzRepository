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
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InsertMakeupBrandView.Visible = false;

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
                if (user != null)
                {
                    if (user.UserRole.Equals("Admin"))
                    {
                        InsertMakeupBrandView.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }


        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            int MakeupBrandID =MakeupController.generateMakeupBrandID();
            String MakeupBrandName = MakeupBrandNameTB.Text;
            int MakeupBrandRating = Convert.ToInt32(MakeupBrandRatingTB.Text);

            string errmess = MakeupController.MakeupBrandValidation(MakeupBrandName,MakeupBrandRating);


            if (!string.IsNullOrEmpty(errmess))
            {
                ErrorLbl.Text = errmess;
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MakeupController.insertMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
        }

    }
}