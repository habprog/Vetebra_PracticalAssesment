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
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        /// <summary>
        /// Action to list all product categories
        /// </summary>
        public ActionResult Index()
        {
            List<productCategory> productCategories = new List<productCategory>();
            using(SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ProductCategory", connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dtCategories = new DataTable();

                    dtCategories.Load(sdr);

                    foreach(DataRow row in dtCategories.Rows)
                    {
                        productCategories.Add(
                            new productCategory
                            {
                                  Name = row["Name"].ToString(),
                                  rowguid = row["rowguid"].ToString()
                            }
                        );
                    }
                }
            }
            return View(productCategories);
        }

        /// <summary>
        /// Action to open product category form
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Action to add single product category
        /// </summary>
        [HttpPost]
        public ActionResult store(productCategory category )
        {
            Guid rowguid = Guid.NewGuid();
            DateTime today = DateTime.Today;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using(SqlCommand cmd = new SqlCommand("INSERT INTO dbo.ProductCategory(Name, rowguid,ModifiedDate) " +
                    "VALUES('"+ category.Name + "', '"+ rowguid.ToString() +"', '"+ today.ToString()+"')", connection ))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Action to get single product category for edit using product catetory id
        /// </summary>
        [HttpGet]
        public ActionResult Edit(string id = null)
        {
            if (id == null || id == string.Empty)
                return HttpNotFound();
            var _category = new productCategory();
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ProductCategory WHERE rowguid='" + id + "'", connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlDataReader _sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();

                    if (_sdr.HasRows)
                    {
                        dt.Load(_sdr);
                        DataRow row = dt.Rows[0];
                        _category.Name = row["Name"].ToString();
                        _category.rowguid = row["rowguid"].ToString();

                        return View("Edit", _category);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
        }

        /// <summary>
        /// Action to update single product category
        /// </summary>
        public ActionResult update(productCategory category)
        {
            DateTime today = DateTime.Today;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.ProductCategory SET Name='"+ category.Name + "', ModifiedDate='"+ today.ToString() + "' WHERE rowguid='" + category.rowguid + "'", connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///Action to delete single product category using productCategory Id
        /// </summary>
        public ActionResult delete(string id = null)
        {
            if (id == null || id == string.Empty)
                return HttpNotFound();
            using (SqlConnection connection = new SqlConnection(GlobalConfig.CnnString()))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.ProductCategory WHERE rowguid='" + id + "'", connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}