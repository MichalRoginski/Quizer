using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.NET.DataAccess
{
    public class Ado_Net
    {

        public  string GetPassword(string username, IConfiguration conf)
        {
            string connectionString = conf.GetConnectionString("ADO.NET");
            string password = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    password = rdr["password"].ToString();
                }
                con.Close();
            }
            return password;
        }
        public  List<string> GetCategories(IConfiguration conf)
        {
            string connectionString = conf.GetConnectionString("ADO.NET");
            List<string> categories = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    categories.Add( rdr["Category"].ToString());
                }
                con.Close();
            }
            return categories;
        }
    }
}
