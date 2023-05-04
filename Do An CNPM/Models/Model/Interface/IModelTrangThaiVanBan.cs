using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.Models.Interface
{
    internal interface IModelTrangThaiVanBan
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên trạng thái")]
        [Required(ErrorMessage = "Tên trạng thái không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenTrangThai { get; set; }

        [Display(Name = "Mã trạng thái")]
        [Required(ErrorMessage ="Mã trạng thái không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaTrangThai { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; } 

        string KeyWord { get; set; }

    }
}
