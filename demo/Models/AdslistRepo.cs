using demo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace demo.Models
{
    public class AdslistRepo
    {
        public List<MyAdvertise> Advertises()
        {
            List<MyAdvertise> myAdvertiseList = new List<MyAdvertise>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                try
                {
                    // string query = "GetAdvertiseData2";
                    SqlCommand cmd = new SqlCommand("GetAdvertiseData2", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MyAdvertise myAdvertise = new MyAdvertise
                        {
                            advertiseId = Convert.ToInt32(reader["advertiseId"]),
                            //  pro=Convert.ToInt32(reader["productCategoryName"]),
                            advertiseTitle = Convert.ToString(reader["advertiseTitle"]),
                            advertiseDescription = Convert.ToString(reader["advertiseDescription"]),
                            advertisePrice = Convert.ToInt32(reader["advertisePrice"]),
                            //areaName=Convert.ToInt32(reader["areaName"]),
                            advertiseStatus = Convert.ToBoolean(reader["advertiseStatus"]),
                            //firstName = Convert.ToString(reader["firstName"]),
                            //advertiseApproved = Convert.ToBoolean(reader["advertiseApproved"])

                        };

                        myAdvertiseList.Add(myAdvertise);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return myAdvertiseList;
        }
        public bool ApproveAdvertise(int advertiseId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("update tbl_MyAdvertise set advertiseStatus=1 where advertiseId=@advertiseId", con);

                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@advertiseId", advertiseId);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool RejectAdvertisement(int advertiseId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("update tbl_MyAdvertise set advertiseStatus=0 where advertiseId=@advertiseId", con);

                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@advertiseId", advertiseId);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }



            }

            }
        }
    }

