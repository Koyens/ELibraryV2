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
    public partial class adminAuthorManagement : System.Web.UI.Page
    {
        AUTHOR author = new AUTHOR();
        authorModels model = new authorModels();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("userLogin.aspx");
            }
        }

        protected void ButtonAddAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.addAuthor(jsonstring);

                if(result == 1)
                {
                    GridViewAuthor.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Author ID already exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY ADD FAILED!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }


        protected void ButtonUpdateAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.updateAuthor(jsonstring);

                if(result == 1)
                {
                    GridViewAuthor.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Update Failed! ID Does not exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY UPDATE FAILED!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }

        protected void ButtonDeleteAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.deleteAuthor(jsonstring);

                if(result == 1)
                {
                    GridViewAuthor.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Delete Failed. Author ID does not exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY DELETE ERROR!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }


        bool verify()
        {
            if (TextBoxAuthodID.Text.Trim() == "" || TextBoxAuthorName.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.authorID = TextBoxAuthodID.Text;
                model.authorName = TextBoxAuthorName.Text;

                jsonstring = JsonConvert.SerializeObject(model);

                return true;
            }
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            DataTable table = author.authorGoSelect(TextBoxAuthodID.Text.Trim());

            if(table != null)
            {
                TextBoxAuthorName.Text = table.Rows[0]["author_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID');</script>");
            }
        }
    }
}