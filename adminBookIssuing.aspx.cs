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
    public partial class adminBookIssuing : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        BOOK_INVENTORY bookInv = new BOOK_INVENTORY();
        BOOK_ISSUE bookIssue = new BOOK_ISSUE();
        memberModels mModels = new memberModels();
        bookIssueModels BIModels = new bookIssueModels();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
        }

        void serialize()
        {
            BIModels.memberID = TextBoxMemberID.Text;
            BIModels.memberName = TextBoxMemberName.Text;
            BIModels.bookID = TextBoxBookID.Text;
            BIModels.bookName = TextBoxBookName.Text;
            BIModels.issueDate = TextBoxStartDate.Text;
            BIModels.dueDate = TextBoxEndDate.Text;

            jsonstring = JsonConvert.SerializeObject(BIModels);
        }

        void clearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxMemberName.Text = "";
            TextBoxBookID.Text = "";
            TextBoxBookName.Text = "";
            TextBoxStartDate.Text = "";
            TextBoxEndDate.Text = "";
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            mModels.memberID = TextBoxMemberID.Text;

            string mJsonstring = JsonConvert.SerializeObject(mModels);

            DataTable memberTable = member.getMemberByID(mJsonstring);
            DataTable bookTable = bookInv.getBookByID(TextBoxBookID.Text.ToString().Trim());

            if(memberTable.Rows.Count > 0 && bookTable.Rows.Count > 0)
            {
                TextBoxMemberName.Text = memberTable.Rows[0]["full_name"].ToString();
                TextBoxBookName.Text = bookTable.Rows[0]["book_name"].ToString();
            }
            else if(memberTable.Rows.Count == 0)
            {
                Response.Write("<script>alert('Member ID does not exist!');</script>");
            }
            else if(bookTable.Rows.Count == 0)
            {
                Response.Write("<script>alert('Book ID does not exist!');</script>");
            }
        }

        protected void IssueBook_Click(object sender, EventArgs e)
        {
            serialize();

            int result = bookIssue.issueBook(jsonstring);

            if(result == 0)
            {
                Response.Write("<script>alert('INSERT QUERY FAILED!');</script>");
            }
            else if(result == 1)
            {
                GridViewBookIssueList.DataBind();
                clearForm();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('PLEASE SELECT DATES!');</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('DATE MUST NOT BE PREVIOUS FROM TODAY!');</script>");
            }
            else if(result == 4)
            {
                Response.Write("<script>alert('DATE MUST RANGE MUST BE 1 OR MORE DAYS!');</script>");
            }
            else if(result == 5)
            {
                Response.Write("<script>alert('MEMBER DOES NOT EXIST!');</script>");
            }
            else if(result == 6)
            {
                Response.Write("<script>alert('BOOK DOES NOT EXIST!');</script>");
            }
            else if(result == 7)
            {
                Response.Write("<script>alert('BOOK IS OUT OF STOCK!');</script>");
            }
            else if(result == 8)
            {
                Response.Write("<script>alert('MEMBER ALREADY ISSUED THIS BOOK!');</script>");
            }
            else if(result == 9)
            {
                Response.Write("<script>alert('Return the book you have failed to return!');</script>");
            }
            else if(result == 10)
            {
                Response.Write("<script>alert('Your account is not activated!');</script>");
            }
            else
            {
                Response.Write("<script>alert('TRY CATCH ERROR!');</script>");
            }
        }

        protected void ButtonReturnBook_Click(object sender, EventArgs e)
        {
            serialize();

            int result = bookIssue.returnBook(jsonstring);

            if(result == 0)
            {
                Response.Write("<script>alert('RETURN QUERY FAILED!');</script>");
            }
            if(result == 1)
            {
                GridViewBookIssueList.DataBind();
                clearForm();
            }
            if(result == 2)
            {
                Response.Write("<script>alert('Member does not exist!');</script>");
            }
            if(result == 3)
            {
                Response.Write("<script>alert('Book does not exist!');</script>");
            }
            if(result == 4)
            {
                Response.Write("<script>alert('Nothing to return!');</script>");
            }
            if(result == 5)
            {
                Response.Write("<script>alert('Try catch error!');</script>");
            }
        }

        protected void GridViewBookIssueList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                DateTime today = DateTime.Today;

                if(today > dt)
                {
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
        }
    }
}