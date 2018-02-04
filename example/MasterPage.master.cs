using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    /**
     * If the user is logged in, change the header to display user information
     * Otherwise display a guest layout.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Connector.ConnectionStatus())
            {
                //Response.Write("<script>alert('Connected!');</script>");
                //Response.Redirect("~/Register.aspx");
            }
        }
        if (Session["user_id"] == null || Session["user_id"].ToString().Equals(""))
        {
            //Response.Redirect("~/Register.aspx");
            loginLabelLink.Text = "Login";
            //loginLabelLink.HRef = "#";
            loginLabelLink.Attributes.Add("data-toggle", "modal");
            loginLabelLink.Attributes.Add("data-target", "#login-modal");
            registerLabel.Text = "Register";
            registerLabel.Attributes.Add("href", "register.aspx");
            registerLabel.Attributes.Remove("onclick");
        } else
        {
            loginLabelLink.Text = "Account Information";
            loginLabelLink.Attributes.Clear();
            loginLabelLink.Attributes.Add("href", "account-info.aspx");

            registerLabel.Text = "Logoff";
            registerLabel.Attributes.Remove("href");
            registerLabel.Attributes.Add("OnClick", "LogoutOnClick");
        }

    }

    protected void UserInfo_DataBinding(object sender, EventArgs e)
    {

    }

    /**
     * On Success: Login the user
     * On Failure: Display an Error message
     * 
     */
    protected void LoginButtonClicked(object sender, EventArgs e)
    {
        int id;
        if(!(emailTextField.Text.Length < 4) && !(passwordTextField.Text.Length < 4) && (id = ValidCredentials()) != -1)
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
            return;
        }
    }

    /**
     * Validates the users credentials to login.
     * 
     */
    protected int ValidCredentials()
    {
        String exe = "SELECT customer_id FROM CUSTOMER WHERE email='" + emailTextField.Text + "' AND password='"
            + passwordTextField.Text + "'";

        DataTable dt = Connector.SelectStatements(exe);
        if(dt.Rows.Count == 1)
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

    /**
     * Clear all cookies,cashe, and session variables when the user logs out.
     * 
     */
    protected void LogoutOnClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Remove("user_id");
        Session.Clear();
        Session.RemoveAll();
        Response.Cookies.Clear();
        Response.Cache.SetNoStore();
        Response.CacheControl = "no-cache";
        Response.Redirect("~/index.aspx");
    }

    /**
     * Redirects to the account information page.
     * 
     */
    protected void AccountInfoOnClick()
    {
        Response.Redirect("~/account-info.aspx");
        //Response.Write("<script>alert('CONNECTED!');</script>");
    }

}
