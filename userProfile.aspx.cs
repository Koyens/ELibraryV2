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
    public partial class userProfile : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        BOOK_ISSUE _bookIssue = new BOOK_ISSUE();
        memberModels _memberModels = new memberModels();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired!');</script>");
                Response.Redirect("userLogin.aspx");
            }
            else if(!IsPostBack)
            {
                _memberModels.memberID = Session["username"].ToString();
                jsonstring = JsonConvert.SerializeObject(_memberModels);
                DataTable table = member.getMemberByID(jsonstring);

                TextBoxFullName.Text = table.Rows[0]["full_name"].ToString();
                TextBoxBirthdate.Text = table.Rows[0]["birthdate"].ToString();
                TextBoxNumber.Text = table.Rows[0]["contact_no"].ToString();
                TextBoxEmail.Text = table.Rows[0]["email"].ToString();
                DropDownListState.SelectedValue = table.Rows[0]["state"].ToString();
                TextBoxCity.Text = table.Rows[0]["city"].ToString();
                TextBoxCode.Text = table.Rows[0]["zip_code"].ToString();
                TextBoxAddress.Text = table.Rows[0]["full_address"].ToString();
                TextBoxMemberID.Text = table.Rows[0]["member_id"].ToString();
                TextBoxOldPassword.Text = table.Rows[0]["password"].ToString();
                LabelStatus.Text = Session["accountstatus"].ToString();
            }

            if (LabelStatus.Text == "Active")
            {
                LabelStatus.CssClass = "badge badge-pill badge-success";
            }
            else if(LabelStatus.Text == "Pending")
            {
                LabelStatus.CssClass = "badge badge-pill badge-warning";
            }
            else
            {
                LabelStatus.CssClass = "badge badge-pill badge-danger";
            }
            GridViewIssuedBooks.DataSource = _bookIssue.getBookIssueDetailsByID(TextBoxMemberID.Text.ToString());
            GridViewIssuedBooks.DataBind();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            _memberModels.memberID = TextBoxMemberID.Text;
            _memberModels.fullName = TextBoxFullName.Text;
            _memberModels.birthdate = TextBoxBirthdate.Text;
            _memberModels.contactNo = TextBoxNumber.Text;
            _memberModels.email = TextBoxEmail.Text;
            _memberModels.state = DropDownListState.SelectedValue;
            _memberModels.city = TextBoxCity.Text;
            _memberModels.zipCode = TextBoxCode.Text;
            _memberModels.fullAddress = TextBoxAddress.Text;
            _memberModels.password = TextBoxNewPassword.Text;

            jsonstring = JsonConvert.SerializeObject(_memberModels);
            int result = member.updateMemberByID(jsonstring);

            if(result == 0)
            {
                Response.Write("<script>alert('QUERY FAILED!');</script>");
            }
            else if(result == 1)
            {
                Session["fullname"] = TextBoxFullName.Text.ToString().Trim();
                Response.Write("<script>alert('Updated Successfully!');</script>");
                GridViewIssuedBooks.DataSource = _bookIssue.getBookIssueDetailsByID(TextBoxMemberID.Text.ToString());
                GridViewIssuedBooks.DataBind();

                if(TextBoxNewPassword.Text != "")
                {
                    TextBoxOldPassword.Text = TextBoxNewPassword.Text.ToString();
                    TextBoxNewPassword.Text = "";
                }

            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Empty Fields!');</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Birthday Error!');</script>");
            }
            else if(result == 4)
            {
                Response.Write("<script>alert('Name Already Taken!');</script>");
            }
            else if(result == 5)
            {
                Response.Write("<script>alert('Cannot update because your account is not active!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Try Catch Error!');</script>");
            }
        }
    }
}