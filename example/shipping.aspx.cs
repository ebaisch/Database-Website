using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shipping : System.Web.UI.Page
{
    /**
     * Populates the shipping page with all of the users shipping addresses.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("~/index.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                errorLabel.Text = "";
                String exe = "SELECT * FROM shipping_address WHERE customer_id=" + Session["user_id"];
                DataTable dt = Connector.SelectStatements(exe);
                searchResults.DataSource = dt;
                searchResults.DataBind();
            }
        }
    }

    /**
     * Saves the shipping address the user adds to their shipping addresses.
     * 
     */
    protected void saveAddressOnClick(object sender, EventArgs e)
    {
        String exe = "SELECT * FROM shipping_address WHERE customer_id=" + Session["user_id"];
        DataTable dt = Connector.SelectStatements(exe);

        if (nameTextBox.Text.Length < 2)
        {
            errorLabel.Text = "Enter text for name.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

        int i = 0;
        foreach(DataRow dr in dt.Rows)
        {
            if (dr["name"].ToString().Equals(nameTextBox.Text))
            {
                i++;
            }
        }

        if (i >= 1)
        {
            errorLabel.Text = "Name already exists in data base.";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        
        // insert
        String insert = "INSERT INTO shipping_address (customer_id,name, customer_name,address,city,state,postal_code,phone_number,email, country) VALUES(\"" + Session["user_id"] + "\", \"" + nameTextBox.Text + "\", \""  + customerNameTextBox.Text + "\", \"" + street.Text + "\", \"" + city.Text +
            "\", \"" + state.Text + "\", \"" + zip.Text + "\", \"" + phone.Text + "\", \"" + email.Text + "\", \"" + country.Text + "\")";
        //Response.Write("<script>alert('2222222 2!');</script>");
        if (!Connector.EditStatements(insert))
        {
            // error
            Response.Write("<script>alert('Error 2!');</script>");
        } else
        {
            Response.Redirect("/account-info.aspx");
        }
    }

    /**
     * Redirects to the modification page of the selected shipping address.
     * 
     */
    protected void searchResults_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        //Response.Write("<script>alert('2222222 2!');</script>");
        Response.Redirect("~/modifyshipping.aspx?shipping=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);
    }

    /**
     * Updates the tooltip and cursor of the selected row.
     * 
     */
    protected void searchResults_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(searchResults, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(searchResults, "Update$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
            e.Row.ToolTip = "Click to select this row.";
        }
    }

    /**
     * Updates the selection color of the selected row.
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