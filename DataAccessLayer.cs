using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudMVC.Models
{
    public class DataAccessLayer
    {
        public string InsertData(Class1 MD)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileID", 0);
                // i will pass zero to MobileID beacause its Primary .  
                cmd.Parameters.AddWithValue("@MobileName", MD.MobileName);
                cmd.Parameters.AddWithValue("@MobileIMEno", MD.MobileIMEno);
                cmd.Parameters.AddWithValue("@mobileprice", MD.mobileprice);
                cmd.Parameters.AddWithValue("@mobileManufacured", MD.mobileManufacured);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public string UpdateData(Class1 MD)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileID", MD.MobileID);
                cmd.Parameters.AddWithValue("@MobileName", MD.MobileName);
                cmd.Parameters.AddWithValue("@MobileIMEno", MD.MobileIMEno);
                cmd.Parameters.AddWithValue("@mobileprice", MD.mobileprice);
                cmd.Parameters.AddWithValue("@mobileManufacured", MD.mobileManufacured);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public string DeleteData(Class1 MD)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileID", MD.MobileID);
                cmd.Parameters.AddWithValue("@MobileName", null);
                cmd.Parameters.AddWithValue("@MobileIMEno", null);
                cmd.Parameters.AddWithValue("@mobileprice", 0);
                cmd.Parameters.AddWithValue("@mobileManufacured", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }




        public DataSet SelectAllData()
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileID", 0);
                cmd.Parameters.AddWithValue("@MobileName", null);
                cmd.Parameters.AddWithValue("@MobileIMEno", null);
                cmd.Parameters.AddWithValue("@mobileprice", 0);
                cmd.Parameters.AddWithValue("@mobileManufacured", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet(); da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
            finally
            {
                con.Close();
            }
        }




        public DataSet SelectAllDatabyID(string MobileID)
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileID", MobileID); // i will pass zero to MobileID beacause its Primary .  
                cmd.Parameters.AddWithValue("@MobileName", null);
                cmd.Parameters.AddWithValue("@MobileIMEno", null);
                cmd.Parameters.AddWithValue("@mobileprice", 0);
                cmd.Parameters.AddWithValue("@mobileManufacured", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
            finally
            {
                con.Close();
            }
        }



    }
}