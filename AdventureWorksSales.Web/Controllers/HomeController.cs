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
    public class HomeController : Controller
    {
        Home HomeModel = new Home();
        /// <summary>
        /// Action to load order sales agregate value
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            salesTotal();
            highestLineTotal();
            breakSalesTotal();
            return View(HomeModel);
        }

        /// <summary>
        /// Method that get all sales total for order sales
        /// </summary>
        private void salesTotal()
        {
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS nCount FROM dbo.SalesOrder", connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    DataRow row = dt.Rows[0];
                    HomeModel.TotalSales = Convert.ToInt32(row["nCount"]);

                }
            }
        }

        /// <summary>
        /// Method that get highest line total value
        /// </summary>
        private void highestLineTotal()
        {
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  MAX(LineTotal) AS lineTotal FROM dbo.SalesOrder", connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    DataRow row = dt.Rows[0];
                    HomeModel.HighestLineTotal = Convert.ToDecimal(row["lineTotal"]);

                }
            }
        }

        /// <summary>
        /// Method that get Front Brakes total sale value
        /// </summary>
        private void breakSalesTotal()
        {
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  COUNT(*) AS fBrake FROM dbo.SalesOrder WHERE ProductID=948", connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    DataRow row = dt.Rows[0];
                    HomeModel.FrontBrakesSalesTotal = Convert.ToInt32(row["fBrake"]);

                }
            }
        }
    }
}