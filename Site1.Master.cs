using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                LinkButtonViewBooks.Visible = false;
                LinkButtonUserLogin.Visible = true;
                navbarDropdown.Visible = false;
                LinkButtonAdminLogin.Visible = true;
                LinkButtonAuthor.Visible = false;
                LinkButtonPublisher.Visible = false;
                LinkButtonBookInventory.Visible = false;
                LinkButtonBookIssuing.Visible = false;
                LinkButtonMemberManagement.Visible = false;
                LinkButtonAdminLogin.Visible = true;

            }
            else if(Session["role"].Equals("user"))
            {
                LinkButtonViewBooks.Visible = true;
                LinkButtonUserLogin.Visible = false;
                navbarDropdown.Visible = true;
                LinkButtonAdminLogin.Visible = true;
                LinkButtonAuthor.Visible = false;
                LinkButtonPublisher.Visible = false;
                LinkButtonBookInventory.Visible = false;
                LinkButtonBookIssuing.Visible = false;
                LinkButtonMemberManagement.Visible = false;
                LinkButtonAdminLogin.Visible = false;

                navbarDropdown.Text = "Hello, " + Session["fullname"].ToString();
            }
            else if(Session["role"].Equals("admin"))
            {
                LinkButtonViewBooks.Visible = true;
                LinkButtonUserLogin.Visible = false;
                navbarDropdown.Visible = true;
                LinkButtonAdminLogin.Visible = false;
                LinkButtonAuthor.Visible = true;
                LinkButtonPublisher.Visible = true;
                LinkButtonBookInventory.Visible = true;
                LinkButtonBookIssuing.Visible = true;
                LinkButtonMemberManagement.Visible = true;
                LinkButtonProfileView.Visible = false;
                LinkButtonAdminLogin.Visible = false;

                navbarDropdown.Text = "Hello, " + Session["fullname"].ToString();
            }
        }

        protected void LinkButtonAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkButtonAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButtonPublisher_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkButtonBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButtonBookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssuing.aspx");
        }

        protected void LinkButtonMemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkButtonUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = null;
            Session["accountstatus"] = "";
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButtonProfileView_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void LinkButtonViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBooks.aspx");
        }
    }
}