using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_viewemployees : System.Web.UI.Page
{
    DataTable myList = new DataTable();
    /**
     * Restores the previous search the employee was searching.
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
            String exe1 = "SELECT * FROM employee WHERE employee_id=" + Int32.Parse(Session["employee_id"].ToString());
            DataTable d = Connector.SelectStatements(exe1);
            DataRow dr= d.Rows[0];
            if((int)dr["role_id"] != 4)
            {
                Response.Redirect("~/admin/index.aspx");
            }

            String exe = "SELECT * FROM employee";
            DataTable dt = Connector.SelectStatements(exe);
            searchResults.DataSource = dt;
            searchResults.DataBind();
        }

    }

    protected override void Render(HtmlTextWriter writer)
    {

        foreach (GridViewRow r in searchResults.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                Page.ClientScript.RegisterForEventValidation(searchResults.UniqueID, "Select$" + r.RowIndex);
                Page.ClientScript.RegisterForEventValidation(searchResults.UniqueID, "Update$" + r.RowIndex);
            }
        }

        base.Render(writer);
    }

    /**
     * Display a java script popup and redirects the employee to the product page
     * 
     */
    protected void searchResults_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>alert('" + searchResults.SelectedRow.Cells[0].Text + "');</script>");
        Response.Redirect("~/admin/search.aspx?product=" + int.Parse(searchResults.SelectedRow.Cells[0].Text));
    }

    /**
     * Changes the tooltip and cursor of the selected row.
     * 
     */
    protected void searchResults_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(searchResults, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(searchResults, "Update$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
            e.Row.ToolTip = "Click to select this row.";
        }
    }

    /**
       * Changes the background color of the selected row.
       * 
       */
    protected void searchResults_SelectedIndexChanged1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in searchResults.Rows)
        {
            if (row.RowIndex == searchResults.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#3498DB");
                row.ToolTip = string.Empty;
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }
        }
    }


    /**
     * Redirects to the admin employee page
     * 
     */
    protected void SearchResultsChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        Response.Redirect("~/admin/modifyemployee.aspx?employee_id=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);

    }
}