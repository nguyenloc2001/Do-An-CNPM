using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelLuuTru
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên lưu trữ")]
        [Required(ErrorMessage = "Tên lưu trữ không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenLuuTru { get; set; }

        [Display(Name = "Mã lưu trữ")]
        [Required(ErrorMessage = "Mã lưu trữ không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaLuuTru { get; set; }

        [Display(Name = "Thời gian lưu trữ")]
        [Required(ErrorMessage = "Thời gian lưu trữ không được phép để trống")]
        [Range(0,50, ErrorMessage = "Thời gian lưu trữ phải trong khoảng 0 - 50 năm")]
        int ThoiGianLuu { get; set; }

        [Display(Name = "Kiểu lưu")]
        string NoiLuu { get; set; }

        [Display(Name = "Tên kho")]
        [Required(ErrorMessage = "Tên kho không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenKho { get; set; }

        [Display(Name = "Mã kho")]
        [Required(ErrorMessage = "Mã kho không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaKho { get; set; }

        [Display(Name = "Tên kệ")]
        [Required(ErrorMessage = "Tên kệ không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenKe { get; set; }

        [Display(Name = "Mã kệ")]
        [Required(ErrorMessage = "Mã kệ không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaKe { get; set; }

        [Display(Name = "Tên hộp")]
        [Required(ErrorMessage = "Tên hộp không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string TenHop { get; set; }

        [Display(Name = "Mã hộp")]
        [Required(ErrorMessage = "Mã hộp không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaHop { get; set; }

        string KeyWord { get; set; }

    }
}
