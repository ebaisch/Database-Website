using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_modifyemployee : System.Web.UI.Page
{
    /**
     * Checks to make sure an employee is logged in, otherwise redirects them to the login page.
     * Only the owner can modify other employee's
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["employee_id"] == null)
        {

            Response.Redirect("~/admin/index.aspx");
        }
        else
        {
            
                String exe1 = "SELECT * FROM employee WHERE employee_id=" + Int32.Parse(Session["employee_id"].ToString());
                DataTable d = Connector.SelectStatements(exe1);
                DataRow dr = d.Rows[0];
                if ((int)dr["role_id"] != 4)
                {
                    Response.Redirect("~/admin/index.aspx");
                }

            if (!String.IsNullOrEmpty(Request.QueryString["employee_id"]) && !this.IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["employee_id"]);
                String exe = "SELECT * FROM employee where employee_id=" + id;
                DataTable dt = Connector.SelectStatements(exe);
                dr = dt.Rows[0];
                employeeEmailTextBox.Text = dr["email"].ToString();
                employeeNameTextBox.Text = dr["name"].ToString();
                employeePasswordLabel.Text = "Set Password";
            }
            
        }
    }

    /**
     * Modify the selected employee fields
     * 
     */
    protected void modifyEmployeeOnClick(object sender, EventArgs e)
    {
        if (employeeEmailTextBox.Text.Length < 2 || employeeEmailTextBox.Text.Length < 2)
        {
            errorLabel.Text = "Please enter valid data.";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        if (employeeEmailTextBox.Text.Length < 5 || !employeeEmailTextBox.Text.Contains(".") || !employeeEmailTextBox.Text.Contains("@"))
        {
            errorLabel.Text = "Please enter a valid email address.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

        int id = Int32.Parse(Request.QueryString["employee_id"]);

        String exe1 = "SELECT * FROM employee WHERE employee_id=" + id;
        DataTable d = Connector.SelectStatements(exe1);
        DataRow dr = d.Rows[0];
        String exe;

        Response.Write("<script>alert('" + employeeNameTextBox.Text + "');</script>");
        if (employeePasswordTextBox.Text.Length > 2)
        {
            exe = "UPDATE employee set email=\"" + employeeEmailTextBox.Text + "\", name=\"" + employeeNameTextBox.Text + "\", password=\"" + employeePasswordTextBox.Text
                + "\" WHERE employee_id=" + id;
        } else
        {
            exe = "UPDATE employee set email=\"" + employeeEmailTextBox.Text + "\", name=\"" + employeeNameTextBox.Text
                + "\" WHERE employee_id=" + id;
        }

        if (!Connector.EditStatements(exe))
        {
            errorLabel.Text = "Error Updating database.";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        else
        {
            Response.Redirect("~/admin/index.aspx");
        }

    }

    protected void DropDownListChanged(object sender, EventArgs e)
    {

    }
}