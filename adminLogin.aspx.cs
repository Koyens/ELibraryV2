using ELibrary.classes;
using ELibrary.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class adminLogin : System.Web.UI.Page
    {
        ADMIN admin = new ADMIN();
        adminModels model = new adminModels();
        string jsonstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxAdminID.Focus();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = admin.adminLogin(jsonstring);

                if(result == 1)
                {
                    Session["role"] = "admin";
                    Response.Redirect("homepage.aspx");
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Member ID is not registered!')</script");
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password!')</script");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!')</script");
            }
        }

        bool verify()
        {
            if(TextBoxAdminID.Text.Trim() == "" || TextBoxAdminPassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.adminID = TextBoxAdminID.Text;
                model.password = TextBoxAdminPassword.Text;

                jsonstring = JsonConvert.SerializeObject(model);
                return true;
            }
        }
    }
}