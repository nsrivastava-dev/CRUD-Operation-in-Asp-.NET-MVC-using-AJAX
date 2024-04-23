using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace AjaxRevision.Models
{
    public class DataLayer
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public int ExecuteDML(string proc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand(proc, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parameter in para)
            {
                if (parameter.Value != null)
                    cmd.Parameters.Add(parameter);
            }
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            
        }
        public DataTable ExecuteSelect(string proc)
        {
            SqlCommand cmd = new SqlCommand(proc, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public DataTable ExecuteSelect(string proc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand(proc, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parameter in para)
            {
                if (parameter.Value != null)
                    cmd.Parameters.Add(parameter);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
        public object ExecuteScalar(string proc, SqlParameter[] para) 
        {
            SqlCommand cmd = new SqlCommand(proc, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parameter in para)
            {
                if (parameter.Value != null)
                    cmd.Parameters.Add(parameter);
            }

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();
            return result;

        }
    }
}