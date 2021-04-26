using AdventureWorksSales.Web.Config;
using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductsController : Controller
    {
        /// <summary>
        /// Action to get all products
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.product", connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dtProducts = new DataTable();

                    dtProducts.Load(sdr);

                    foreach(DataRow row in dtProducts.Rows)
                    {
                        products.Add(
                            new Product
                            {
                                Name = row["Name"].ToString(),
                                ListPrice = Convert.ToDecimal(row["ListPrice"])
                            }
                        ); ;

                    }
                }
            }
            return View(products);
        }
    }
}