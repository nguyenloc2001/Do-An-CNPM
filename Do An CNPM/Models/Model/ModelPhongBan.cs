using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelPhongBan))]
    public class ModelPhongBan : IModelPhongBan
    {
        public int ID { get; set; }
        public string TenPhongBan { get; set; }
        public string MaPhongBan { get; set; }
        public int SoNhanVien { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
    }
}