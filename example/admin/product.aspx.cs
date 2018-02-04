using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_product : System.Web.UI.Page
{
    /**
     * Loads information about the product
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["Product"]) && !this.IsPostBack)
        {
            int product_id = int.Parse(Request.QueryString["Product"]);
            DataTable dt =  Connector.SelectStatements("SELECT * FROM product where product_id=" + product_id);
            DataRow dr = dt.Rows[0];
            productNameTextBox.Text = (String)dr["name"];
            productDescriptionTextBox.Text = (String)dr["description"];
            ProductPriceTextBox.Text = dr["price"].ToString();
            quanityTextBox.Text = dr["quanity"].ToString();
            int x = (int)dr["is_valid"];
            if (x > 0)
            {
                isValidCheckBox.Checked = true;
            } else
            {
                isValidCheckBox.Checked = false;
            }
        }
    }

    /**
     * Saves the changes made to the product
     * 
     */
    protected void ModifyProduct(object sender, EventArgs e)
    {

        decimal price;
        try
        {
            Regex.Match(ProductPriceTextBox.Text, "\\d+\\.\\d{2}");
            Regex.Match(quanityTextBox.Text, "\\d+");
        }
        catch (ArgumentException)
        {
            errorLabel.Text = "Price/Quanity is incorrect";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        if (productNameTextBox.Text.Equals("") || ProductPriceTextBox.Text.Equals("") || quanityTextBox.Text.Equals(""))
        {
            errorLabel.Text = "Some fields are empty";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        if (quanityTextBox.Text.Length > 5 || productNameTextBox.Text.Length > 45 || productDescriptionTextBox.Text.Length > 45 || ProductPriceTextBox.Text.Length > 45)
        {
            errorLabel.Text = "Fields must be less then 45 characters";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        price = Decimal.Parse(ProductPriceTextBox.Text);
        String exe = "UPDATE product set name=\"" + productNameTextBox.Text + "\", description=\"" + productDescriptionTextBox.Text
            + "\", image=\"" + productImagePathTextBox.Text + "\", price=" + Decimal.Round(price, 2) + ", quanity=" + Int32.Parse(quanityTextBox.Text) +
            ", is_valid=" + ((isValidCheckBox.Checked == true) ? 1 : 0) +
            " where product_id=" + int.Parse(Request.QueryString["Product"]);

        if (!Connector.EditStatements(exe))
        {
            errorLabel.Text = "Error inserting into the database";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        Response.Redirect("~/admin/index.aspx");
    }

}