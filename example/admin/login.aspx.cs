using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            invalidCredentials.Style.Add("display", "none");
            usernameTextBox.Focus();
        }
    }

    /**
     * Login the employee if they enter the correct credentials.
     * 
     */
    protected void loginButtonOnClick(object sender, EventArgs e)
    {
        int id;
        if (!(usernameTextBox.Text.Length < 4) && !(usernameTextBox.Text.Length < 4) && (id = ValidCredentials()) != -1)
        {
            //Response.Write("<script>alert('User ID! = " + id + "');</script>");
            invalidCredentials.Text = "Success!!";
            invalidCredentials.BackColor = Color.Green;
            Session["employee_id"] = "" + id;
            Response.Redirect("~/admin/index.aspx");
        }
        else
        {
            invalidCredentials.Style.Remove("display");
            invalidCredentials.Style.Add("display", "normal");
            invalidCredentials.Text = "Email or Password is incorrect";
            invalidCredentials.BackColor = Color.Red;
        }
    }

    /**
     * Validates the employee's credentials
     * 
     */
    protected int ValidCredentials()
    {
        String exe = "SELECT employee_id, name, role_id FROM EMPLOYEE WHERE email='" + usernameTextBox.Text + "' AND password='"
            + passwordTextBox.Text + "'";

        DataTable dt = Connector.SelectStatements(exe);
        if (dt.Rows.Count == 1)
        {

            DataRow dr = dt.Rows[0];
            /*
            foreach (DataColumn c in dr.Table.Columns)  //loop through the columns. 
            {
                Response.Write("<script>alert('" + c.ColumnName + "!');</script>");
            } */
            int customer_id = (int)dr["employee_id"];
            Session["name"] = dr["name"];
            Session["role_id"] = dr["role_id"];
            //Response.Write("<script>alert('" + customer_id + "!');</script>");
            return customer_id;
        }
        return -1;
    }

}