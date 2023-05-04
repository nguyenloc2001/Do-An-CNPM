using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface ILoaiDAO
    {
        bool check(ModelLoaiVanBan loai);
        List<ModelLoaiVanBan> findAll();
        ModelLoaiVanBan findById(int id);
        List<ModelLoaiVanBan> findByCode(string code);
        void insert(ModelLoaiVanBan loai);
        void update(ModelLoaiVanBan loai, int id);
        void delete(int id);
        bool check(string code);
    }
}
