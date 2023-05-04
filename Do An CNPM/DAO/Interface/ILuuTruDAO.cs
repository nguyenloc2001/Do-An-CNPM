using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface ILuuTruDAO
    {
        bool check(ModelLuuTru luuTru);
        List<ModelLuuTru> findAll();
        ModelLuuTru findById(int id);
        List<ModelLuuTru> findByCode(string code);
        void insert(ModelLuuTru luuTru);
        void update(ModelLuuTru luuTru, int id);
        void delete(int id);
    }
}
