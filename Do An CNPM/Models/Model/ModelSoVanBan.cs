using Do_An_CNPM.Models.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Models.Model
{
    [MetadataType(typeof(IModelSoVanBan))]
    public class ModelSoVanBan : IModelSoVanBan
    {
        public int ID { get; set; }
        public string TenSoVanBan { get; set; }
        public string MaSoVanBan { get; set; }
        public DateTime NgayTaoSo { get; set; }
        public DateTime NgayDongSo { get; set; }
        public string KeyWord { get; set; }
    }
}