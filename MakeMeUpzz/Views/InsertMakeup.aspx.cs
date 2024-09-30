using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Web.UI;

namespace MakeMeUpzz.Views
{
    public partial class InsertMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_session"] == null)
            {
                if (Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }

                string userCookieValue = Request.Cookies["user_cookie"].Value;
                if (int.TryParse(userCookieValue, out int userID))
                {
                    Session["user_session"] = UserController.findbyid(userID);
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                    return;
                }
            }

            User user = (User)Session["user_session"];

            if (user.UserRole.Equals("User"))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            string makeupName = MakeupNameTB.Text;
            int makeupPrice = Convert.ToInt32(MakeupPriceTB.Text);
            int makeupWeight = Convert.ToInt32(MakeupWeightTB.Text);
            int makeupTypeID = Convert.ToInt32(MakeupTypeIDTB.Text);
            int makeupBrandID = Convert.ToInt32(MakeupBrandIDTB.Text);
            string errmess = MakeupController.MakeupValidation(makeupName,makeupPrice,makeupWeight,makeupTypeID,makeupBrandID);
           
            
            if (errmess != "")
            {
                ErrLbl.Text = errmess;
                ErrLbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MakeupController.insertMakeup(makeupName, makeupPrice, makeupWeight, makeupTypeID, makeupBrandID);
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }
    }
}
