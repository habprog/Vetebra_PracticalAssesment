using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class productCategory
    {
        /// <summary>
        /// For single row unique id
        /// </summary>
        public string rowguid { get; set; }
        
        /// <summary>
        /// For single Product category Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}