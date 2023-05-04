using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IVanBanDenDAO
    {
        bool check(ModelVanBanDen vanBanDen);
        List<ModelVanBanDen> findAll();
        ModelVanBanDen findById(int id);
        List<ModelVanBanDen> findByCode(string code);
        void insert(ModelVanBanDen vanBanDen);
        void update(ModelVanBanDen vanBanDen, int id);
        void delete(int id);
        List<ModelLoaiVanBan> findLoaiVB();
    }
}
