using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class basket : System.Web.UI.Page
{
    /**
     * Populates the shopping cart with the users items from the database.
     * 
     * If the user is not logged in, Redirect the user to the home page.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            errorLabel.Text = "";
            if (!IsPostBack)
            {
                if (Request.QueryString["product_id"] != null)
                {

                    int customerID = int.Parse(Session["user_id"].ToString());
                    int productID = int.Parse(Request.QueryString["product_id"]);

                    String exe2 = "select * from shopping_cart where customer_id= " + customerID + " and product_id=" + productID;
                    DataTable dt2 = Connector.SelectStatements(exe2);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        DataRow dr2 = dt2.Rows[0];
                        //  Response.Write("<script>alert('" + (int)dr2["quanity"] + "');</script>");
                        saveItemInShoppingCart(customerID, productID, 1);
                    }
                    else
                    {
                        saveItemInShoppingCart(customerID, productID, 0);
                    }

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
      else {
            Response.Redirect("index.aspx");
        }
  

    }
    /**
     * Displays the items to the repeater on the front end.
     * 
     */
    public void displayItem(DataTable dt1) {
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
     * Saves an item to a users shopping cart
     * 
     */
    public void saveItemInShoppingCart(int customer_id, int product_id, int quanity) {
        String exe = "select * from product where product_id=" + product_id + " and quanity > 0";
        DataTable dt = Connector.SelectStatements(exe);
        if (dt != null)
        {
            String checkDuplicate = "select * from shopping_cart where customer_id=" + customer_id + " and product_id=" + product_id;
            DataTable dt1 = Connector.SelectStatements(checkDuplicate); 
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                DataRow dr = dt1.Rows[0];
                String updateQuantity = "update shopping_cart set quanity=" + ((int)dr["quanity"] + quanity) + " where product_id=" + product_id + " and customer_id=" + customer_id;
                if (!Connector.EditStatements(updateQuantity))
                {
                    Response.Write("<script>alert('" + "FAILED" + "');</script>");
                } else
                {
                    //Response.Write("<script>alert('" + (quanity) + "');</script>");
                }
            }
            else {
                String insertNew = "insert into shopping_cart (customer_id, product_id, quanity) values('" + customer_id + "','" + product_id + "', '1')";
                Connector.EditStatements(insertNew);       
            }

        }
        else {
            Response.Write("<script>alert('" + "Not enough quantity" + "');</script>");
        }
      

    }

    /**
     * If a user updates an item in the shopping cart, this method gets called and saves the new shopping cart to the database.
     * 
     */
    protected void UpdateCart(object sender, EventArgs e)
    {

        foreach (RepeaterItem repItem in Repeater1.Items)
        {
            TextBox quanity = (TextBox)repItem.FindControl("quanityTextBox");
            int product_id = Int32.Parse(((Label)repItem.FindControl("productIDLabel")).Text);
            String product_name = ((Label)repItem.FindControl("productNameLabel")).Text;
            String exe1 = "SELECT * FROM product where product_id=" + product_id + " and quanity>=" + Int32.Parse(quanity.Text);

            DataTable dt1 = Connector.SelectStatements(exe1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                //DataRow dr = dt1.Rows[0];
                //String update = "update product set quanity= " + ((int)dr["quanity"] - Int32.Parse(quanity.Text)) + " where product_id=" + product_id;
                //if (!Connector.EditStatements(update))
                //{
                //    Response.Write("<script>alert('update failed for product table');</script>");
                //}
                //else {
                String exe = "UPDATE shopping_cart set quanity=" + Int32.Parse(quanity.Text) + " WHERE customer_id=" + Session["user_id"]
                        + " and product_id=" + product_id;
                if (!Connector.EditStatements(exe))
                {
                    Response.Write("<script>alert('Error connecting to DB');</script>");
                    return;
                }

                Label ll = (Label)repItem.FindControl("totalLabel");
                Label price = (Label)repItem.FindControl("priceLabel");
                ll.Text = (Int32.Parse(quanity.Text) * Double.Parse(price.Text)).ToString();
                //   }
                //Response.Redirect("/basket.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Not Enough quanity in product table');</script>");
                errorLabel.Text = "Error not enough stock available " + product_name;
                errorLabel.ForeColor = Color.Red;
                return;
            }
        }
        int customerID = int.Parse(Session["user_id"].ToString());
        String exe5 = "select * from shopping_cart where customer_id= " + customerID;
        DataTable dt = Connector.SelectStatements(exe5);
        PopulateSideBar(dt);
    }

    /**
     * Removes an item from a users shopping cart.
     * 
     */
    protected void DeleteOnClick(object sender, CommandEventArgs e)
    {
        String product_id = (String)e.CommandArgument;
        String deleteSql = "delete from shopping_cart where product_id=" + product_id;
        if (Connector.EditStatements(deleteSql))
        {
            Response.Write("<script>alert('successful delete');</script>");
        }
        else {
            Response.Write("<script>alert('failed delete');</script>");
        }
        Response.Redirect("/basket.aspx");
       

    }

    /**
     * If a user wants to checkout their cart, redirect them to the first checkout page.
     * 
     */
    protected void CheckoutCart(object sender, EventArgs e)
    {


        bool validateCartItem = validateCart();
        if (validateCartItem)
        {
            Response.Redirect("checkout1.aspx");
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
     * Checks to make sure all items are in stock before the user checks out.
     * 
     */
    public bool validateCart() {
        foreach (RepeaterItem repItem in Repeater1.Items)
        {
            TextBox quanity = (TextBox)repItem.FindControl("quanityTextBox");
            int product_id = Int32.Parse(((Label)repItem.FindControl("productIDLabel")).Text);
            String product_name = ((Label)repItem.FindControl("productNameLabel")).Text;
            String exe1 = "SELECT * FROM product where product_id=" + product_id + " and quanity>=" + Int32.Parse(quanity.Text);

            DataTable dt1 = Connector.SelectStatements(exe1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                //DataRow dr = dt1.Rows[0];
                //String update = "update product set quanity= " + ((int)dr["quanity"] - Int32.Parse(quanity.Text)) + " where product_id=" + product_id;
                //if (!Connector.EditStatements(update))
                //{
                //    Response.Write("<script>alert('update failed for product table');</script>");
                //}
                //else {
                String exe = "UPDATE shopping_cart set quanity=" + Int32.Parse(quanity.Text) + " WHERE customer_id=" + Session["user_id"]
                        + " and product_id=" + product_id;
                if (!Connector.EditStatements(exe))
                {
                    Response.Write("<script>alert('Error connecting to DB');</script>");
                    return false;
                }
                //   }

                //Response.Redirect("/basket.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Not Enough quanity in product table');</script>");
                errorLabel.Text = "Error not enough stock available " + product_name;
                errorLabel.ForeColor = Color.Red;
                return false;
            }
            return true;

        }
        return false;
    }
}