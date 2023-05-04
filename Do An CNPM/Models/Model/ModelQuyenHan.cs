using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelQuyenHan))]
    public class ModelQuyenHan : IModelQuyenHan
    {
        public int ID { get; set; }
        public string TenQuyenHan { get; set; }
        public string MaQuyen { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}