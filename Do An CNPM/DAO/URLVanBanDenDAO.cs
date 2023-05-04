using Do_An_CNPM.Commons;
using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Do_An_CNPM.DAO
{
    public class URLVanBanDenDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        public void insert(string maVanBan, string FileName, string FileUrl)
        {
            StringBuilder sb = new StringBuilder();
            try
            { 
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    URLVANBANDEN fileVanBan = new URLVANBANDEN();
                    fileVanBan.MaVanBan = maVanBan;
                    fileVanBan.TenFile = FileName;
                    fileVanBan.urlFile = FileUrl;
                    dbContext.URLVANBANDENs.InsertOnSubmit(fileVanBan);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}