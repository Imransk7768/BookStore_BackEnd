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
<<<<<<< HEAD
                    //cmd.Parameters.AddWithValue("@Password", userReg.Password);
                    cmd.Parameters.AddWithValue("@Password", Encrypt(userReg.Password));
=======
                    cmd.Parameters.AddWithValue("@Password", userReg.Password);
                    //cmd.Parameters.AddWithValue("@Password", Encrypt(userReg.Password));
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

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
<<<<<<< HEAD
                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    //cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                    var pwd = Encrypt(userLogin.Password);
                    cmd.Parameters.AddWithValue("@Password", pwd);

=======

                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                    con.Open();
                   
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
<<<<<<< HEAD
                        string query = "SELECT UserId FROM Users WHERE Email = '" + userLogin.Email + "'";
=======
                        string query = "SELECT UserId FROM Users WHERE EmaiL = '" + userLogin.Email + "'";
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var userId = Convert.ToInt32(dr["UserId"] == DBNull.Value ? default : dr["UserId"]);
                            var token = this.GenerateSecurityToken(Email, userId.ToString());
                            MSMQ msmq = new MSMQ();
                            msmq.sendData2Queue(token);
                            return token;
                        }
                    }
                    con.Close();
                    return null;
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
<<<<<<< HEAD
                        //cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Password", Encrypt(newPassword));
=======
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        //cmd.Parameters.AddWithValue("@Password", Encrypt(newPassword));
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
<<<<<<< HEAD
                    new Claim(ClaimTypes.Role, "Users"),
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
<<<<<<< HEAD
            try
            {
                if (string.IsNullOrEmpty(password))
                    return null;
                else
                {
                    password += Key;
                    var passwordBytes = Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(passwordBytes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
=======
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        }

        public static string Decrypt(string password)
        {
<<<<<<< HEAD
            try
            {
                if (string.IsNullOrEmpty(password))
                    return null;
                else
                {
                    var encodedBytes = Convert.FromBase64String(password);
                    var res = Encoding.UTF8.GetString(encodedBytes);
                    var resPass = res.Substring(0, res.Length - Key.Length);
                    return resPass;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<GetUserModel> GetUserdetails(int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                try
                {

                List<GetUserModel> userList = new List<GetUserModel>();

                SqlCommand cmd = new SqlCommand("spGetUserData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GetUserModel getUser = new GetUserModel();

                        getUser.UserId = Convert.ToInt32(dr["UserId"] == DBNull.Value ? default : dr["UserId"]);
                        getUser.FullName = Convert.ToString(dr["FullName"] == DBNull.Value ? default : dr["FullName"]);
                        getUser.Mobile = (long)Convert.ToDouble(dr["Mobile"] == DBNull.Value ? default : dr["Mobile"]);
                        userList.Add(getUser);

                    }
                    return userList;
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
=======
            if (string.IsNullOrEmpty(password))
                return "";
            var bytes = Convert.FromBase64String(password);
            var result = Encoding.UTF8.GetString(bytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        }
    }
}
