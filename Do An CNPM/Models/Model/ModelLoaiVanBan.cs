using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelLoaiVanBan))]
    public class ModelLoaiVanBan : IModelLoaiVanBan
    {
        public int ID { get; set; }
        public string TenLoaiVanBan { get; set; }
        public string MaLoaiVanBan { get; set; }
        public string GhiChu { get; set; }
        public string KeyWord { get; set; }
        [NotMapped]
        public List<ModelLoaiVanBan> LoaiVanBanList { get; set; }
    }
}