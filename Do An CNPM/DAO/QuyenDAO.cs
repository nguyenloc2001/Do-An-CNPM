using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Do_An_CNPM.DAO
{
    public class QuyenDAO : IQuyenHanDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        QuyenHanMapper mapper = new QuyenHanMapper();

        public bool check(ModelQuyenHan quyenHan)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.QUYENHANs select temp.MaQuyen.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(quyenHan.MaQuyen));
                if (isMore > 0)
                {
                    check = true;
                }
                return check;
            }
        }

        public void delete(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    PHONGBAN model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID == id);
                    dbContext.PHONGBANs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelQuyenHan> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<QUYENHAN> listDB = (from temp in dbContext.QUYENHANs select temp).ToList();
                    List<ModelQuyenHan> listData = new List<ModelQuyenHan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelQuyenHan> findByCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                InsertKeyWord insertKeyWord = new InsertKeyWord();
                code = insertKeyWord.RemoveUnicode(code.ToString());
            }
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<QUYENHAN> listDB = new List<QUYENHAN>();
                    var model = from temp in dbContext.QUYENHANs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelQuyenHan> listData = new List<ModelQuyenHan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelQuyenHan findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    QUYENHAN model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID == id);
                    ModelQuyenHan phongBan = new ModelQuyenHan();
                    mapper.rowMapper(model, phongBan);
                    return phongBan;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelQuyenHan quyenHan)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    QUYENHAN temp = new QUYENHAN();
                    mapper.dbMapper(quyenHan, temp);
                    if (!String.IsNullOrEmpty(temp.TenQuyenHan))
                    {
                        sb.Append(temp.TenQuyenHan.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaQuyen))
                    {
                        sb.Append(temp.MaQuyen.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.QUYENHANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelQuyenHan quyenHan, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    QUYENHAN model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(quyenHan, model);
                    if (!String.IsNullOrEmpty(quyenHan.TenQuyenHan))
                    {
                        sb.Append(quyenHan.TenQuyenHan.ToString());
                    }
                    if (!String.IsNullOrEmpty(quyenHan.MaQuyen))
                    {
                        sb.Append(quyenHan.MaQuyen.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    model.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}