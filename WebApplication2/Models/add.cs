using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Models
{
    public class add
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
        public string addcat (catmodel obj) {
            try
            {
                SqlCommand cmd = new SqlCommand("st_insetCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@status", obj.status);
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
        public string addstore(storemodel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_insertStore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@status", obj.status);
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
        public string addtable(tablemodel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_inserttable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@status", obj.status);
                cmd.Parameters.AddWithValue("@capacity", obj.capacity);
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
        public string addproduct(productmodel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_insertproduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.product_name);
                cmd.Parameters.AddWithValue("@status", obj.status);
                cmd.Parameters.AddWithValue("@quantity", obj.capacity);
                cmd.Parameters.AddWithValue("@price", obj.price);
                cmd.Parameters.AddWithValue("@catid", obj.category_id);
                cmd.Parameters.AddWithValue("@storeid", obj.store_id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {
                return ("Failed");

            }
        }
    }
}