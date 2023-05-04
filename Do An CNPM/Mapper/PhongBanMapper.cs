using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class PhongBanMapper
    {
        public ModelPhongBan rowMapper(PHONGBAN data, ModelPhongBan phongBan)
        {
            phongBan.ID = data.ID;
            phongBan.TenPhongBan = data.TenPhongBan;
            phongBan.MaPhongBan = data.MaPhongBan;
            phongBan.SoNhanVien = data.SoNhanVien;
            phongBan.GhiChu = data.GhiChu;
            phongBan.KeyWord = data.KeyWord;
            return phongBan;
        }

        public PHONGBAN dbMapper(ModelPhongBan data, PHONGBAN phongBan)
        {
            phongBan.ID = data.ID;
            phongBan.TenPhongBan = data.TenPhongBan;
            phongBan.MaPhongBan = data.MaPhongBan;
            phongBan.SoNhanVien = data.SoNhanVien;
            phongBan.GhiChu = data.GhiChu;
            phongBan.KeyWord = data.KeyWord;
            return phongBan;
        }

        public List<ModelPhongBan> listMapper(List<PHONGBAN> listData, List<ModelPhongBan> listPhongBan)
        {
            foreach (var data in listData)
            {
                ModelPhongBan phongBan = new ModelPhongBan();
                phongBan = rowMapper(data, phongBan);
                listPhongBan.Add(phongBan);
            }
            return listPhongBan;
        }
    }
}