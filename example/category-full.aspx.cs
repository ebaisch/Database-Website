using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class category_full : System.Web.UI.Page
{
    /**
     * Populates the Repeater with the products in the database.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        String exe = "SELECT * FROM PRODUCT WHERE is_valid=1 and quanity > 0";
        DataTable dt = Connector.SelectStatements(exe);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

}