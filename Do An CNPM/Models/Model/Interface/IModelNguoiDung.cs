using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelNguoiDung
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Required(ErrorMessage = "Mã nhân viên không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaNhanVien { get; set; }

        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Tên nhân viên không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string HoVaTen { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime? NgaySinh { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string DiaChi { get; set; }

        [Display(Name = "Tên nhân viên")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string QueQuan { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Số điện thoại")]
        string SoDienThoai { get; set; }

        [Display(Name = "Ngày bắt đầu làm việc")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime? NgayBatDauLamViec { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MatKhau { get; set; }

        [Display(Name = "Chức vụ")]
        [Required(ErrorMessage = "Chức vụ không được phép để trống")]
        int ChucVuId { get; set; }

        [Display(Name = "Quyền")]
        [Required(ErrorMessage = "Quyền không được phép để trống")]
        int QuyenId { get; set; }

        [Display(Name = "Phòng ban")]
        [Required(ErrorMessage = "Phòng ban không được phép để trống")]
        int PhongBanId { get; set; }

        string KeyWord { get; set; }
    }
}
