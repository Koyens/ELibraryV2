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
    public class MEMBERS
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        memberModels m = new memberModels();
        SqlConnection con;

        public int addUser(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("addUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@full_name", SqlDbType.NVarChar, 50).Value = m.fullName.Trim();
                        cmd.Parameters.Add("@birthdate", SqlDbType.NVarChar, 50).Value = m.birthdate.Trim();
                        cmd.Parameters.Add("@contact_no", SqlDbType.NVarChar, 50).Value = m.contactNo.Trim();
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = m.email.Trim();
                        cmd.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = m.state.Trim();
                        cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = m.city.Trim();
                        cmd.Parameters.Add("@zip_code", SqlDbType.NVarChar, 50).Value = m.zipCode.Trim();
                        cmd.Parameters.Add("@full_address", SqlDbType.NVarChar, 50).Value = m.fullAddress.Trim();
                        cmd.Parameters.Add("@member_id", SqlDbType.NVarChar, 50).Value = m.memberID.Trim();
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = m.password.Trim();
                        cmd.Parameters.Add("@account_status", SqlDbType.NVarChar, 50).Value = m.accountStatus.Trim();

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return (Convert.ToInt32(output.Value));
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

        public int userLogin(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("userLogin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@member_id", SqlDbType.NVarChar, 50).Value = m.memberID.Trim();
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = m.password.Trim();

                        var output = cmd.Parameters.Add("@Return", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        if (Convert.ToInt32(output.Value) == 1)
                        {
                            DataTable dt = new DataTable();
                            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                            adapt.Fill(dt);
                            HttpContext.Current.Session["username"] = dt.Rows[0]["member_id"].ToString();
                            HttpContext.Current.Session["fullname"] = dt.Rows[0]["full_name"].ToString();
                            HttpContext.Current.Session["accountstatus"] = dt.Rows[0]["account_status"].ToString();
                        }
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

        public DataTable getMemberByID(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("GetMemberByID",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
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

        public int updateMemberStatus(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateMemberStatus",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
                        cmd.Parameters.AddWithValue("@account_status", m.accountStatus.Trim());

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

        public int deleteMemberByName(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteMember",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
                        cmd.Parameters.AddWithValue("@full_name", m.fullName.Trim());

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

        public int updateMemberByID(string modelstring)
        {
            try
            {
                m = JsonConvert.DeserializeObject<memberModels>(modelstring);

                using (con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateMemberByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@member_id", m.memberID.Trim());
                        cmd.Parameters.AddWithValue("@full_name", m.fullName.Trim());
                        cmd.Parameters.AddWithValue("@birthdate", m.birthdate.Trim());
                        cmd.Parameters.AddWithValue("@contact_no", m.contactNo.Trim());
                        cmd.Parameters.AddWithValue("@email", m.email.Trim());
                        cmd.Parameters.AddWithValue("@state", m.state.Trim());
                        cmd.Parameters.AddWithValue("@city", m.city.Trim());
                        cmd.Parameters.AddWithValue("@zip_code", m.zipCode.Trim());
                        cmd.Parameters.AddWithValue("@full_address", m.fullAddress.Trim());
                        cmd.Parameters.AddWithValue("@password", m.password.Trim());

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
}