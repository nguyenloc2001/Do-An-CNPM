using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_CNPM.DAO.Interface
{
    internal interface IQuyenHanDAO
    {
        bool check(ModelQuyenHan quyenHan);
        List<ModelQuyenHan> findAll();
        ModelQuyenHan findById(int id);
        List<ModelQuyenHan> findByCode(string code);
        void insert(ModelQuyenHan quyenHan);
        void update(ModelQuyenHan quyenHan, int id);
        void delete(int id);
    }
}
