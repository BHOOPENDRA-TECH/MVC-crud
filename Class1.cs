using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudMVC.Models
{
    public class Class1
    {
        public int MobileID { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Name")]
        [Display(Name = "Enter Mobile Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mobile Name must be between 3 and 50 characters!")]
        public string MobileName { get; set; }
        [Required(ErrorMessage = "Please Enter MobileIMEno")]
        [Display(Name = "Enter MobileIMEno")]
        [MaxLength(100, ErrorMessage = "Exceeding Limit")]
        public string MobileIMEno { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Price")]
        [Display(Name = "Enter Mobile Price")]
        [DataType(DataType.Currency)]
        public string mobileprice { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Manufacured")]
        [Display(Name = "Enter Mobile Manufacured")]
        [DataType(DataType.Text)]
        public string mobileManufacured { get; set; }
        public DataSet StoreAllData { get; set; }
    }
  
}
