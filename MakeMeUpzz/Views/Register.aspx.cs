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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentuser = null;
            if (Session["user_session"] != null && Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
            if (Session["user_session"] == null && Request.Cookies["user_cookie"] == null)
            {
                return;
            }
            if (Session["user_session"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");

                return;
            }
            if (Session["user_session"] == null)
            {
                string id = Request.Cookies["user_cookie"].Value;

                if (int.TryParse(id, out int nid))
                {
                    currentuser = UserController.findbyid(nid);
                    Session["user_session"] = currentuser;
                    Response.Redirect("~/Views/HomePage.aspx");
                    return;
                }
            }
        }
        protected void SubmitRegister_Click(object sender, EventArgs e)
        {
            RegisController cons = new RegisController();            
            string username = usernameRegister.Text;
            string password = passwordRegister.Text;
            string confpass = confirmPasswordRegister.Text;
            string email = emailRegister.Text;
            DateTime dateOfBirth = dobCalendar.SelectedDate;
            Boolean ismale = male.Checked;
            Boolean isfemale = female.Checked;       
            string role = "User";
            string errmess = cons.ValidateRegistration(username,password,confpass,email,dateOfBirth,ismale,isfemale); 

            if (!string.IsNullOrEmpty(errmess))
            {
                registerError.Text = errmess;
                registerError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string gender = cons.gendercheck(ismale, isfemale);
                cons.doregister(username,email, dateOfBirth,password, role, gender);
                Response.Redirect("~/Views/Login.aspx");
            }
        }


        protected void LoginPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}