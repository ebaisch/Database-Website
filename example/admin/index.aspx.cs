using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_index : System.Web.UI.Page
{
    /**
     * Checks to make sure an employee is logged in.
     * If they are not the owner, then they can't view the employees.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee_id"] == null)
        {
            Response.Redirect("~/admin/login.aspx");
        }

        String exe1 = "SELECT * FROM employee WHERE employee_id=" + Int32.Parse(Session["employee_id"].ToString());
        DataTable d = Connector.SelectStatements(exe1);
        DataRow dr = d.Rows[0];
        if ((int)dr["role_id"] != 4)
        {
            viewEmployeeButton.Text = "";
            viewEmployeeButton.Enabled = false;
        }

    }

    /**
     * Redirects to the add product page
     * 
     */
    protected void AddProductOnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/addproduct.aspx");
    }

    /**
     * Redirects to the add employee page
     * 
     */
    protected void AddEmployeeOnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/addemployee.aspx");
    }

    /**
     * Redirects to the view employees page
     * 
     */
    protected void ViewEmployeeOnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/viewemployees.aspx");
    }

    /**
     * Redirects to the view messages page
     * 
     */
    protected void ViewMessagesOnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/viewmessages.aspx");
    }
}