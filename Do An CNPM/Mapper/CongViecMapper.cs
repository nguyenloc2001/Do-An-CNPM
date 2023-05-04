using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_CNPM.Mapper
{
    public class CongViecMapper
    {
        public ModelCongViec rowMapper(CONGVIEC data, ModelCongViec congViec)
        {
            congViec.ID = data.ID;
            congViec.TenCongViec = data.TenCongViec;
            congViec.MaCongViec = data.MaCongViec;
            congViec.NgayTao = data.NgayTao;
            congViec.NgayHoanThanhDuKien = data.NgayHoanThanhDuKien;
            congViec.NgayHoanThanhThucTe = data.NgayHoanThanhThucTe;
            congViec.NguoiDungId = data.NguoiDungId;
            congViec.PhongBanId = data.PhongBanId;
            congViec.GhiChu = data.GhiChu;
            congViec.KeyWord = data.KeyWord;
            return congViec;
        }

        public CONGVIEC dbMapper(ModelCongViec data, CONGVIEC congViec)
        {
            congViec.ID = data.ID;
            congViec.TenCongViec = data.TenCongViec;
            congViec.MaCongViec = data.MaCongViec;
            congViec.NgayTao = data.NgayTao;
            congViec.NgayHoanThanhDuKien = data.NgayHoanThanhDuKien;
            congViec.NgayHoanThanhThucTe = data.NgayHoanThanhThucTe;
            congViec.NguoiDungId = data.NguoiDungId;
            congViec.PhongBanId = data.PhongBanId;
            congViec.GhiChu = data.GhiChu;
            congViec.KeyWord = data.KeyWord;
            return congViec;
        }

        public List<ModelCongViec> listMapper(List<CONGVIEC> listData, List<ModelCongViec> listCongViec)
        {
            foreach (var data in listData)
            {
                ModelCongViec congViec = new ModelCongViec();
                congViec = rowMapper(data, congViec);
                listCongViec.Add(congViec);
            }
            return listCongViec;
        }
    }
}