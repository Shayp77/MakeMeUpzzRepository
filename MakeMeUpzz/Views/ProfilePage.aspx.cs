using MakeMeUpzz.Controller;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositori;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class ProfilePage : System.Web.UI.Page
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
                string aid = Request.Cookies["user_cookie"].Value;

                if (int.TryParse(aid, out int nid))
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


            UpdateProfileController cons = new UpdateProfileController();
            User currentUser = Session["user_session"] as User;
            int id = currentUser.UserID;
            if (!IsPostBack)
            {
                User user = cons.getbyid(id);
                if (user != null)
                {
                    usernameRegister.Text = user.Username;
                    emailRegister.Text = user.UserEmail;
                    if (user.UserGender == "Male")
                    {
                        male.Checked = true;
                    }
                    else if (user.UserGender == "Female")
                    {
                        female.Checked = true;
                    }
                    dobCalendar.SelectedDate = user.UserDOB;
                    dobCalendar.VisibleDate = user.UserDOB;

                }
            }

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string username = usernameRegister.Text;
            string email = emailRegister.Text;
            DateTime dateOfBirth = dobCalendar.SelectedDate;
            UpdateProfileController cons = new UpdateProfileController();
            Boolean ismale = male.Checked;
            Boolean isfemale = female.Checked;
            string errmess =cons.validateprofile(username,email,dateOfBirth,ismale,isfemale);

            string gender = cons.gendercheck(ismale,isfemale);
            

            if (!string.IsNullOrEmpty(errmess))
            {
                updateerror.Text = errmess;
                updateerror.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                User currentUser = Session["user_session"] as User;

                cons.updatebyid(currentUser,username, email, gender, dateOfBirth);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void updatepassword_Click(object sender, EventArgs e)
        {
            User currentUser = Session["user_session"] as User;
            int id = currentUser.UserID;
            UpdateProfileController cons = new UpdateProfileController();
            string password = passwordRegister.Text;
            string newpass = newpasswordrupdate.Text;
            string errmess = cons.validatepassword(currentUser,password,newpass) ;

            if (!string.IsNullOrEmpty(errmess))
            {
                passerr.Text = errmess;
                passerr.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                cons.updatepass(id, newpass);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

    }
}