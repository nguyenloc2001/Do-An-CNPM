using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_An_CNPM.Models.Interface
{
    internal interface IModelChucVu
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên chức vụ")]
        [Required(ErrorMessage = "Tên chức vụ không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenChucVu { get; set; }

        [Display(Name = "Mã chức vụ")]
        [Required(ErrorMessage = "Mã chức vụ không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        /*[CheckChucVuNotExists]*/
        string MaChucVu { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; }

        string KeyWord { get; set; }

    }
}
