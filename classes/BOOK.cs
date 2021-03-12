using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ELibrary.models;
using Newtonsoft.Json;

namespace ELibrary.classes
{
    public class BOOK_INVENTORY
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        bookInventoryModels m = new bookInventoryModels();
        SqlConnection con;
        
        public int addBook(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<bookInventoryModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("AddBook",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@book_id", m.bookID.Trim());
                        cmd.Parameters.AddWithValue("@book_name", m.bookName.Trim());
                        cmd.Parameters.AddWithValue("@language", m.language.Trim());
                        cmd.Parameters.AddWithValue("@author_name", m.authorName.Trim());
                        cmd.Parameters.AddWithValue("@publisher_name", m.publisherName.Trim());
                        cmd.Parameters.AddWithValue("@publish_date", m.publishDate.Trim());
                        cmd.Parameters.AddWithValue("@genre", m.genre.Trim());
                        cmd.Parameters.AddWithValue("@edition", m.edition.Trim());
                        cmd.Parameters.AddWithValue("@book_cost", m.bookCost.Trim());
                        cmd.Parameters.AddWithValue("@pages", m.pages.Trim());
                        cmd.Parameters.AddWithValue("@actual_stock", m.actualStock.Trim());
                        cmd.Parameters.AddWithValue("@current_stock", m.currentStock.Trim());
                        cmd.Parameters.AddWithValue("@book_description", m.bookDescription.Trim());
                        cmd.Parameters.AddWithValue("@book_link", m.bookLink.Trim());

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return Convert.ToInt32(output.Value);
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Dispose();
            }
        }

        public DataTable getBookByID(string id)
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBookDetailsByID",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@book_id", id.Trim());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Dispose();
            }
        }

        public int updateBookByID(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<bookInventoryModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateBookDetailsByID",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@book_id", m.bookID.Trim());
                        cmd.Parameters.AddWithValue("@book_name", m.bookName.Trim());
                        cmd.Parameters.AddWithValue("@language", m.language.Trim());
                        cmd.Parameters.AddWithValue("@author_name", m.authorName.Trim());
                        cmd.Parameters.AddWithValue("@publisher_name", m.publisherName.Trim());
                        cmd.Parameters.AddWithValue("@publish_date", m.publishDate.Trim());
                        cmd.Parameters.AddWithValue("@genre", m.genre.Trim());
                        cmd.Parameters.AddWithValue("@edition", m.edition.Trim());
                        cmd.Parameters.AddWithValue("@book_cost", m.bookCost.Trim());
                        cmd.Parameters.AddWithValue("@pages", m.pages.Trim());
                        cmd.Parameters.AddWithValue("@actual_stock", m.actualStock.Trim());
                        cmd.Parameters.AddWithValue("@current_stock", m.currentStock.Trim());
                        cmd.Parameters.AddWithValue("@book_description", m.bookDescription.Trim());

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return Convert.ToInt32(output.Value);
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                return 500;
            }
            finally
            {
                con.Dispose();
            }
        }
    }

    public class BOOK_ISSUE
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        bookIssueModels m = new bookIssueModels();
        SqlConnection con;

        public int issueBook(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<bookIssueModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("IssueBook",con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
                        cmd.Parameters.AddWithValue("@member_name", m.memberName.Trim());
                        cmd.Parameters.AddWithValue("@book_id", m.bookID.Trim());
                        cmd.Parameters.AddWithValue("@book_name", m.bookName.Trim());
                        cmd.Parameters.AddWithValue("@issue_date", m.issueDate.Trim());
                        cmd.Parameters.AddWithValue("@due_date", m.dueDate.Trim());

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return Convert.ToInt32(output.Value);
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Dispose();
            }
        }

        public int returnBook(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<bookIssueModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("ReturnBook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
                        cmd.Parameters.AddWithValue("@member_name", m.memberName.Trim());
                        cmd.Parameters.AddWithValue("@book_id", m.bookID.Trim());
                        cmd.Parameters.AddWithValue("@book_name", m.bookName.Trim());

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return Convert.ToInt32(output.Value);
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                return 500;
            }
            finally
            {
                con.Dispose();
            }
        }

        public DataTable getBookIssueDetailsByID(string id)
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBookIssueDetailsByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", id.Trim());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}