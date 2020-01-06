using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Delete
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
        public string DeleteCategory(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_delete_category", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@catID", id);
               
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }

        }


    }
}