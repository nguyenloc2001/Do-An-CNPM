using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface ISoVanBanDAO
    {
        bool check(ModelSoVanBan soVanBan);
        List<ModelSoVanBan> findAll();
        ModelSoVanBan findById(int id);
        List<ModelSoVanBan> findByCode(string code);
        void insert(ModelSoVanBan soVanBan);
        void update(ModelSoVanBan soVanBan, int id);
        void delete(int id);
    }
}
