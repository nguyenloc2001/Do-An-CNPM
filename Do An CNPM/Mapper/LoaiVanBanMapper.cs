using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class LoaiVanBanMapper
    {
        public ModelLoaiVanBan rowMapper(LOAIVANBAN data, ModelLoaiVanBan loaiVanBan)
        {
            loaiVanBan.ID = data.ID;
            loaiVanBan.TenLoaiVanBan = data.TenLoaiVanBan;
            loaiVanBan.MaLoaiVanBan = data.MaLoaiVanBan;
            loaiVanBan.GhiChu = data.GhiChu;
            loaiVanBan.KeyWord = data.KeyWord;
            return loaiVanBan;
        }

        public LOAIVANBAN dbMapper(ModelLoaiVanBan data, LOAIVANBAN loaiVanBan)
        {
            loaiVanBan.ID = data.ID;
            loaiVanBan.TenLoaiVanBan = data.TenLoaiVanBan;
            loaiVanBan.MaLoaiVanBan = data.MaLoaiVanBan;
            loaiVanBan.GhiChu = data.GhiChu;
            loaiVanBan.KeyWord = data.KeyWord;
            return loaiVanBan;
        }

        public List<ModelLoaiVanBan> listMapper(List<LOAIVANBAN> listData, List<ModelLoaiVanBan> listTrangThai)
        {
            foreach (var data in listData)
            {
                ModelLoaiVanBan trangThai = new ModelLoaiVanBan();
                trangThai = rowMapper(data,trangThai);
                listTrangThai.Add(trangThai);
            }
            return listTrangThai;
        }
    }
}