using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_viewmessage : System.Web.UI.Page
{
    /**
     * Displays the information about the message the user sent in.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee_id"] == null)
        {

            Response.Redirect("~/admin/index.aspx");
        }
        else
        {

            if (!String.IsNullOrEmpty(Request.QueryString["message_id"]) && !this.IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["message_id"]);
                String exe = "SELECT * FROM contactus where id=" + id;
                DataTable dt = Connector.SelectStatements(exe);

                DataRow dr = dt.Rows[0];
                firstname.Enabled = false;
                firstname.Text = dr["first_name"].ToString();
                lastname.Text = dr["last_name"].ToString();
                lastname.Enabled = false;
                email.Text = dr["email"].ToString();
                email.Enabled = false;
                subject.Text = dr["subject"].ToString();
                subject.Enabled = false;
                message.Text = dr["message"].ToString();
                message.Enabled = false;
            }

        }
    }
}