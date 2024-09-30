
using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
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
    public partial class UpdateMakeupBrand : System.Web.UI.Page
    {
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
            if (currentuser.UserRole.Equals("Admin") && !IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                MakeupBrand mb = MakeupController.FindMakeupBrandByID(id);

                if (mb != null)
                {
                    updatembnametb.Text = mb.MakeupBrandName;
                    updatembratetb.Text = mb.MakeupBrandRating.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }
            }
        }



        protected void updatebtn_Click1(object sender, EventArgs e)
        {

            int updateID = Convert.ToInt32(Request.QueryString["id"]);
            String makeupname = updatembnametb.Text;
            int makeuprating = Convert.ToInt32(updatembratetb.Text);

            string errmess = MakeupController.MakeupBrandValidation(makeupname, makeuprating);


            if (!string.IsNullOrEmpty(errmess))
            {
                errorMsgLabel.Text = errmess;
                errorMsgLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MakeupController.updateMakeupBrand(updateID, makeupname, makeuprating);
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
        }

        protected void backto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");

        }
    }
}
