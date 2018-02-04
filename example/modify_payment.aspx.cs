using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modify_payment : System.Web.UI.Page
{
    /**
     * Populate the front end with the data of the selected payment method
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
            if (!String.IsNullOrEmpty(Request.QueryString["payment"]) && !IsPostBack)
            {
                paymentTypeDropDownList.Items.Add("PayPal");
                paymentTypeDropDownList.Items.Add("Credit Card");
                paymentTypeDropDownList.DataBind();

                String payment = Request.QueryString["payment"];
                String exe = "SELECT * FROM payment WHERE name=\"" + payment + "\" and customer_id=" + Session["user_id"];
                DataTable dt = Connector.SelectStatements(exe);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    nameTextBox.Text = dr["name"].ToString();
                    nameTextBox.ReadOnly = true;
                    String pay = dr["payment_type"].ToString();
                    if(pay.Equals("Credit Card"))
                    {
                        paymentTypeDropDownList.SelectedIndex = 1;
                        cardNumberTextBox.Text = dr["card_number"].ToString();
                        expTextBox.Text = dr["card_exp"].ToString();
                        csvTextBox.Text = dr["csv"].ToString();

                    } else
                    {
                        paymentTypeDropDownList.SelectedIndex = 0;
                        csvTextBox.Enabled = false;
                        cardNumberTextBox.Enabled = false;
                        expTextBox.Enabled = false;
                    }

                } else
                {
                    Response.Redirect("~/account-info.aspx");
                }
               
                errorLabel.Text = "";

             

            } else
            {
                Response.Redirect("~/account-info.aspx");
            }
            
        }
    }

    /**
     * Saves the modifictions made to the current payment method.
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
        }
        else
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
     * Changes what is editable based on the payment method the user selects.
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
        }
        else
        {
            csvTextBox.Enabled = false;
            cardNumberTextBox.Enabled = false;
            expTextBox.Enabled = false;
        }
    }
}