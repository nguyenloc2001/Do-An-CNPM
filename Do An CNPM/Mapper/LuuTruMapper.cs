using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class LuuTruMapper
    {
        public ModelLuuTru rowMapper(LUUTRU data, ModelLuuTru luuTru)
        {
            luuTru.ID = data.ID;
            luuTru.TenLuuTru = data.TenLuuTru;
            luuTru.MaLuuTru = data.MaLuuTru;
            luuTru.ThoiGianLuu = data.ThoiGianLuu;
            luuTru.NoiLuu = data.NoiLuu;
            luuTru.TenKho = data.TenKho;
            luuTru.MaKho = data.MaKho;
            luuTru.TenKe = data.TenKe;
            luuTru.MaKe = data.MaKe;
            luuTru.TenHop = data.TenHop;
            luuTru.MaHop = data.MaHop;
            luuTru.KeyWord = data.KeyWord;
            return luuTru;
        }

        public LUUTRU dbMapper(ModelLuuTru data, LUUTRU luuTru)
        {
            luuTru.ID = data.ID;
            luuTru.TenLuuTru = data.TenLuuTru;
            luuTru.MaLuuTru = data.MaLuuTru;
            luuTru.ThoiGianLuu = data.ThoiGianLuu;
            luuTru.NoiLuu = data.NoiLuu;
            luuTru.TenKho = data.TenKho;
            luuTru.MaKho = data.MaKho;
            luuTru.TenKe = data.TenKe;
            luuTru.MaKe = data.MaKe;
            luuTru.TenHop = data.TenHop;
            luuTru.MaHop = data.MaHop;
            luuTru.KeyWord = data.KeyWord;
            return luuTru;
        }

        public List<ModelLuuTru> listMapper(List<LUUTRU> listData, List<ModelLuuTru> listLuuTru)
        {
            foreach (var data in listData)
            {
                ModelLuuTru luuTru = new ModelLuuTru();
                luuTru = rowMapper(data, luuTru);
                listLuuTru.Add(luuTru);
            }
            return listLuuTru;
        }
    }
}