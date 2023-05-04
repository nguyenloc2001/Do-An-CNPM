using Do_An_CNPM.Models.Interface;
using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelCongViec))]
    public class ModelCongViec : IModelCongViec
    {
        public int ID { get; set; }
        public string TenCongViec { get; set; }
        public string MaCongViec { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHoanThanhDuKien { get; set; }
        public DateTime? NgayHoanThanhThucTe { get; set; }
        public int NguoiDungId { get; set; }
        public int PhongBanId { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
    }
}