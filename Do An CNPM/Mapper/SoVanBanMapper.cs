using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class SoVanBanMapper
    {
        public ModelSoVanBan rowMapper(SOVANBAN data, ModelSoVanBan soVanBan)
        {
            soVanBan.ID = data.ID;
            soVanBan.TenSoVanBan = data.TenSoVanBan;
            soVanBan.MaSoVanBan = data.MaSoVanBan;
            soVanBan.NgayTaoSo = data.NgayTaoSo;
            soVanBan.NgayDongSo = data.NgayDongSo;
            soVanBan.KeyWord = data.KeyWord;
            return soVanBan;
        }

        public SOVANBAN dbMapper(ModelSoVanBan data, SOVANBAN soVanBan)
        {
            soVanBan.ID = data.ID;
            soVanBan.TenSoVanBan = data.TenSoVanBan;
            soVanBan.MaSoVanBan = data.MaSoVanBan;
            soVanBan.NgayTaoSo = data.NgayTaoSo;
            soVanBan.NgayDongSo = data.NgayDongSo;
            soVanBan.KeyWord = data.KeyWord;
            return soVanBan;
        }

        public List<ModelSoVanBan> listMapper(List<SOVANBAN> listData, List<ModelSoVanBan> listSoVanBan)
        {
            foreach (var data in listData)
            {
                ModelSoVanBan soVanBan = new ModelSoVanBan();
                soVanBan = rowMapper(data, soVanBan);
                listSoVanBan.Add(soVanBan);
            }
            return listSoVanBan;
        }
    }
}