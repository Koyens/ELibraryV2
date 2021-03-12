using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ELibrary.models;
using Newtonsoft.Json;

namespace ELibrary.classes
{
    public class PUBLISHER
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        publisherModels m = new publisherModels();
        SqlConnection con;

        public int addPublisher(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<publisherModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("AddPublisher",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@publisher_id", SqlDbType.NVarChar, 50).Value = m.publisherID.Trim();
                        cmd.Parameters.Add("@publisher_name", SqlDbType.NVarChar, 50).Value = m.publisherName.Trim();

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

        public int updatePublisher(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<publisherModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdatePublisher",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@publisher_id", SqlDbType.NVarChar, 50).Value = m.publisherID.Trim();
                        cmd.Parameters.Add("@publisher_name", SqlDbType.NVarChar, 50).Value = m.publisherName.Trim();

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

        public int deletePublisher(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<publisherModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("DeletePublisher", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@publisher_id", SqlDbType.NVarChar, 50).Value = m.publisherID.Trim();
                        cmd.Parameters.Add("@publisher_name", SqlDbType.NVarChar, 50).Value = m.publisherName.Trim();

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

        public DataTable publisherGoSelect(string id)
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("PublisherGoSelect",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@publisher_id", SqlDbType.NVarChar, 50).Value = id.Trim();
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

        public DataTable getPublisherDetails()
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPublisherDetails", con))
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