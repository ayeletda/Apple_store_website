using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using System.Data.SqlClient;
using System.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly AppleDBContext _context;
        private readonly ILogger<SignController> _logger;


        public SignController(AppleDBContext context, ILogger<SignController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // PUT: api/Sign/login
        [HttpPut("login")]
        public async Task<ActionResult<User>> GetTokenByUsername(TokenBody details)
        {
        
        //     var username = details.UserName;
        //     var password = details.Password;
        // _logger.LogError("inside put");
        // _logger.LogError("details:"+ username+" pass "+ password);
        // _logger.LogError("")
        
            if (_context.Users == null)
            {
                return NotFound();
            }
            // var theList= getUserByUsernameAndPassword("avigailsh", "aaAA11!!");
            var theList= getUserByUsernameAndPassword(details.Username, details.UserPassword);
        _logger.LogError("after function"); ////

            if (theList.ToList().Count == 0)
            {
                return BadRequest();
            }
        _logger.LogError("after count"); ////

            var user=theList[0];

            var token = "thisUserIsLoggedIn";

            user.Token = token;
        _logger.LogError("insert new token"); ////

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!CustomerExists(id))
                // {
                //     return NotFound();
                // }
                // else
                // {
                throw;
                // }
            }
        _logger.LogError("after save"); ////

            return user;
        }

        // ---------- Get from the DB a user by Username and UserPassword ----------
        List<User> getUserByUsernameAndPassword(string username, string userPassword)
        {
            List<User> theList = new List<User>();
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;"))
            {
                using (SqlCommand cmd = new SqlCommand("spGetUserByUsername", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@userPassword", userPassword);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); // running the SP
                    while (dr.Read())
                    {
                _logger.LogError("before read"); ////
                // _logger.LogError(dr.GetInt32(0)); ////
                _logger.LogError(dr.GetString(1)); ////
                _logger.LogError(dr.GetString(2)); ////
                _logger.LogError(dr.GetString(3)); ////
                _logger.LogError(dr.GetString(4)); ////
                // _logger.LogError(dr.Getvalue(5) as string?); ////

                        theList.Add(new User
                        {
                            Id = dr.GetInt32(0),
                            FisrtName = dr.GetString(1),
                            LastName = dr.GetString(2),
                            Username = dr.GetString(3),
                            UserPassword = userPassword,
                            PhoneNumber = dr.GetString(4),
                            // Token = null
                            // Token = dr.Getvalue(5) as string?
                        });
                _logger.LogError("after read"); ////
                    }
                    con.Close();

                }
                return theList ;
            }
        }

    }
}
