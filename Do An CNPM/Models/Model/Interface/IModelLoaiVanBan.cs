using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelLoaiVanBan
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên loại văn bản")]
        [Required(ErrorMessage = "Tên loại văn bản không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenLoaiVanBan { get; set; }

        [Display(Name = "Mã loại văn bản")]
        [Required(ErrorMessage = "Mã loại văn bản không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaLoaiVanBan { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; }

        string KeyWord { get; set; }
    }
}
