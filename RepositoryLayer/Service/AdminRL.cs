using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly IConfiguration iConfiguration;
        public AdminRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public static string tokenKey = "ImranshaikTokenNo123";

        public AdminModel AddAdmin(AdminModel adminModel)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                //con = new SqlConnection(iConfiguration["ConnectionStrings:Bookstore"]);
                try
                //using (con)
                {
                    SqlCommand cmd = new SqlCommand("spAdminRegister", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@AdminId", adminModel.AdminId);
                    cmd.Parameters.AddWithValue("@FullName", adminModel.FullName);
                    cmd.Parameters.AddWithValue("@Email", adminModel.Email);
                    cmd.Parameters.AddWithValue("@Mobile", adminModel.Mobile);
                    cmd.Parameters.AddWithValue("@Password", adminModel.Password);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return adminModel;
                    }
                    return null;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public string AdminLogin(AdminLoginModel adminLogin)
        {

            using SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]);
            try
            {
                SqlCommand cmd = new SqlCommand("spAdminLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", adminLogin.Email);
                cmd.Parameters.AddWithValue("@Password", adminLogin.Password);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //adminModel.AdminId = Convert.ToString(dr["AdminId"] == DBNull.Value ? default : dr["AdminId"]);
                        //adminModel.FullName = Convert.ToString(dr["FullName"] == DBNull.Value ? default : dr["FullName"]);
                        adminLogin.Email = Convert.ToString(dr["Email"] == DBNull.Value ? default : dr["Email"]);
                        adminLogin.Password = Convert.ToString(dr["Password"] == DBNull.Value ? default : dr["Password"]);
                        //adminModel.Mobile = Convert.ToString(dr["Mobile"] == DBNull.Value ? default : dr["Mobile"]);
                        var token = GenerateSecurityToken(adminLogin.Email);
                        return token;
                    }
                }
                else
                {
                    con.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return default;
        }
        public string GenerateSecurityToken(string email)
        {

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.iConfiguration[("JWT:Key")]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, email),
                    //new Claim("UserId", UserId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
