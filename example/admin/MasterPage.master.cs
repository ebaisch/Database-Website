using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    /**
     * Checks to make sure an employee is logged in, otherwise redirects them to the login page.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["employee_id"] == null)
        {
            Response.Redirect("~/admin/login.aspx");
        } else
        {
            loginLabel.Text = "Welcome " + Session["name"].ToString();
        }
    }

    /**
     * Clears the cookies, cache and sessions when the employee logs out.
     * 
     */
    protected void LogoutOnClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Remove("employee_id");
        Session.Clear();
        Session.RemoveAll();
        Response.Cookies.Clear();
        Response.Cache.SetNoStore();
        Response.CacheControl = "no-cache";
        Response.Redirect("~/admin/login.aspx");
    }

}
