using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelVanBanDen
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Mã văn bản")]
        [Required(ErrorMessage = "Mã văn bản không được phép để trống")]
        [StringLength(50, ErrorMessage = "Số ký tự phải nhỏ hơn 50")]
        string MaVanBan { get; set; }

        [Display(Name = "Trích yếu")]
        [Required(ErrorMessage = "Trích yếu không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string TrichYeu { get; set; }

        [Display(Name = "Ngày nhận")]
        [Required(ErrorMessage = "Ngày nhận không được phép để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayNhan { get; set; }

        [Display(Name = "Ngày ban hành văn bản")]
        [Required(ErrorMessage = "Ngày ban hành văn bản không được phép để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayBanHanhVanBan { get; set ; }

        [Display(Name = "Nơi lưu văn bản")]
        string NoiLuuVanBan { get; set; }

        [Display(Name = "Số tờ")]
        [Required(ErrorMessage = "Số tờ không được phép để trống")]
        [Range(1,10000, ErrorMessage = "Số tờ phải trong khoảng 1 - 10000")]
        int SoTo { get; set; }

        [Display(Name = "Ngày duyệt văn bản")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime? NgayDuyetVanBan { get; set; }

        [Display(Name = "Người ký văn bản")]
        [Required(ErrorMessage = "Người ký văn bản không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string NguoiKyVanBan { get; set; }

        [Display(Name = "Chức vụ người ký")]
        [Required(ErrorMessage = "Chức vụ người ký không được phép để trống")]
        [StringLength(100, ErrorMessage = "Số ký tự phải nhỏ hơn 100")]
        string ChucVuNguoiKy { get; set; }

        [Display(Name = "Đơn vị gửi")]
        [Required(ErrorMessage = "Đơn vị gửi không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string DonViGui { get; set; }

        [Display(Name = "Nội dung văn bản")]
        string NoiDungVanBan { get; set; }

        string urlNoiDungVanBan { get; set; }

        [Display(Name = "Nội dung văn bản")]
        [Required(ErrorMessage = "Nội dung văn bản không được phép để trống")]
        [NotMapped]
        HttpPostedFileBase[] NDVBFiles { get; set; }

        [Display(Name = "Nội dung văn bản liên quan")]
        string VanBanLienQuanVanBan { get ; set; }
        
        string urlVanBanLienQuanVanBan { get; set; }

        [NotMapped]
        HttpPostedFileBase[] NDVBLQFiles { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string GhiChu { get; set; }

        [Display(Name = "Nhân viên")]
        [Required(ErrorMessage = "Nhân viên không được phép để trống")]
        int NguoiDungId { get; set; }

        [Display(Name = "Công việc")]
        [Required(ErrorMessage = "Công việc không được phép để trống")]
        int CongViecId { get; set; }

        [Display(Name = "Loại văn bản")]
        [Required(ErrorMessage = "Loại văn bản không được phép để trống")]
        int LoaiVanBanId { get; set; }

        [Display(Name = "Lưu trữ")]
        [Required(ErrorMessage = "lưu trữ không được phép để trống")]
        int LuuTruId { get; set; }

        [Display(Name = "Trạng thái văn bản")]
        int TrangThaiVanBanId { get; set; }

        [Display(Name = "Quyền")]
        int QuyenId { get; set; }

        [Display(Name = "Sổ văn bản")]
        [Required(ErrorMessage = "Sổ văn bản không được phép để trống")]
        int SoVanBanId { get; set; }

        string KeyWord { get; set; }

    }
}
