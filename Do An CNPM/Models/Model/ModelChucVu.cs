using Do_An_CNPM.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelChucVu))]
    public class ModelChucVu : IModelChucVu
    {
        public int ID { get; set; }
        public string TenChucVu { get; set; }
        public string MaChucVu { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
    }
}