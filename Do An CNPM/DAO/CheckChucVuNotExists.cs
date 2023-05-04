using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Do_An_CNPM.DAO
{
    public class CheckChucVuNotExists : ValidationAttribute
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as CHUCVU;
            if (owner == null) return new ValidationResult("Chức vụ trống");
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                
                var data = from temp in dbContext.CHUCVUs select temp.MaChucVu;

                if (data == null ) 
                { 
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Mã chức vụ đã tồn tại");
                }
            }            
        }*/
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                var data = from temp in dbContext.CHUCVUs select temp.MaChucVu;

                foreach (var item in data)
                {
                    if (item != null)
                    {
                        return new ValidationResult("Mã chức vụ đã tồn tại");
                    }
                }        
                return ValidationResult.Success;
            }
        }
    }
}