using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IModelCongViecDAO
    {
        bool check(ModelCongViec congViec);
        List<ModelCongViec> findAll();
        ModelCongViec findById(int id);
        List<ModelCongViec> findByCode(string code);
        void insert(ModelCongViec congViec);
        void update(ModelCongViec congViec, int id);
        void delete(int id);
    }
}
