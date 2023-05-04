using Do_An_CNPM.Models.Interface;
using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelLuuTru))]
    public class ModelLuuTru : IModelLuuTru
    {
        public int ID { get; set; }
        public string TenLuuTru { get; set; }
        public string MaLuuTru { get; set; }
        public int ThoiGianLuu { get; set; }
        public string NoiLuu { get; set; }
        public string TenKho { get; set; }
        public string MaKho { get; set; }
        public string TenKe { get; set; }
        public string MaKe { get; set; }
        public string TenHop { get; set; }
        public string MaHop { get; set; }
        public string KeyWord { get; set; }
    }
}