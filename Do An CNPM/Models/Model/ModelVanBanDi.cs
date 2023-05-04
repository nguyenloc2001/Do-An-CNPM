using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelVanBanDi))]
    public class ModelVanBanDi : IModelVanBanDi
    {
        public int ID { get; set; }
        public string MaVanBan { get; set; }
        public string TrichYeu { get; set; }
        public DateTime NgaySoan { get; set; }
        public DateTime? NgayBanHanhVanBan { get; set; }
        public string NoiLuuVanBan { get; set; }
        public int SoTo { get; set; }
        public DateTime? NgayDuyetVanBan { get; set; }
        public string NguoiKyVanBan { get; set; }
        public string ChucVuNguoiKy { get; set; }
        public string DonViNhan { get; set; }
        public string NoiDungVanBan { get; set; }
        public string urlNoiDungVanBan { get; set; }
        public HttpPostedFileBase[] NDVBFiles { get; set; }
        public string VanBanLienQuanVanBan { get; set; }
        public string urlVanBanLienQuanVanBan { get; set; }
        public HttpPostedFileBase[] NDVBLQFiles { get; set; }
        public string GhiChu { get; set; }
        public int NguoiDungId { get; set; }
        public int CongViecId { get; set; }
        public int LoaiVanBanId { get; set; }
        public int LuuTruId { get; set; }
        public int TrangThaiVanBanId { get; set; }
        public int QuyenId { get; set; }
        public int SoVanBanId { get; set; }
        public string KeyWord { get; set; }
    }
}