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
    public class AllProductsController : ControllerBase
    {
        private readonly AppleDBContext _context;
        private readonly ILogger<AllProductsController> _logger;
        // private readonly Environments _environments;

        public AllProductsController(AppleDBContext context, ILogger<AllProductsController> logger)
        {
            _context = context;
            _logger = logger;
            // _environments = new Environments();
        }

        // GET: api/AllProducts/Category/{id}
        [HttpGet("Category/{id}")]
        public async Task<ActionResult<IEnumerable<AProduct>>> Category(string id)
        {
            if(id == "Mac" || id == "Ipad" || id == "Iphone"){
                return getMiiProductsCategoryWithSale(id);
            }
            else if(id == "Watch" || id == "Airpods") {
                return getWaProductsCategoryWithSale(id);
            }
            return getAProductsCategoryWithSale(id);
        }

        // ---------- AProducts ----------
        List<AProduct> getAProductsCategoryWithSale(string category)
        {
            List<AProduct> theList = new List<AProduct>();
            // using (SqlConnection con = new SqlConnection(_environments.Context))
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;"))
            {
                using (SqlCommand cmd = new SqlCommand("spAccessoriesWithSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category", category);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); // running the SP
                    while (dr.Read())
                    {
                        theList.Add(new AProduct
                        {
                            Id = dr.GetInt32(0),
                            NameProduct = dr.GetString(1),
                            Category = dr.GetString(2),
                            Price = dr.GetInt32(3),
                            Details = dr.GetString(4),
                            PictureUrl = dr.GetString(5),
                            NewFlag = dr.GetBoolean(6),
                            SalePrice = dr.GetValue(7) as int?
                        });
                    }
                    con.Close();
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

        // ---------- WaProducts ----------
        List<WaProduct> getWaProductsCategoryWithSale(string category)
        {
            List<WaProduct> theList = new List<WaProduct>();
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;"))
            {
                using (SqlCommand cmd = new SqlCommand("spWatchAirpodsProductsWithSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category", category);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); // running the SP
                    while (dr.Read())
                    {
                        theList.Add(new WaProduct
                        {
                            Id = dr.GetInt32(0),
                            NameProduct = dr.GetString(1),
                            Category = dr.GetString(2),
                            Price = dr.GetInt32(3),
                            Details = dr.GetString(4),
                            PictureUrl = dr.GetString(5),
                            NewFlag = dr.GetBoolean(6),
                            Color = dr.GetString(7),
                            SalePrice = dr.GetValue(8) as int?
                        });
                    }
                    con.Close();
                }
                return theList;
            }
        }
    }
}
