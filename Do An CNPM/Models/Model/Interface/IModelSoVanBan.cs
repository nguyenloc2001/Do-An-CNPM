using Do_An_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.Models.Model.Interface
{
    internal interface IModelSoVanBan
    {
        [Key]
        int ID { get; set; }

        [Display(Name = "Tên sổ văn bản")]
        [Required(ErrorMessage = "Tên sổ văn bản không được phép để trống")]
        [StringLength(255, ErrorMessage = "Số ký tự phải nhỏ hơn 255")]
        string TenSoVanBan { get; set; }

        [Display(Name = "Mã sổ văn bản")]
        [Required(ErrorMessage = "Mã sổ văn bản không được phép để trống")]
        [StringLength(20, ErrorMessage = "Số ký tự phải nhỏ hơn 20")]
        string MaSoVanBan { get; set; }

        [Display(Name = "Ngày tạo sổ")]
        [Required(ErrorMessage = "Ngày tạo sổ không được phép để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayTaoSo { get; set; }

        [Display(Name = "Ngày đóng sổ")]
        [Required(ErrorMessage = "Ngày đóng sổ không được phép để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime NgayDongSo { get; set; }

        string KeyWord { get; set; }
    }
}
