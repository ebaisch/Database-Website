using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addproduct : System.Web.UI.Page
{

    /**
     * Validation is done through the matser page
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**
     * Allows employees to add products to the database
     * 
     */
    protected void AddProduct(object sender, EventArgs e)
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
        if(quanityTextBox.Text.Length > 5 || productNameTextBox.Text.Length > 45 || productDescriptionTextBox.Text.Length > 45 || ProductPriceTextBox.Text.Length > 45)
        {
            errorLabel.Text = "Fields must be less then 45 characters";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        price = Decimal.Parse(ProductPriceTextBox.Text);
        String qwe = "SELECT * FROM product WHERE name=\"" + productNameTextBox.Text + "\"";
        DataTable dt = Connector.SelectStatements(qwe);

        String result = "";
        foreach (DataRow dr in dt.Rows)
        {
            result = dr.Field<String>("name");
            if (result.Equals(productNameTextBox.Text))
            {
                errorLabel.Text = "product name already exists.";
                errorLabel.ForeColor = Color.Red;
                return;
            }
        }
        

        String exe = "INSERT INTO product (name, description, image, price, quanity, is_valid) VALUES('" + productNameTextBox.Text + "', '" +
            productDescriptionTextBox.Text + "', '" + productImagePathTextBox.Text + "', '" + Decimal.Round(price, 2) + 
            "', '" + Int32.Parse(quanityTextBox.Text) + "', '" + ((isValidCheckBox.Checked == true) ? 1 : 0) + "')";

        if (!Connector.EditStatements(exe))
        {
            errorLabel.Text = "Error inserting into the database";
            errorLabel.ForeColor = Color.Red;
            return;
        }
        Response.Redirect("~/admin/index.aspx");
    }
}