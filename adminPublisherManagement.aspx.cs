using ELibrary.classes;
using ELibrary.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class adminPublisherManagement : System.Web.UI.Page
    {
        PUBLISHER publisher = new PUBLISHER();
        publisherModels model = new publisherModels();
        string jsonstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
        }

        protected void ButtonPublisherAdd_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = publisher.addPublisher(jsonstring);

                if(result == 1)
                {
                    GridViewPublisher.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Publisher ID already exist!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY ADD FAILED!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
        }

        bool verify()
        {
            if(TextBoxPublisherID.Text.Trim() == "" || TextBoxPublisherName.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.publisherID = TextBoxPublisherID.Text;
                model.publisherName = TextBoxPublisherName.Text;

                jsonstring = JsonConvert.SerializeObject(model);
                return true;
            }
        }

        protected void ButtonPublisherUpdate_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = publisher.updatePublisher(jsonstring);

                if(result == 1)
                {
                    GridViewPublisher.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Update Failed! Publisher ID does not exist!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY UPDATE ERROR!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
        }

        protected void ButtonPublisherDelete_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = publisher.deletePublisher(jsonstring);

                if(result == 1)
                {
                    GridViewPublisher.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Delete Failed! Publisher ID does not exist!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Publisher Name Invalid!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            DataTable table = publisher.publisherGoSelect(TextBoxPublisherID.Text);

            if (table != null)
            {
                TextBoxPublisherName.Text = table.Rows[0]["publisher_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID')</script>");
            }
        }
    }
}