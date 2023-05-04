using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IVanBanDiDAO
    {
        bool check(ModelVanBanDi vanBanDi);
        List<ModelVanBanDi> findAll();
        ModelVanBanDi findById(int id);
        List<ModelVanBanDi> findByCode(string code);
        void insert(ModelVanBanDi vanBanDi);
        void update(ModelVanBanDi vanBanDi, int id);
        void delete(int id);
        List<ModelLoaiVanBan> findLoaiVB(); 

    }
}
