using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ELibrary.models;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary.classes
{
    public class AUTHOR
    {
        authorModels m = new authorModels();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;

        public int addAuthor(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<authorModels>(modelstring);
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("addAuthor",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@author_id", SqlDbType.NVarChar, 50).Value = m.authorID.Trim();
                        cmd.Parameters.Add("@author_name", SqlDbType.NVarChar, 50).Value = m.authorName.Trim();

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
                throw;
                con.Close();
            }
            finally
            {
                con.Dispose();
            }
        }

        public int updateAuthor(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<authorModels>(modelstring);

                using(con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("updateAuthor",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@author_id", SqlDbType.NVarChar, 50).Value = m.authorID.Trim();
                        cmd.Parameters.Add("@author_name", SqlDbType.NVarChar, 50).Value = m.authorName.Trim();

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
                throw;
                con.Close();
            }
            finally
            {
                con.Dispose();
            }
        }

        public int deleteAuthor(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<authorModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("deleteAuthor",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@author_id", SqlDbType.NVarChar, 50).Value = m.authorID.Trim();

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

        public DataTable authorGoSelect(string author_id)
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("authorGoSelect", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@author_id", SqlDbType.NVarChar, 50).Value = author_id.Trim();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(dt);

                        if(dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        else
                        {
                            return null;
                        }
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
        public DataTable getAuthorName()
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAuthorDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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