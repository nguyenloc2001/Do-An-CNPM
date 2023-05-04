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
    public class PhongBanDAO : IPhongBanDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        PhongBanMapper mapper = new PhongBanMapper();
        public bool check(ModelPhongBan phongBan)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.PHONGBANs select temp.MaPhongBan.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(phongBan.MaPhongBan));
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

        public List<ModelPhongBan> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<PHONGBAN> listDB = (from temp in dbContext.PHONGBANs select temp).ToList();
                    List<ModelPhongBan> listData = new List<ModelPhongBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelPhongBan> findByCode(string code)
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
                    List<PHONGBAN> listDB = new List<PHONGBAN>();
                    var model = from temp in dbContext.PHONGBANs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelPhongBan> listData = new List<ModelPhongBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelPhongBan findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    PHONGBAN model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID == id);
                    ModelPhongBan phongBan = new ModelPhongBan();
                    mapper.rowMapper(model, phongBan);
                    return phongBan;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelPhongBan phongBan)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    phongBan.SoNhanVien = 0;
                    PHONGBAN temp = new PHONGBAN();
                    mapper.dbMapper(phongBan, temp);
                    temp.SoNhanVien = 0;
                    if (!String.IsNullOrEmpty(temp.TenPhongBan))
                    {
                        sb.Append(temp.TenPhongBan.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaPhongBan))
                    {
                        sb.Append(temp.MaPhongBan.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.PHONGBANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelPhongBan phongBan, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    PHONGBAN model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(phongBan, model);
                    if (!String.IsNullOrEmpty(phongBan.TenPhongBan))
                    {
                        sb.Append(phongBan.TenPhongBan.ToString());
                    }
                    if (!String.IsNullOrEmpty(phongBan.MaPhongBan))
                    {
                        sb.Append(phongBan.MaPhongBan.ToString());
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