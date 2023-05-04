using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;

namespace Do_An_CNPM.Mapper
{
    public class VanBanDenMapper
    {
        public ModelVanBanDen rowMapper(VANBANDEN data, ModelVanBanDen vanBanDen)
        {
            vanBanDen.ID = data.ID;
            vanBanDen.MaVanBan = data.MaVanBan;
            vanBanDen.TrichYeu = data.TrichYeu;
            vanBanDen.NgayNhan = data.NgayNhan;
            vanBanDen.NgayBanHanhVanBan = data.NgayBanHanhVanBan;
            vanBanDen.NoiLuuVanBan = data.NoiLuuVanBan;
            vanBanDen.SoTo = data.SoTo;
            vanBanDen.NgayDuyetVanBan = data.NgayDuyetVanBan;
            vanBanDen.NguoiKyVanBan = data.NguoiKyVanBan;
            vanBanDen.ChucVuNguoiKy = data.ChucVuNguoiKy;
            vanBanDen.DonViGui = data.DonViGui;
            vanBanDen.NoiDungVanBan = data.NoiDungVanBan;
            vanBanDen.urlNoiDungVanBan = data.urlNoiDungVanBan;
            vanBanDen.VanBanLienQuanVanBan = data.VanBanLienQuanVanBan;
            vanBanDen.urlVanBanLienQuanVanBan = data.urlVanBanLienQuanVanBan;
            vanBanDen.GhiChu = data.GhiChu;
            vanBanDen.NguoiDungId = data.NguoiDungId;
            vanBanDen.CongViecId = data.CongViecId;
            vanBanDen.LoaiVanBanId = data.LoaiVanBanId;
            vanBanDen.LuuTruId = data.LuuTruId;
            vanBanDen.TrangThaiVanBanId = data.TrangThaiVanBanId;
            vanBanDen.QuyenId = data.QuyenId;
            vanBanDen.SoVanBanId = data.SoVanBanId;
            return vanBanDen;
        }

        public VANBANDEN dbMapper(ModelVanBanDen data, VANBANDEN vanBanDen)
        {
            vanBanDen.ID = data.ID;
            vanBanDen.MaVanBan = data.MaVanBan;
            vanBanDen.TrichYeu = data.TrichYeu;
            vanBanDen.NgayNhan = data.NgayNhan;
            vanBanDen.NgayBanHanhVanBan = data.NgayBanHanhVanBan;
            vanBanDen.NoiLuuVanBan = data.NoiLuuVanBan;
            vanBanDen.SoTo = data.SoTo;
            vanBanDen.NgayDuyetVanBan = data.NgayDuyetVanBan;
            vanBanDen.NguoiKyVanBan = data.NguoiKyVanBan;
            vanBanDen.ChucVuNguoiKy = data.ChucVuNguoiKy;
            vanBanDen.DonViGui = data.DonViGui;
            vanBanDen.NoiDungVanBan = data.NoiDungVanBan;
            vanBanDen.urlNoiDungVanBan = data.urlNoiDungVanBan;
            vanBanDen.VanBanLienQuanVanBan = data.VanBanLienQuanVanBan;
            vanBanDen.urlVanBanLienQuanVanBan = data.urlVanBanLienQuanVanBan;
            vanBanDen.GhiChu = data.GhiChu;
            vanBanDen.NguoiDungId = data.NguoiDungId;
            vanBanDen.CongViecId = data.CongViecId;
            vanBanDen.LoaiVanBanId = data.LoaiVanBanId;
            vanBanDen.LuuTruId = data.LuuTruId;
            vanBanDen.TrangThaiVanBanId = data.TrangThaiVanBanId;
            vanBanDen.QuyenId = data.QuyenId;
            vanBanDen.SoVanBanId = data.SoVanBanId;
            return vanBanDen;
        }
        public VANBANDEN dbMapperNotID(ModelVanBanDen data, VANBANDEN vanBanDen)
        {
            vanBanDen.MaVanBan = data.MaVanBan;
            vanBanDen.TrichYeu = data.TrichYeu;
            vanBanDen.NgayNhan = data.NgayNhan;
            vanBanDen.NgayBanHanhVanBan = data.NgayBanHanhVanBan;
            vanBanDen.NoiLuuVanBan = data.NoiLuuVanBan;
            vanBanDen.SoTo = data.SoTo;
            vanBanDen.NgayDuyetVanBan = data.NgayDuyetVanBan;
            vanBanDen.NguoiKyVanBan = data.NguoiKyVanBan;
            vanBanDen.ChucVuNguoiKy = data.ChucVuNguoiKy;
            vanBanDen.DonViGui = data.DonViGui;
            vanBanDen.NoiDungVanBan = data.NoiDungVanBan;
            vanBanDen.urlNoiDungVanBan = data.urlNoiDungVanBan;
            vanBanDen.VanBanLienQuanVanBan = data.VanBanLienQuanVanBan;
            vanBanDen.urlVanBanLienQuanVanBan = data.urlVanBanLienQuanVanBan;
            vanBanDen.GhiChu = data.GhiChu;
            vanBanDen.NguoiDungId = data.NguoiDungId;
            vanBanDen.CongViecId = data.CongViecId;
            vanBanDen.LoaiVanBanId = data.LoaiVanBanId;
            vanBanDen.LuuTruId = data.LuuTruId;
            vanBanDen.TrangThaiVanBanId = data.TrangThaiVanBanId;
            vanBanDen.QuyenId = data.QuyenId;
            vanBanDen.SoVanBanId = data.SoVanBanId;
            return vanBanDen;
        }

        public List<ModelVanBanDen> listMapper(List<VANBANDEN> listData, List<ModelVanBanDen> listVanBanDen)
        {
            foreach (var data in listData)
            {
                ModelVanBanDen vanBanDen = new ModelVanBanDen();
                vanBanDen = rowMapper(data, vanBanDen);
                listVanBanDen.Add(vanBanDen);
            }
            return listVanBanDen;
        }
    }
}