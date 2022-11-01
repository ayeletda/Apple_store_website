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
    public class ShoppingController : ControllerBase
    {
        private readonly AppleDBContext _context;
        private readonly ILogger<ShoppingController> _logger;
        // private readonly Environments _environments;

        public ShoppingController(AppleDBContext context, ILogger<ShoppingController> logger)
        {
            _context = context;
            _logger = logger;
            // _environments = new Environments();
        }

        // GET: api/Shopping/Cart/{id}
        [HttpGet("Cart/{id}")]
        public async Task<ActionResult<IEnumerable<Cart>>> Cart(int id, string procedure)
        {
            //---------------------------------------------------------
            // procedureName = spGetCartByUserId | spGetHistoryByUserId
            //---------------------------------------------------------
        _logger.LogError("before function");
            return getCartByUserId(id, procedure);
        _logger.LogError("after function");
        }

        // ---------- Carts ----------
        List<Cart> getCartByUserId(int id, string procedure)
        {
            List<Cart> theList = new List<Cart>();
            // using (SqlConnection con = new SqlConnection(_environments.Context))
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;"))
            {
                using (SqlCommand cmd = new SqlCommand(procedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); // running the SP
                // _logger.LogError(procedure.ProcedureName);

                    while (dr.Read())
                    {
                        _logger.LogError(dr.GetString(5));

                        theList.Add(new Cart
                        {
                            Id = dr.GetInt32(0),
                            AllProductsAmount = dr.GetInt32(1),
                            FinalPrice = dr.GetInt32(2),
                            ProductAmount = dr.GetInt32(3),
                            ProductId = dr.GetInt32(4),
                            NameProduct = dr.GetString(5),
                            PictureURL = dr.GetString(6),
                            Price = dr.GetInt32(7),
                            SalePrice = dr.GetValue(8) as int?
                        });
                    }
                    con.Close();
        _logger.LogError("after read");
                }
                return theList;
            }
        }

        // ---------- MiiProducts ----------
        List<MiiProduct> getMiiProductsCategoryWithSale(string category)
        {
            List<MiiProduct> theList = new List<MiiProduct>();
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;"))
            {
                using (SqlCommand cmd = new SqlCommand("spMacIpadIphoneProductsWithSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category", category);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); // running the SP
                    while (dr.Read())
                    {
                        theList.Add(new MiiProduct
                        {
                            Id = dr.GetInt32(0),
                            NameProduct = dr.GetString(1),
                            Category = dr.GetString(2),
                            Price = dr.GetInt32(3),
                            Details = dr.GetString(4),
                            PictureUrl = dr.GetString(5),
                            NewFlag = dr.GetBoolean(6),
                            Color = dr.GetString(7),
                            Memory = dr.GetString(8),
                            ScreenSize = dr.GetString(9),
                            SalePrice = dr.GetValue(10) as int?
                        });
                    }
                    con.Close();
                }
                return theList;
            }
        }

    }
}
