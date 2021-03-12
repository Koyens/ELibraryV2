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
    public partial class userSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignUpYes_Click(object sender, EventArgs e)
        {
            MEMBERS member = new MEMBERS();
            memberModels model = new memberModels();
            model.fullName = TextBoxFullName.Text;
            model.birthdate = TextBoxBirthdate.Text;
            model.contactNo = TextBoxContactNumber.Text;
            model.email = TextBoxEmail.Text;
            model.state = DropDownListState.SelectedItem.Value;
            model.city = TextBoxCity.Text;
            model.zipCode = TextBoxCode.Text;
            model.fullAddress = TextBoxAddress.Text;
            model.memberID = TextBoxMemberID.Text;
            model.password = TextBoxPassword.Text;
            model.accountStatus = "pending";

            string jsonString = JsonConvert.SerializeObject(model);

            if(verify())
            {
                if(passwordMatch())
                {
                    int output = member.addUser(jsonString);
                    
                    if(output == 1)
                    {
                        Response.Write("<script>alert('Successful Registration!')</script");
                    }
                    else if(output == 2)
                    {
                        Response.Write("<script>alert('Full Name Already Exist!')</script");
                    }
                    else if(output == 3)
                    {
                        Response.Write("<script>alert('Member ID Already Taken!')</script");
                    }
                    else
                    {
                        Response.Write("<script>alert('Add Failed!')</script");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password not matched')</script");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!')</script");
            }
        }

        bool verify()
        {
            if(TextBoxFullName.Text.Trim() == "" || TextBoxBirthdate.Text.Trim() == "" || TextBoxContactNumber.Text.Trim() == "" || TextBoxEmail.Text.Trim() == "" || DropDownListState.SelectedItem.Value == "Select" || TextBoxCity.Text.Trim() == "" || TextBoxCode.Text.Trim() == "" || TextBoxAddress.Text.Trim() == "" || TextBoxMemberID.Text.Trim() == "" || TextBoxPassword.Text.Trim() == "" || TextBoxConfirmPassword.Text.Trim() == "")
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        bool passwordMatch()
        {
            if (TextBoxPassword.Text.Trim() == TextBoxConfirmPassword.Text.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}