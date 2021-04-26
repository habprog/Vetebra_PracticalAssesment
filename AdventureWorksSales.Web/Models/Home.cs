using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class Home
    {
        /// <summary>
        /// For total order Sales count value
        /// </summary>
        public int TotalSales { get; set; }

        /// <summary>
        /// For Highest line total from order Sales
        /// </summary>
        public decimal HighestLineTotal { get; set; }

        /// <summary>
        /// For Total sales of single front brakes product
        /// </summary>
        public int FrontBrakesSalesTotal { get; set; }
    }
}