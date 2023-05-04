using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class TrangThaiVanBanMapper
    {
        public ModelTrangThaiVanBan rowMapper (TRANGTHAIVANBAN data, ModelTrangThaiVanBan trangThai)
        {
            trangThai.ID = data.ID;
            trangThai.TenTrangThai = data.TenTrangThai;
            trangThai.MaTrangThai = data .MaTrangThai;
            trangThai.GhiChu = data.GhiChu;
            trangThai.KeyWord = data.KeyWord;
            return trangThai;
        }

        public TRANGTHAIVANBAN dbMapper(ModelTrangThaiVanBan data, TRANGTHAIVANBAN trangThai)
        {
            trangThai.ID = data.ID;
            trangThai.TenTrangThai = data.TenTrangThai;
            trangThai.MaTrangThai = data.MaTrangThai;
            trangThai.GhiChu = data.GhiChu;
            trangThai.KeyWord = data.KeyWord;
            return trangThai;
        }

        public List<ModelTrangThaiVanBan> listMapper (List<TRANGTHAIVANBAN> listData, List<ModelTrangThaiVanBan> listTrangThai)
        {
            foreach (var data in listData)
            {
                ModelTrangThaiVanBan trangThai = new ModelTrangThaiVanBan();
                trangThai = rowMapper(data, trangThai);
                listTrangThai.Add(trangThai);
            }
            return listTrangThai;
        }
    }
}