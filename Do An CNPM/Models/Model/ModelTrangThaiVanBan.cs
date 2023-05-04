using Do_An_CNPM.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelTrangThaiVanBan))]
    public class ModelTrangThaiVanBan : IModelTrangThaiVanBan
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
        public string MaTrangThai { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
    }
}