using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class VanBanDiMapper
    {
        public ModelVanBanDi rowMapper(VANBANDI data, ModelVanBanDi vanBanDi)
        {
            vanBanDi.ID = data.ID;
            vanBanDi.MaVanBan = data.MaVanBan;
            vanBanDi.TrichYeu = data.TrichYeu;
            vanBanDi.NgaySoan = data.NgaySoan;
            vanBanDi.NgayBanHanhVanBan = data.NgayBanHanhVanBan;
            vanBanDi.NoiLuuVanBan = data.NoiLuuVanBan;
            vanBanDi.SoTo = data.SoTo;
            vanBanDi.NgayDuyetVanBan = data.NgayDuyetVanBan;
            vanBanDi.NguoiKyVanBan = data.NguoiKyVanBan;
            vanBanDi.ChucVuNguoiKy = data.ChucVuNguoiKy;
            vanBanDi.DonViNhan = data.DonViNhan;
            vanBanDi.NoiDungVanBan = data.NoiDungVanBan;
            vanBanDi.urlNoiDungVanBan = data.urlNoiDungVanBan;
            vanBanDi.VanBanLienQuanVanBan = data.VanBanLienQuanVanBan;
            vanBanDi.urlVanBanLienQuanVanBan = data.urlVanBanLienQuanVanBan;
            vanBanDi.GhiChu = data.GhiChu;
            vanBanDi.NguoiDungId = data.NguoiDungId;
            vanBanDi.CongViecId = data.CongViecId;
            vanBanDi.LoaiVanBanId = data.LoaiVanBanId;
            vanBanDi.LuuTruId = data.LuuTruId;
            vanBanDi.TrangThaiVanBanId = data.TrangThaiVanBanId;
            vanBanDi.QuyenId = data.QuyenId;
            vanBanDi.SoVanBanId = data.SoVanBanId;
            return vanBanDi;
        }

        public VANBANDI dbMapper(ModelVanBanDi data, VANBANDI vanBanDi)
        {
            vanBanDi.ID = data.ID;
            vanBanDi.MaVanBan = data.MaVanBan;
            vanBanDi.TrichYeu = data.TrichYeu;
            vanBanDi.NgaySoan = data.NgaySoan;
            vanBanDi.NgayBanHanhVanBan = data.NgayBanHanhVanBan;
            vanBanDi.NoiLuuVanBan = data.NoiLuuVanBan;
            vanBanDi.SoTo = data.SoTo;
            vanBanDi.NgayDuyetVanBan = data.NgayDuyetVanBan;
            vanBanDi.NguoiKyVanBan = data.NguoiKyVanBan;
            vanBanDi.ChucVuNguoiKy = data.ChucVuNguoiKy;
            vanBanDi.DonViNhan = data.DonViNhan;
            vanBanDi.NoiDungVanBan = data.NoiDungVanBan;
            vanBanDi.urlNoiDungVanBan = data.urlNoiDungVanBan;
            vanBanDi.VanBanLienQuanVanBan = data.VanBanLienQuanVanBan;
            vanBanDi.urlVanBanLienQuanVanBan = data.urlVanBanLienQuanVanBan;
            vanBanDi.GhiChu = data.GhiChu;
            vanBanDi.NguoiDungId = data.NguoiDungId;
            vanBanDi.CongViecId = data.CongViecId;
            vanBanDi.LoaiVanBanId = data.LoaiVanBanId;
            vanBanDi.LuuTruId = data.LuuTruId;
            vanBanDi.TrangThaiVanBanId = data.TrangThaiVanBanId;
            vanBanDi.QuyenId = data.QuyenId;
            vanBanDi.SoVanBanId = data.SoVanBanId;
            return vanBanDi;
        }

        public List<ModelVanBanDi> listMapper(List<VANBANDI> listData, List<ModelVanBanDi> listVanBanDi)
        {
            foreach (var data in listData)
            {
                ModelVanBanDi vanBanDi = new ModelVanBanDi();
                vanBanDi = rowMapper(data, vanBanDi);
                listVanBanDi.Add(vanBanDi);
            }
            return listVanBanDi;
        }
    }
}