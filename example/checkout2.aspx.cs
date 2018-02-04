using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout2 : System.Web.UI.Page
{
    /**
     * Checks to make sure the user is logged in, otherwise redirects them to the home page.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null) {
        int customerID = int.Parse(Session["user_id"].ToString());
        String exe = "select * from shopping_cart where customer_id= " + customerID;
        DataTable dt = Connector.SelectStatements(exe);
        PopulateSideBar(dt);
        }
        else
        {
            Response.Redirect("/index.aspx");
        }
    }

    /**
     * Saves the payment method to a session and continues to checkout 3.
     * 
     */
    protected void ToPaymentMethod(object sender, EventArgs e)
    {

        Person person = new Person();
        if (shippingRadioButton1.Checked)
        {
            person.Shipping_type = "Standard";
        }
        else if (shippingRadioButton2.Checked)
        {
            person.Shipping_type = "Express";
        }
        else if (shippingRadioButton3.Checked)
        {
            person.Shipping_type = "NextDay";
        } else
        {
            Response.Redirect("checkout2.aspx");
        }
        Session["person"] = person;

        Response.Redirect("checkout3.aspx");
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
}