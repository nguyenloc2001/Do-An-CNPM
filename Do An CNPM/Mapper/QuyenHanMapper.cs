using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class QuyenHanMapper
    {
        public ModelQuyenHan rowMapper(QUYENHAN data, ModelQuyenHan quyen)
        {
            quyen.ID = data.ID;
            quyen.TenQuyenHan = data.TenQuyenHan;
            quyen.MaQuyen = data.MaQuyen;
            quyen.GhiChu = data.GhiChu;
            quyen.NgayBatDau = data.NgayBatDau;
            quyen.NgayKetThuc = data.NgayKetThuc;
            quyen.KeyWord = data.KeyWord;
            return quyen;
        }

        public QUYENHAN dbMapper(ModelQuyenHan data, QUYENHAN quyen)
        {
            quyen.ID = data.ID;
            quyen.TenQuyenHan = data.TenQuyenHan;
            quyen.MaQuyen = data.MaQuyen;
            quyen.GhiChu = data.GhiChu;
            quyen.NgayBatDau = data.NgayBatDau;
            quyen.NgayKetThuc = data.NgayKetThuc;
            quyen.KeyWord = data.KeyWord;
            return quyen;
        }

        public List<ModelQuyenHan> listMapper(List<QUYENHAN> listData, List<ModelQuyenHan> listQuyen)
        {
            foreach (var data in listData)
            {
                ModelQuyenHan quyen = new ModelQuyenHan();
                quyen = rowMapper(data, quyen);
                listQuyen.Add(quyen);
            }
            return listQuyen;
        }
    }
}