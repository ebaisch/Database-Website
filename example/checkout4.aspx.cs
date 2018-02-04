using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout4 : System.Web.UI.Page
{
    /**
     * Checks to make sure the user is logged in, otherwise redirects them to the home page.
     * Displays all the information and makes sure the user wants to continue.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user_id"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["product_id"] != null)
                {

                    int customerID = int.Parse(Session["user_id"].ToString());
                    int productID = int.Parse(Request.QueryString["product_id"]);

                    //  Response.Write("<script>alert('" + validItem + "!');</script>");
                    String exe = "select * from shopping_cart where customer_id= " + customerID;
                    DataTable dt = Connector.SelectStatements(exe);

                    if (dt != null)
                    {
                        displayItem(dt);
                        PopulateSideBar(dt);
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "DB returned no customer info for the item you have selected" + "');</script>");
                    }

                }
                else
                {
                    int customerID = int.Parse(Session["user_id"].ToString());



                    //  Response.Write("<script>alert('" + validItem + "!');</script>");
                    String exe = "select * from shopping_cart where customer_id= " + customerID;
                    DataTable dt = Connector.SelectStatements(exe);
                    if (dt != null)
                    {
                        displayItem(dt);
                        PopulateSideBar(dt);
                    }
                }
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }



    }

    /**
     * This method places the order.
     * 
     */
    protected void PlaceOrder(object sender, EventArgs e)
    {
        String shipAddress = (String)Session["address"];
        int customerID = int.Parse(Session["user_id"].ToString());
        String exe = "select * from shipping_address where customer_id= " + customerID+" and name=\"" + shipAddress + "\"";
        DataTable dt = Connector.SelectStatements(exe);
        int shipping_id = 0;
        int order_number = 0;
        DateTime datetime = DateTime.Now;
        String invoiceDate = datetime.ToString("yyyyMMddHHmmss");
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            shipping_id = (int)dr["shipping_id"];
            int x = 1;

            //insert data into payment table
            Random random = new Random();
            double shippmentHandle = 5.0;
            int randomNumber = random.Next(0, 1000000);
            String shipment_type = (String)Session["payment"];
            String paymentInsertSql = "INSERT INTO shipment (shipping_id, shipment_type, tracking_number, shipment_charge, date) VALUES(" + shipping_id + ", \"" +
                shipment_type + "\", " + randomNumber + ", " + shippmentHandle + ", \"" + invoiceDate + "\")";

            if (!Connector.EditStatements(paymentInsertSql))
            {
                Response.Write("<script>alert('" + "failed inseting into payment table" + "');</script>");
                return;
            }



            //order_item table insert
            String shipmentSQL = "select * from shipment where date=\"" + invoiceDate + "\"";
            DataTable p = Connector.SelectStatements(shipmentSQL);
            DataRow rowP = p.Rows[0];
            int shipment_id = Int32.Parse(rowP["shipment_id"].ToString());

            String exe1 = "INSERT INTO order_invoice (customer_ID, shipment_id, paid, sales_tax, total_price, date) VALUES(" + customerID + ", " +
                shipment_id + ", " + x + ", " + Double.Parse(sideTax.Text) + ", " + Double.Parse(sideTotal.Text)+ ","+ invoiceDate + ")";

            if (!Connector.EditStatements(exe1))
            {
                Response.Write("<script>alert('" + "Database error" + "');</script>");
                return;
            }

            String exe2 = "select * from order_invoice where customer_id=" + customerID + " and date=" + "\""+ invoiceDate + "\"";
            DataTable result = Connector.SelectStatements(exe2);
            if (result == null) {
                Response.Write("<script>alert('" + "cant not select the order_number from DB" + "');</script>");
                return;
            }

            DataRow row = result.Rows[0];
            order_number = (int)row["order_number"];
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                int quantity = Int32.Parse(((Label)ri.FindControl("quanityTextBox")).Text);
                int produc_id = Int32.Parse(((Label)ri.FindControl("productIDLabel")).Text);
                double price = Double.Parse(((Label)ri.FindControl("priceLabel")).Text);
                String inserOrderItemTable = "insert into order_item(product_id, price, order_number, quantity) values(" + produc_id + "," + price + "," + order_number + "," + quantity + ")";
                if (!Connector.EditStatements(inserOrderItemTable))
                {
                    Response.Write("<script>alert('" + "insert order_item table failed" + "');</script>");
                    return;
                }
            }

          



            //delete from shopping_cart  

            String deleteShoppingCartItems = "delete from shopping_cart where customer_id = " + customerID;
            if (!Connector.EditStatements(deleteShoppingCartItems))
            {
                Response.Write("<script>alert('" + "Delete from shopping cart query failed" + "');</script>");
                return;
            }
            else {
                Response.Redirect("account-info.aspx");
            }

            // delete from product table
            foreach (RepeaterItem repItem in Repeater1.Items)
            {
                Label quanity = (Label)repItem.FindControl("quanityTextBox");
                int product_id = Int32.Parse(((Label)repItem.FindControl("productIDLabel")).Text);
                String exe5 = "SELECT * FROM product where product_id=" + product_id + " and quanity>=" + Int32.Parse(quanity.Text);

                DataTable dt1 = Connector.SelectStatements(exe5);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    DataRow dataRow = dt1.Rows[0];
                    String update = "update product set quanity= " + ((int)dataRow["quanity"] - Int32.Parse(quanity.Text)) + " where product_id=" + product_id;
                    if (!Connector.EditStatements(update))
                    {
                        Response.Write("<script>alert('update failed for product table');</script>");
                    }
                }
            }
            Response.Redirect("~/vieworder.aspx?order=" + order_number);


        }
        else
        {
            Response.Write("<script>alert('" + "Cannot find customer address" + "');</script>");
        }





    }
    /**
     * Displays all the items the user is going to purchase.
     * 
     */
    public void displayItem(DataTable dt1)
    {
        DataTable final = new DataTable();
        final.Columns.Add("product_id", typeof(int));
        final.Columns.Add("quanity", typeof(int));
        final.Columns.Add("is_valid", typeof(int));
        final.Columns.Add("name", typeof(String));
        final.Columns.Add("description", typeof(String));
        final.Columns.Add("image", typeof(String));
        final.Columns.Add("category_id", typeof(int));
        final.Columns.Add("price", typeof(double));
        foreach (DataRow row in dt1.Rows)
        {
            String exe = "SELECT * FROM product where product_id=" + row.Field<int>("product_id");
            DataTable dt = Connector.SelectStatements(exe);

            if (dt != null)
            {
                // result = row.Field<int>("product_id");
                DataRow dr = dt.Rows[0];
                dr["quanity"] = row["quanity"];
                final.Rows.Add(dt.Rows[0].ItemArray);
            }
            else
            {
                Response.Write("<script>alert('" + "nothing has returned from db" + "');</script>");
            }
        }

        Repeater1.DataSource = final;
        Repeater1.DataBind();
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