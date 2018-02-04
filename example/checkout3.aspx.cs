using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /**
          * Checks to make sure the user is logged in, otherwise redirects them to the home page.
          * Populates the payment dropdown list with a list of the users payments.
          * 
          */
        if (Session["user_id"] != null)
        {
            if (!IsPostBack)
            {
                int customerID = int.Parse(Session["user_id"].ToString());
                String exe = "select * from shopping_cart where customer_id= " + customerID;
                DataTable dt = Connector.SelectStatements(exe);
                PopulateSideBar(dt);

                String payment = "select * from payment where customer_id=" + customerID;
                dt = Connector.SelectStatements(payment);
                if (dt != null && dt.Rows.Count > 0)
                {
                    paymentDropDownList.DataTextField = "name";
                    paymentDropDownList.DataValueField = "name";
                    paymentDropDownList.DataSource = dt;
                    paymentDropDownList.DataBind();

                }
                else
                {
                    Response.Redirect("/payments.aspx");
                }
            }

        }
        else
        {
            Response.Redirect("/index.aspx");
        }
    }

    /**
     * Saves the payment method and redirects to the final checkout page.
     * 
     */
    protected void ToReviewOrder(object sender, EventArgs e)
    {
        if (paymentDropDownList.SelectedIndex > -1)
        {
            Session["payment"] = paymentDropDownList.SelectedValue;
            Response.Redirect("checkout4.aspx");
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
}