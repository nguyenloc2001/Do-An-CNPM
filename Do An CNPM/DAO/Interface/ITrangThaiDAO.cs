using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface ITrangThaiDAO
    {
        bool check(ModelTrangThaiVanBan trangThai);
        List<ModelTrangThaiVanBan> findAll();
        ModelTrangThaiVanBan findById(int id);
        List<ModelTrangThaiVanBan> findByCode(string code);
        void insert(ModelTrangThaiVanBan trangThai);
        void update(ModelTrangThaiVanBan trangThai, int id);
        void delete(int id);
    }
}
