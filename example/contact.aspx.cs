using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**
     * Saves the message the user wants to send to the database.
     * If there is an error connecting to the database, display an error message
     * Otherwise, redirect to the homepage.
     * 
     */
    protected void SendMessageOnClick(object sender, EventArgs e)
    {
        if (firstname.Text.Length < 1 || lastname.Text.Length < 1 || email.Text.Length < 1 || subject.Text.Length < 1 || message.Text.Length < 1)
        {
            errorLabel.Text = "Make sure all the fields are filled in.";
        }

        String exe = "INSERT INTO contactus (first_name, last_name, email, subject, message) VALUE(\"" + firstname.Text + "\", \"" + lastname.Text + "\", \""
            + email.Text + "\", \"" + subject.Text + "\", \"" + message.Text + "\")";

        if (!Connector.EditStatements(exe))
        {
            errorLabel.Text = "Error inserting into DB.";
        } else
        {
            Response.Redirect("~/index.aspx");
        }

    }
}