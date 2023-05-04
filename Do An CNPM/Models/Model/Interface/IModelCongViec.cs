using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelCongViec
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên công việc")]
        [Required(ErrorMessage = "Tên công việc không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string TenCongViec { get; set; }

        [Display(Name = "Mã công việc")]
        [Required(ErrorMessage = "Mã công việc không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string MaCongViec { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayTao { get; set; }

        [Display(Name = "Ngày hoàn thành dự kiến")]
        [Required(ErrorMessage = "Ngày hoàn thành dự kiến không được phép để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayHoanThanhDuKien { get; set; }

        [Display(Name = "Ngày hoàn thành thực tế")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime? NgayHoanThanhThucTe { get; set; }

        [Display(Name = "Nhân viên")]
        [Required(ErrorMessage = "Nhân viên không được phép để trống")]
        int NguoiDungId { get; set; }

        [Display(Name = "Phòng ban")]
        [Required(ErrorMessage = "Phòng ban không được phép để trống")]
        int PhongBanId { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; }

        string KeyWord { get; set; }

    }
}
