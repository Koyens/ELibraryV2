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
    public partial class userLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignup.aspx");
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            MEMBERS member = new MEMBERS();
            memberModels model = new memberModels();
            model.memberID = TextBoxMemberID.Text;
            model.password = TextBoxMemberPassword.Text;

            string jsonstring = JsonConvert.SerializeObject(model);

            if(verify())
            {
                int result = member.userLogin(jsonstring);
                if(result == 1)
                {
                    Session["role"] = "user";
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
            if(TextBoxMemberID.Text.Trim() == "" || TextBoxMemberPassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}