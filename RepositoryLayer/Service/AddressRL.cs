using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly IConfiguration iConfiguration;
        public AddressRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public string AddAddress(AddressModel addressModel, int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spAddAddress", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                        cmd.Parameters.AddWithValue("@City", addressModel.City);
                        cmd.Parameters.AddWithValue("@State", addressModel.State);
                        cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        con.Open();
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        if (result == 2)
                        {
                            return "Please Enter Correct Address TypeId For Adding Address";
                        }
                        else
                        {
                            return "Address Added Successfully";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public AddressModel UpdateAddress(AddressModel addressModel, int addressId, int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spUpdateAddress", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                        cmd.Parameters.AddWithValue("@City", addressModel.City);
                        cmd.Parameters.AddWithValue("@State", addressModel.State);
                        cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                        cmd.Parameters.AddWithValue("@AddressId", addressId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result != 0)
                        {
                            return addressModel;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public bool DeleteAddress(int addressId, int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteAddress", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AddressId", addressId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result != 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public List<AddressModel> GetAllAddresses(int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllAddresses", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            List<AddressModel> addressModel = new List<AddressModel>();
                            while (dr.Read())
                            {
                                addressModel.Add(new AddressModel
                                {
                                    Address = dr["Address"].ToString(),
                                    City = dr["City"].ToString(),
                                    State = dr["State"].ToString(),
                                    TypeId = Convert.ToInt32(dr["TypeId"]),
                                    UserId = Convert.ToInt32(dr["UserId"])
                                });
                            }
                            con.Close();
                            return addressModel;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

    }
}
