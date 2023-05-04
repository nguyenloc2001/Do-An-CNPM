using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface INguoiDungDAO
    {
        bool check(ModelNguoiDung nguoiDung);
        List<ModelNguoiDung> findAll();
        ModelNguoiDung findById(int id);
        List<ModelNguoiDung> findByCode(string code);
        void insert(ModelNguoiDung nguoiDung);
        void update(ModelNguoiDung nguoiDung, int id);
        void delete(int id);
    }
}
