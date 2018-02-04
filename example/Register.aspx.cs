using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user_id"] != null)
        {
            Response.Redirect("~/index.aspx");
        }
    }

    /**
     * Validates the fields and tries to register the user.
     * Success: creates the account
     * Failure: displays an error message on why the account was not created.
     * 
     */
    protected void RegisterOnClick(object sender, EventArgs e)
    {
        if(registerEmailTextField.Text.Length > 5 && registerEmailTextField.Text.Length < 45 &&
            registerPasswordTextfield.Text.Length > 5 && registerPasswordTextfield.Text.Length < 45 
            && registerNameTextField.Text.Length > 1 && EmailNotUsed())
        {
            //Response.Write("<script>alert('Connected!');</script>");
            DateTime dateTimeVariable = DateTime.Now;
            String exe = "INSERT INTO customer (name, email, password, registration_date) VALUES ('" + registerNameTextField.Text + "','"
                + registerEmailTextField.Text + "','" +
               registerPasswordTextfield.Text + "','" + dateTimeVariable.ToString() + "')";
            if (!Connector.EditStatements(exe))
            {
                Response.Write("Please Contact Support.");
            }
            errorLabel.Text = "You are now Registered. Please log in.";
            errorLabel.ForeColor = Color.Green;
        } else if (!EmailNotUsed())
        {
            errorLabel.Text = "Email Address is already used";
            errorLabel.ForeColor = Color.Red;
        } else
        {
            errorLabel.Text = "Make sure the fields have valid data.";
            errorLabel.ForeColor = Color.Red;
        }
    }

    /**
     * Checks to see if the email is in use.
     * 
     */
    protected bool EmailNotUsed()
    {
        String exe = "SELECT customer_id FROM CUSTOMER WHERE email='" + registerEmailTextField.Text + "'";
        DataTable dt;
        if ((dt = Connector.SelectStatements(exe)) == null || dt.Rows.Count < 1)
        {
            return true;
        }

        //int customer_id = (from DataRow dr in dt.Rows
        //                  where (string)dr["email"] == registerEmailTextField.Text
        //                  select (int)dr["customer_id"]).FirstOrDefault();
        return false;
    }

    /**
     * Tries to login the user.
     * On Failure: displays an error message.
     * 
     */
    protected void LoginButtonClicked(object sender, EventArgs e)
    {
        int id;
        if (!(loginEmailTextBox.Text.Length < 4) && !(loginEmailTextBox.Text.Length < 4) && (id = ValidCredentials()) != -1)
        {
            invalidCredentialsLabel.Text = "Success!!";
            invalidCredentialsLabel.ForeColor = Color.Green;
            Session["user_id"] = "" + id;
            Response.Redirect("~/Register.aspx");
            //Response.Write("<script>alert('User ID! = "+id+"');</script>");
            //Response.Write("<script>alert('User ID2! = " + Session["user_id"].ToString() + "');</script>");
        }
        else
        {
            invalidCredentialsLabel.Text = "Email or Password is incorrect";
            invalidCredentialsLabel.ForeColor = Color.Red;
        }
    }

    /**
     * Validates the credentials the user tries to login with.
     * 
     */
    protected int ValidCredentials()
    {
        String exe = "SELECT customer_id FROM CUSTOMER WHERE email='" + loginEmailTextBox.Text + "' AND password='"
            + loginPasswordTextBox.Text + "'";

        DataTable dt = Connector.SelectStatements(exe);
        if (dt.Rows.Count == 1)
        {

            DataRow dr = dt.Rows[0];
            /*
            foreach (DataColumn c in dr.Table.Columns)  //loop through the columns. 
            {
                Response.Write("<script>alert('" + c.ColumnName + "!');</script>");
            } */
            int customer_id = (int)dr["customer_id"];
            //Response.Write("<script>alert('" + customer_id + "!');</script>");
            return customer_id;
        }
        return -1;
    }

}