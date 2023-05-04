using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelPhongBan
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên phòng ban")]
        [Required(ErrorMessage = "Tên phòng ban không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenPhongBan { get; set; }

        [Display(Name = "Mã phòng ban")]
        [Required(ErrorMessage = "Mã phòng ban không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaPhongBan { get; set; }

        [Display(Name = "Số nhân viên")]
        [Range(0,100, ErrorMessage = "Số nhân viên phải trong khoảng 0 -100")]
        int SoNhanVien { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; }

        string KeyWord { get; set; }
    }
}
