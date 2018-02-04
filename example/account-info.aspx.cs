using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class account_info : System.Web.UI.Page
{
    /**
     * Populated the Orders Table with the customers orders
     * 
     * If the user is not logged in, Redirect the user to the home page.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        errorLabel.Text = "";
        if (Session["user_id"] == null)
        {
            Response.Redirect("~/index.aspx");
        } else
        {
            String exe = "SELECT * FROM order_invoice WHERE customer_ID=" + Session["user_id"];
            DataTable dt = Connector.SelectStatements(exe);
            searchResults.DataSource = dt;
            searchResults.DataBind();
        }
    }

    /**
     * Allows the user to update their existing password
     * 
     * @return Returns nothing if there was a validation error or connection to the database error
     *
     */
    protected void PasswordButtonOnClick(object sender, EventArgs e)
    {
        if (oldPasswordTextBox.Text.Length < 1)
        {
            errorLabel.Text = "Please enter your old password";
            errorLabel.ForeColor = Color.Red;
            return;
        } else if (newPasswordTextBox1.Text.Length < 5 || newPasswordTextBox2.Text.Length < 5)
        {
            errorLabel.Text = "Please enter a pasword with a minimum length of 5";
            errorLabel.ForeColor = Color.Red;
            return;
        } else if (!newPasswordTextBox1.Text.Equals(newPasswordTextBox2.Text))
        {
            errorLabel.Text = "The passwords you entered don't match.";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        String exe = "SELECT * FROM customer WHERE customer_id=" + Session["user_id"] + " and password=\"" + oldPasswordTextBox.Text + "\"";
        DataTable dt = Connector.SelectStatements(exe);

        if (dt.Rows.Count == 0)
        {
            errorLabel.Text = "Your old password is incorrect.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

        exe = "UPDATE customer set password=\"" + newPasswordTextBox1.Text + "\" WHERE customer_id=" + Session["user_id"];
        if(!Connector.EditStatements(exe))
        {
            errorLabel.Text = "Database Error. Contact Support.";
            errorLabel.ForeColor = Color.Red;
            return;
        } else
        {
            errorLabel.Text = "Password Change Successful.";
            errorLabel.ForeColor = Color.Green;
        }

    }
    
    /**
     * Redirects to an order page based on the order the user selects.
     * 
     */
    protected void searchResults_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        //Response.Write("<script>alert('2222222 2!');</script>");
        Response.Redirect("~/vieworder.aspx?order=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);
    }

    /**
     * Changes the mouse pointer and tool tip for the row the user selects
     * 
     */
    protected void searchResults_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(searchResults, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
            e.Row.ToolTip = "Click to select this row.";
        }
    }

    /*
     * Changes the color of the rows in the Orders Table.
     * 
     */
    protected void searchResults_SelectedIndexChanged1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in searchResults.Rows)
        {
            if (row.RowIndex == searchResults.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#3498DB");
                row.ToolTip = string.Empty;
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }
        }
    }

}