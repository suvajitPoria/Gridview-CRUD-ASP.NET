using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BLL.Model;

namespace DAL
{
    public class DALGirdviewCRUD
    {
        public DataTable ReadStudent()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spReadStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public string CreateStudent(StudentInfo studentInfo, out bool status)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", studentInfo.Name);
                    cmd.Parameters.AddWithValue("@Email", studentInfo.Email);
                    cmd.Parameters.AddWithValue("@Course", studentInfo.Course);
                    cmd.Parameters.AddWithValue("@Age", studentInfo.Age);
                    try
                    {
                        con.Open();
                        status = true;
                        return cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        return ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string UpdateStudent(StudentInfo studentInfo, int StudentId, out bool status)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentId);
                    cmd.Parameters.AddWithValue("@Name", studentInfo.Name);
                    cmd.Parameters.AddWithValue("@Email", studentInfo.Email);
                    cmd.Parameters.AddWithValue("@Course", studentInfo.Course);
                    cmd.Parameters.AddWithValue("@Age", studentInfo.Age);
                    try
                    {
                        con.Open();
                        status = true;
                        return cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        return ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteStudent(int StudentId, out bool status)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentId);
                    try
                    {
                        con.Open();
                        status = true;
                        return cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        return ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
