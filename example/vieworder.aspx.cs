using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vieworder : System.Web.UI.Page
{
    /**
     * Displays information about the order along with all of the products.
     * Populates the repeater in the front end to display all the items in that order.
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
            if (!String.IsNullOrEmpty(Request.QueryString["order"]) && !IsPostBack)
            {
                int order_number = Int32.Parse(Request.QueryString["order"]);
                errorLabel.Text = "";
                String exe = "SELECT * FROM order_item WHERE order_number=" + order_number;
                DataTable dt = Connector.SelectStatements(exe);
                searchResults.DataSource = dt;
                searchResults.DataBind();


                exe = "SELECT * FROM order_invoice WHERE order_number=" + order_number;
                dt = Connector.SelectStatements(exe);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    orderDateTextBox.Enabled = false;
                    ordernumberTextBox.Enabled = false;
                    orderDateTextBox.Enabled = false;
                    salesTaxTextBox.Enabled = false;
                    totalPriceTextBox.Enabled = false;

                    ordernumberTextBox.Text = dr["order_number"].ToString();
                    orderDateTextBox.Text = dr["order_date"].ToString();
                    salesTaxTextBox.Text = dr["sales_tax"].ToString();
                    totalPriceTextBox.Text = dr["total_price"].ToString();

                    exe = "SELECT * FROM shipment WHERE shipment_id = " + Int32.Parse(dr["shipment_id"].ToString());
                    dt = Connector.SelectStatements(exe);
                    dr = dt.Rows[0];

                    exe = "SELECT * FROM shipping_address WHERE shipping_id = " + Int32.Parse(dr["shipping_id"].ToString());
                    dt = Connector.SelectStatements(exe);
                    dr = dt.Rows[0];

                    nameTextBox.Text = dr["name"].ToString();
                    nameTextBox.ReadOnly = true;
                    customerNameTextBox.ReadOnly = true;
                    street.ReadOnly = true;
                    city.ReadOnly = true;
                    state.ReadOnly = true;
                    zip.ReadOnly = true;
                    phone.ReadOnly = true;
                    email.ReadOnly = true;
                    country.ReadOnly = true;
                    customerNameTextBox.Text = dr["customer_name"].ToString();
                    street.Text = dr["address"].ToString();
                    city.Text = dr["city"].ToString();
                    state.Text = dr["state"].ToString();
                    zip.Text = dr["postal_code"].ToString();
                    phone.Text = dr["phone_number"].ToString();
                    email.Text = dr["email"].ToString();
                    country.Text = dr["country"].ToString();

                }


            }
        }
    }

    /**
     * Allows the user to midify the payment method for the selected item
     * 
     */
    protected void searchResults_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        //Response.Write("<script>alert('2222222 2!');</script>");
        Response.Redirect("~/modify_payment.aspx?payment=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);
    }

    /**
     * Updates the tooltip and curson on a selected row.
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
     * Changes the color of the selection to blue.
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