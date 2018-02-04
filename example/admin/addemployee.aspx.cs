using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addemployee : System.Web.UI.Page
{
    /**
     * Validation is done through the master page
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**
     * Allows an employee to add an employee below their rank to the database.
     * 
     */
    protected void AddEmployeeOnClick(object sender, EventArgs e)
    {
        if(employeeEmailTextBox.Text.Length < 2 || employeeEmailTextBox.Text.Length < 2 || employeePasswordTextBox.Text.Length < 2)
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
        int employee_role = (int)Session["role_id"];

        int newEmployeeID = -1;
        if(DropDownList.Text.Equals("Employee"))
        {
            newEmployeeID = 1;
        } else if (DropDownList.Text.Equals("Manager"))
        {
            newEmployeeID = 2;
        } else if (DropDownList.Text.Equals("Database Admin"))
        {
            newEmployeeID = 3;
        } else if (DropDownList.Text.Equals("Owner"))
        {
            newEmployeeID = 4;
        } else
        {
            errorLabel.Text = "Dropdown list error.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

        if(employee_role > newEmployeeID)
        {
            String exe = "INSERT INTO employee (name, email, password, role_id) VALUES('" + employeeNameTextBox.Text + "', '" + 
                employeeEmailTextBox.Text + "', '" + employeePasswordTextBox.Text + "', '" + newEmployeeID + "')";

            if (!Connector.EditStatements(exe))
            {
                errorLabel.Text = "Error inserting into database.";
                errorLabel.ForeColor = Color.Red;
                return;
            } else
            {
                Response.Redirect("~/admin/index.aspx");
            }

        } else
        {
            errorLabel.Text = "You do not have permission to add an employee.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

    }

    protected void DropDownListChanged(object sender, EventArgs e)
    {

    }
}