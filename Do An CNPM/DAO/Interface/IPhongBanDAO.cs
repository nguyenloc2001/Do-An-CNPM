using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IPhongBanDAO
    {
        bool check(ModelPhongBan phongBan);
        List<ModelPhongBan> findAll();
        ModelPhongBan findById(int id);
        List<ModelPhongBan> findByCode(string code);
        void insert(ModelPhongBan phongBan);
        void update(ModelPhongBan phongBan, int id);
        void delete(int id);
    }
}