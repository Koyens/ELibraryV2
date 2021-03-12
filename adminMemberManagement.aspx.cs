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
    public partial class adminMemberManagement : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        memberModels model = new memberModels();
        string jsonstring;
        string buttonStatus = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
        }

        public void serializer()
        {
            model.memberID = TextBoxMemberID.Text;
            model.accountStatus = buttonStatus;
            model.fullName = TextBoxFullName.Text;

            jsonstring = JsonConvert.SerializeObject(model);
        }

        public void clearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxFullName.Text = "";
            TextBoxAccountStatus.Text = "";
            TextBoxBirthdate.Text = "";
            TextBoxContactNumber.Text = "";
            TextBoxEmail.Text = "";
            TextBoxState.Text = "";
            TextBoxCity.Text = "";
            TextBoxZipCode.Text = "";
            TextBoxPostalAddress.Text = "";
        }

        public void fillForm()
        {
            DataTable table = member.getMemberByID(jsonstring);

            if (table.Rows.Count > 0)
            {
                TextBoxFullName.Text = table.Rows[0]["full_name"].ToString();
                TextBoxAccountStatus.Text = table.Rows[0]["account_status"].ToString();
                TextBoxBirthdate.Text = table.Rows[0]["birthdate"].ToString();
                TextBoxContactNumber.Text = table.Rows[0]["contact_no"].ToString();
                TextBoxEmail.Text = table.Rows[0]["email"].ToString();
                TextBoxState.Text = table.Rows[0]["state"].ToString();
                TextBoxCity.Text = table.Rows[0]["city"].ToString();
                TextBoxZipCode.Text = table.Rows[0]["zip_code"].ToString();
                TextBoxPostalAddress.Text = table.Rows[0]["full_address"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No Data Found!')</script>");
            }
        }

        public void statusUpdater()
        {
            int result = member.updateMemberStatus(jsonstring);

            if (result == 1)
            {
                GridView1.DataBind();
                fillForm();
            }
            else if (result == 2)
            {
                Response.Write("<script>alert('Member ID does not exist!')</script>");
            }
            else if (result == 500)
            {
                Response.Write("<script>alert('TryCatch Exception Error!')</script>");
            }
            else
            {
                Response.Write("<script>alert('QUERY UPDATE ERROR!')</script>");
            }
        }


        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            serializer();
            fillForm();
        }

        protected void ButtonActive_Click(object sender, EventArgs e)
        {
            buttonStatus = "Active";
            serializer();
            statusUpdater();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxMemberID.Text = GridView1.SelectedRow.Cells[0].Text.ToString();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void ButtonPending_Click(object sender, EventArgs e)
        {
            buttonStatus = "Pending";
            serializer();
            statusUpdater();
        }

        protected void ButtonInactive_Click(object sender, EventArgs e)
        {
            buttonStatus = "Inactive";
            serializer();
            statusUpdater();
        }

        protected void ButtonMemberDelete_Click(object sender, EventArgs e)
        {
            serializer();
            int result = member.deleteMemberByName(jsonstring);

            if(result == 1)
            {
                GridView1.DataBind();
                clearForm();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Delete Failed! Member ID and Name Does not Match!');</script>");
            }
            else
            {
                Response.Write("<script>alert('QUERY DELETE ERROR!');</script>");
            }
        }
    }
}