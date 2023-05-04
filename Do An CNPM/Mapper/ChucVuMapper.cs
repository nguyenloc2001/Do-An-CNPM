using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System.Collections.Generic;

namespace Do_An_CNPM.Mapper
{
    public class ChucVuMapper
    {
        public ModelChucVu rowMapper(CHUCVU data, ModelChucVu ChucVu)
        {
            ChucVu.ID = data.ID;
            ChucVu.TenChucVu = data.TenChucVu;
            ChucVu.MaChucVu = data.MaChucVu;
            ChucVu.GhiChu = data.GhiChu;
            ChucVu.KeyWord = data.KeyWord;
            return ChucVu;
        }

        public CHUCVU dbMapper(ModelChucVu data, CHUCVU ChucVu)
        {
            ChucVu.ID = data.ID;
            ChucVu.TenChucVu = data.TenChucVu;
            ChucVu.MaChucVu = data.MaChucVu;
            ChucVu.GhiChu = data.GhiChu;
            ChucVu.KeyWord = data.KeyWord;
            return ChucVu;
        }

        public List<ModelChucVu> listMapper(List<CHUCVU> listData, List<ModelChucVu> listChucVu)
        {
            foreach (var data in listData)
            {
                ModelChucVu ChucVu = new ModelChucVu();
                rowMapper(data, ChucVu);
                listChucVu.Add(ChucVu);
            }
            return listChucVu;
        }
    }
}