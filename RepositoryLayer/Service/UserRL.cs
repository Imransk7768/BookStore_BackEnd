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
    public class UserRL : IUserRL
    {
        private SqlConnection con;
        private readonly IConfiguration iConfiguration;
        public UserRL(IConfiguration _configuration)
        {
            this.iConfiguration = _configuration;
        }
        public UserReg Registration(UserReg userReg)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                //con = new SqlConnection(iConfiguration["ConnectionStrings:Bookstore"]);
                try
                //using (con)
                {
                    SqlCommand cmd = new SqlCommand("spRegister", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", userReg.FullName);
                    cmd.Parameters.AddWithValue("@Email", userReg.Email);
                    cmd.Parameters.AddWithValue("@Mobile", userReg.Mobile);
                    cmd.Parameters.AddWithValue("@Password", userReg.Password);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return userReg;
                    }
                    return null;
                }

                catch (Exception ex)
                {
                    throw;
                }
        }
        public string Login(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                try
                {

                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    var resultcnt = (Int32)cmd.ExecuteScalar();
                    //if (resultcnt == 1)
                    //return userLogin;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            email = Convert.ToString(dr["Email"] == DBNull.Value ? default : dr["Email"]);
                        }
                        var token = this.GenerateSecurityToken(email);
                        new MSMQ().sendData2Queue(token);
                        return token;
                    }
                    else
                        con.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        public string ForgetPassword(string Email)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                try
                {
                    SqlCommand cmd = new SqlCommand("spForgetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Email = Convert.ToString(dr["Email"] == DBNull.Value ? default : dr["Email"]);
                        }
                        var token = this.GenerateSecurityToken(Email);
                        new MSMQ().sendData2Queue(token);
                        return token;
                    }
                    con.Close();
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
        }
        public bool ResetPassword(string email, string newPassword, string confirmPassword)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                try
                {
                    if (newPassword == confirmPassword)
                    {
                        SqlCommand cmd = new SqlCommand("spResetPassword", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                email = Convert.ToString(dr["Email"] == DBNull.Value ? default : dr["Email"]);
                                newPassword = Convert.ToString(dr["Password"] == DBNull.Value ? default : dr["Password"]);
                            }
                            return true;
                        }
                        return true;
                    }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
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
                    //new Claim("UserId",UserId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
