using Do_An_CNPM.Models.Interface;
using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelNguoiDung))]
    public class ModelNguoiDung : IModelNguoiDung
    {
        public int ID { get; set; }
        public string MaNhanVien { get; set; }
        public string HoVaTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgayBatDauLamViec { get; set; }
        public string MatKhau { get; set; }
        public int ChucVuId { get; set; }
        public int QuyenId { get; set; }
        public int PhongBanId { get; set; }
        public string KeyWord { get; set; }
    }
}