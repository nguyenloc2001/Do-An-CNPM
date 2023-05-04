using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class NguoiDungMapper
    {
        public ModelNguoiDung rowMapper(NGUOIDUNG data, ModelNguoiDung nguoiDung)
        {
            nguoiDung.ID = data.ID;
            nguoiDung.MaNhanVien = data.MaNhanVien;
            nguoiDung.HoVaTen = data.HoVaTen;
            nguoiDung.DiaChi = data.DiaChi;
            nguoiDung.QueQuan = data.QueQuan;
            nguoiDung.Email = data.Email;
            nguoiDung.SoDienThoai = data.SoDienThoai;
            nguoiDung.NgayBatDauLamViec = data.NgayBatDauLamViec;
            nguoiDung.MatKhau = data.MatKhau;
            nguoiDung.ChucVuId = data.ChucVuId;
            nguoiDung.QuyenId = data.QuyenId;
            nguoiDung.PhongBanId = data.PhongBanId;
            nguoiDung.KeyWord = data.KeyWord;
            return nguoiDung;
        }

        public NGUOIDUNG dbMapper(ModelNguoiDung data, NGUOIDUNG nguoiDung)
        {
            nguoiDung.ID = data.ID;
            nguoiDung.MaNhanVien = data.MaNhanVien;
            nguoiDung.HoVaTen = data.HoVaTen;
            nguoiDung.DiaChi = data.DiaChi;
            nguoiDung.QueQuan = data.QueQuan;
            nguoiDung.Email = data.Email;
            nguoiDung.SoDienThoai = data.SoDienThoai;
            nguoiDung.NgayBatDauLamViec = data.NgayBatDauLamViec;
            nguoiDung.MatKhau = data.MatKhau;
            nguoiDung.ChucVuId = data.ChucVuId;
            nguoiDung.QuyenId = data.QuyenId;
            nguoiDung.PhongBanId = data.PhongBanId;
            nguoiDung.KeyWord = data.KeyWord;
            return nguoiDung;
        }

        public List<ModelNguoiDung> listMapper(List<NGUOIDUNG> listData, List<ModelNguoiDung> listNguoiDung)
        {
            foreach (var data in listData)
            {
                ModelNguoiDung nguoiDung = new ModelNguoiDung();
                nguoiDung = rowMapper(data, nguoiDung);
                listNguoiDung.Add(nguoiDung);
            }
            return listNguoiDung;
        }
    }
}