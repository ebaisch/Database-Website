using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modifyshipping : System.Web.UI.Page
{
    /**
     * Populate the front end with the data of the selected shipping method
     * If the user is not logged in, redirect them to the home page.
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

            if (!String.IsNullOrEmpty(Request.QueryString["shipping"]) && !IsPostBack)
            {
                String shipping = Request.QueryString["shipping"];
                //DataTable dt = Connector.SelectStatements("SELECT * FROM product where product_id=" + product_id);
                //DataRow dr = dt.Rows[0];
                //productNameTextBox.Text = (String)dr["name"];
                //productDescriptionTextBox.Text = (String)dr["description"];
                //ProductPriceTextBox.Text = dr["price"].ToString();
                //quanityTextBox.Text = dr["quanity"].ToString();

                String exe = "SELECT * FROM shipping_address WHERE name=\"" + shipping + "\" and customer_id=" + Session["user_id"];
                DataTable dt = Connector.SelectStatements(exe);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    nameTextBox.Text = dr["name"].ToString();
                    nameTextBox.ReadOnly = true;
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
     * Saves the modifictions made to the current shipping address.
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
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["name"].ToString().Equals(nameTextBox.Text))
            {
                i++;
            }
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            // update
            String update = "UPDATE shipping_address set customer_name='" + customerNameTextBox.Text + "', address='" + street.Text + "', city='" + city.Text +
                "', state='" + state.Text + "', postal_code='" + zip.Text + "', phone_number='" + phone.Text + "', email='" + email.Text + "', country='" + country.Text + "\' WHERE customer_id=" + Session["user_id"] + " and name=\"" + nameTextBox.Text + "\"";
            //Response.Write("<script>alert('WORKS!!!!');</script>");
            if (!Connector.EditStatements(update))
            {
                // error
                Response.Write("<script>alert('Error 1!');</script>");
            }

            Response.Redirect("~/account-info.aspx");
        } else
        {
            errorLabel.Text = ("Does not exist in db.");
            errorLabel.ForeColor = Color.Red;
            return;
        }
        //else
        //{
        //    // insert
        //    String insert = "INSERT INTO shipping_address (customer_id,name, customer_name,address,city,state,postal_code,phone_number,email, country) VALUES(\"" + Session["user_id"] + "\", \"" + nameTextBox.Text + "\", \"" + customerNameTextBox.Text + "\", \"" + street.Text + "\", \"" + city.Text +
        //        "\", \"" + state.Text + "\", \"" + zip.Text + "\", \"" + phone.Text + "\", \"" + email.Text + "\", \"" + country.Text + "\")";
        //    //Response.Write("<script>alert('2222222 2!');</script>");
        //    if (!Connector.EditStatements(insert))
        //    {
        //        // error
        //        Response.Write("<script>alert('Error 2!');</script>");
        //    }
        //}
    }

}