using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IModelChucVuDAO
    {
        bool check(ModelChucVu chucVu);
        List<ModelChucVu> findAll();
        ModelChucVu findById(int id);
        List<ModelChucVu> findByCode(string code);
        void insert(ModelChucVu chucVu);
        void update(ModelChucVu chucVu, int id);
        void delete(int id);
    }
}
