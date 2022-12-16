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

        public static string Key = "Imran*84";
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
                    cmd.Parameters.AddWithValue("@Password", Encrypt(userReg.Password));

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
        public string Login(UserLogin userLogin)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                try
                {

                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", Decrypt(userLogin.Password));
                    con.Open();
                   
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string query = "SELECT UserId FROM Users WHERE EmaiL = '" + userLogin.Email + "'";
                        SqlCommand com = new SqlCommand(query, con);
                        var Id = com.ExecuteScalar();
                        var token = GenerateSecurityToken(userLogin.Email, Id.ToString());
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    con.Close();
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
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string query = "SELECT UserId FROM Users WHERE EmaiL = '" + result + "'";
                        SqlCommand com = new SqlCommand(query, con);
                        var Id = com.ExecuteScalar();
                        var token = GenerateSecurityToken(Email, Id.ToString());
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    con.Close();
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
                        //var newPassword = Encrypt(confirmPassword);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", Encrypt(newPassword));
                        //cmd.Parameters.AddWithValue("@Password", Encrypt(confirmPassword));
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
        public string GenerateSecurityToken(string email, string UserId)
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
                    new Claim("UserId",UserId.ToString())
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
        public static string Encrypt(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return "";
                }
                else
                {
                    password += Key;
                    var passwordBytes = Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(passwordBytes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string Decrypt(string base64EncodeData)
        {
            try
            {
                if (string.IsNullOrEmpty(base64EncodeData))
                {
                    return "";
                }
                else
                {
                    var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
                    var result = Encoding.UTF8.GetString(base64EncodeBytes);
                    result = result.Substring(0, result.Length - Key.Length);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
