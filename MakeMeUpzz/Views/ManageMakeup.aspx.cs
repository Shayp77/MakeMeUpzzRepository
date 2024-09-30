using MakeMeUpzz.Controller;
using MakeMeUpzz.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class ManageMakeup : System.Web.UI.Page
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

            User user = Session["user_session"] as User;

            if (user.UserRole.Equals("User"))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                GridView1.DataSource = MakeupController.getAllMakeups();
                GridView1.DataBind();

                Type.DataSource = MakeupController.getAllMakeupTypes();
                Type.DataBind();

                Brand.DataSource = MakeupController.getAllMakeupBrands();
                Brand.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);
            String mid = id.ToString();

            Response.Redirect("~/Views/UpdateMakeupPage.aspx?id=" + mid);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.RemoveMakeupByID(id);
            GridView1.DataSource = MakeupController.getAllMakeups();
            GridView1.DataBind();
        }

        protected void InsertMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeup.aspx");
        }

        protected void InsertMakeupType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void InsertMakeupBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Type_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Type.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.RemoveMakeupTypeByID(id);
            Type.DataSource = MakeupController.getAllMakeupTypes();
            Type.DataBind();
        }

        protected void Brand_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Brand.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.RemoveMakeupBrandByID(id);
            Brand.DataSource = MakeupController.getAllMakeupBrands();
            Brand.DataBind();
        }

        protected void UpdateType(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = Type.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?id="+id);
        }

        protected void UpdateBrand(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = Type.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupBrand.aspx?id=" + id);
        }
    }
}
