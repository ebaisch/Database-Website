using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout1 : System.Web.UI.Page
{
    /**
     * Checks to make sure the user is logged in.
     * Populates the combobox with a list of the users addresses.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            if (!IsPostBack)
            {
                int customerID = int.Parse(Session["user_id"].ToString());
                String exe = "select * from shopping_cart where customer_id= " + customerID;
                DataTable dt = Connector.SelectStatements(exe);
                PopulateSideBar(dt);

                String ship = "select * from shipping_address where customer_id=" + customerID;
                dt = Connector.SelectStatements(ship);
                if (dt != null && dt.Rows.Count > 0)
                {
                    shippingDropDownList.DataTextField = "name";
                    shippingDropDownList.DataValueField = "name";
                    shippingDropDownList.DataSource = dt;
                    shippingDropDownList.DataBind();

                }
                else
                {
                    Response.Redirect("/shipping.aspx");
                }
            }

        }
        else
        {
            Response.Redirect("/index.aspx");
        }
    }

    /**
     * Redirects to the second checkout page and saves the shipping option the user selects to a cookie.
     * 
     */
    protected void ToCheckout2(object sender, EventArgs e)
    {

        if (shippingDropDownList.SelectedIndex > -1)
        {
            Session["address"] = shippingDropDownList.SelectedValue;
            Response.Redirect("checkout2.aspx");
        }

    }

    /**
     * This populates the side bar with information about the order. (Subtotal, tax, total)
     * 
     */
    public void PopulateSideBar(DataTable dt1)
    {
        double subtotal = 0;
        foreach (DataRow row in dt1.Rows)
        {
            String exe = "SELECT * FROM product where product_id=" + row.Field<int>("product_id");
            DataTable dt = Connector.SelectStatements(exe);

            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                subtotal += (int)row["quanity"] * dr.Field<double>("price");
            }
        }
        sideOrderSubtotal.Text = subtotal.ToString("0.00");
        double x = 5;
        sideShippingHandling.Text = x.ToString("0.00");
        sideTax.Text = ((subtotal + x) * .08521).ToString("0.00");
        sideTotal.Text = (((subtotal + x) * .08521) + subtotal + x).ToString("0.00");
    }

    /**
     * Not used
     * 
     */
    protected void ShippingDropDownListChanged(object sender, EventArgs e)
    {
        //DataRow dr = shippingDropDownList.SelectedItem
    }
}