using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class payments : System.Web.UI.Page
{
    /**
     * Displays a list of all the payment methothds in the users account.
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
                csvTextBox.Enabled = false;
                cardNumberTextBox.Enabled = false;
                expTextBox.Enabled = false;
                errorLabel.Text = "";
                String exe = "SELECT * FROM payment WHERE customer_id=" + Session["user_id"];
                DataTable dt = Connector.SelectStatements(exe);
                searchResults.DataSource = dt;
                searchResults.DataBind();

                paymentTypeDropDownList.Items.Add("PayPal");
                paymentTypeDropDownList.Items.Add("Credit Card");
                paymentTypeDropDownList.DataBind();

            }
        }
    }

    /**
     * Saves the new payment method the user wants to add.
     * 
     */
    protected void savePaymentOnClick(object sender, EventArgs e)
    {
        String exe = "SELECT * FROM payment WHERE customer_id=" + Session["user_id"];
        DataTable dt = Connector.SelectStatements(exe);

        if (nameTextBox.Text.Length < 2)
        {
            errorLabel.Text = "Enter text for name.";
            errorLabel.ForeColor = Color.Red;
            return;
        }

        int i = 0;
        foreach (DataRow dr in dt.Rows)
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

        String insert = "";
        // insert
        if (paymentTypeDropDownList.SelectedValue.ToString().Equals("Credit Card"))
        {
            insert = "INSERT INTO payment (customer_id,name, payment_type,card_number,card_exp,csv) VALUES(" + Session["user_id"] + ", \"" + nameTextBox.Text
                + "\", \"" + paymentTypeDropDownList.SelectedValue.ToString() + "\", \"" + cardNumberTextBox.Text + "\", \"" + expTextBox.Text + "\", " + Int32.Parse(csvTextBox.Text) + ")";
        } else
        {
            insert = "INSERT INTO payment (customer_id, name, payment_type) VALUES(" + Session["user_id"] + ", \"" + nameTextBox.Text + "\", \"" + paymentTypeDropDownList.SelectedValue.ToString() + "\")";
        }
            //Response.Write("<script>alert('2222222 2!');</script>");
        if (!Connector.EditStatements(insert))
        {
            // error
            Response.Write("<script>alert('Error 2!');</script>");
        }
        else
        {
            Response.Redirect("/account-info.aspx");
        }
    }

    /**
     * Redirects to the modification page of the selected payment method.
     * 
     */
    protected void searchResults_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        //Response.Write("<script>alert('2222222 2!');</script>");
        Response.Redirect("~/modify_payment.aspx?payment=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);
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

    /**
     * Changes what is editable based on the selected payment method.
     * 
     */
    protected void paymentTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList s = sender as DropDownList;
        if (s.Text.Equals("Credit Card"))
        {
            csvTextBox.Enabled = true;
            cardNumberTextBox.Enabled = true;
            expTextBox.Enabled = true;
        } else
        {
            csvTextBox.Enabled = false;
            cardNumberTextBox.Enabled = false;
            expTextBox.Enabled = false;
        }
    }
}