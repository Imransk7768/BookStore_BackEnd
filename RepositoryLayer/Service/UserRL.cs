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
            //con = new SqlConnection(iConfiguration["ConnectionStrings:Bookstore"]);
            try
            {
                using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
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
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public UserLogin Login(UserLogin userLogin)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:BookStore"]))
                {
                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                    con.Open();
                    var resultcnt = (Int32)cmd.ExecuteScalar();
                    if (resultcnt == 1)
                        return userLogin;
                    else
                        con.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GenerateSecurityToken(string email)
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
    }
}
