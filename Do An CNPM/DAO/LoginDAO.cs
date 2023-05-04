using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.DAO
{
    public class LoginDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        NguoiDungMapper mapper = new NguoiDungMapper();

        public ModelNguoiDung findData(string MaNhanVien, string MatKhau)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                ModelNguoiDung model = new ModelNguoiDung();
                var obj = (from temp in dbContext.NGUOIDUNGs where (temp.MaNhanVien.Contains(MaNhanVien) && temp.MatKhau.Contains(MatKhau)) select temp).ToList();
                model.ID = obj.FirstOrDefault().ID;
                model.MaNhanVien = obj.FirstOrDefault().MaNhanVien.ToString();
                model.MatKhau = obj.FirstOrDefault().MatKhau.ToString();
                model.HoVaTen = obj.FirstOrDefault().HoVaTen.ToString();
                model.QuyenId = obj.FirstOrDefault().QuyenId;
                return model;
            }
        }
    }
}