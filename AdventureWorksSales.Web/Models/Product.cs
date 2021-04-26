using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class Product
    {
        /// <summary>
        /// For single product row unique id
        /// </summary>
        public string rowguid { get; set; }
        /// <summary>
        /// For single product name
        /// </summary>
        public string  Name { get; set; }

        /// <summary>
        /// For single product list price
        /// </summary>
        public decimal ListPrice { get; set; }
    }
}