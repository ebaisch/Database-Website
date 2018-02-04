using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_search : System.Web.UI.Page
{
    DataTable myList = new DataTable();
    /**
     * Restores the previous search the employee was searching.
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["Search"]) && !this.IsPostBack)
        {
            this.myList = SearchForProduct(Request.QueryString["Search"], searchOptionDropDownList.Text);
            searchTextBox.Text = Request.QueryString["Search"];
            searchResults.DataSource = myList;
            searchResults.DataBind();
        } else
        {
            searchResults.DataSource = myList;
            searchResults.DataBind();
        }
        //Response.Write("<script>alert('" + myList.ToString() + "!');</script>");
        //searchResults.DataSource = myList;
        
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
     * Searches for the item, if the user doesn't enter more then 2 characters then display an error in a javascript popup.
     * 
     */
    protected void searchTextBoxChanged(object sender, EventArgs e)
    {
        //List<Users> myList = MyConnection.Ad.SearchForUser(searchTextBox.Text, searchOptionDropDownList.Text);
        //searchResults.DataSource = myList;
        if (searchTextBox.Text.Length >= 2)
        {
            //Response.Write("<script language=javascript>alert('testtt');</script>");
            Response.Redirect("~/admin/search.aspx?Search=" + searchTextBox.Text);
        }
        else
        {
            Response.Write("<script language=javascript>alert('Search box must have more then 2 characters.');</script>");
        }

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
     * Binds the search text box to the search results data source
     * 
     */
    protected void bindData(object sender, EventArgs e)
    {
        if (searchTextBox.Text.Length >= 2)
        {
            this.myList = SearchForProduct(Request.QueryString["Search"], searchOptionDropDownList.Text);
            searchResults.DataSource = myList;
        }
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
     * Processes the search results
     * 
     */
    public DataTable SearchForProduct(String searchName, String searchBy)
    {
        DataTable dt = null;
        if (searchBy.Equals("Product Name"))
        {
            //BoundField field = (BoundField)this.searchResults.Columns[0];
            //field.DataField = "product_id";
            String exe = "Select * FROM product where name LIKE \"%" + searchName + "%\"";
            dt = Connector.SelectStatements(exe);
            return dt;
        }

        // select
        return dt;
    }

    /**
     * Redirects to the admin product page
     * 
     */
    protected void SearchResultsChanging(object sender, GridViewSelectEventArgs e)
    {
        //Response.Write("<script language=javascript>alert('" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text + "');</script>");
        Response.Redirect("~/admin/product.aspx?Product=" + searchResults.Rows[e.NewSelectedIndex].Cells[0].Text);
       
    }
}