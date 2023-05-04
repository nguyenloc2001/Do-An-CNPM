using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Do_An_CNPM.DAO
{
    public class ChucVuDAO : IChucVuDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        ChucVuMapper mapper = new ChucVuMapper();
        
        public bool check(ModelChucVu chucVu)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.CHUCVUs select temp.MaChucVu.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(chucVu.MaChucVu));
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
                    CHUCVU model = dbContext.CHUCVUs.SingleOrDefault(x => x.ID == id);
                    dbContext.CHUCVUs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelChucVu> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<CHUCVU> listDB = (from temp in dbContext.CHUCVUs select temp).ToList();
                    List<ModelChucVu> listData = new List<ModelChucVu>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelChucVu> findByCode(string code)
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
                    List<CHUCVU> listDB = new List<CHUCVU>();
                    var model = from temp in dbContext.CHUCVUs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelChucVu> listData = new List<ModelChucVu>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelChucVu findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    CHUCVU model = dbContext.CHUCVUs.SingleOrDefault(x => x.ID == id);
                    ModelChucVu ChucVu = new ModelChucVu();
                    mapper.rowMapper(model, ChucVu);
                    return ChucVu;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelChucVu chucVu)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    CHUCVU temp = new CHUCVU();
                    mapper.dbMapper(chucVu, temp);
                    if (!String.IsNullOrEmpty(temp.TenChucVu))
                    {
                        sb.Append(temp.TenChucVu.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaChucVu))
                    {
                        sb.Append(temp.MaChucVu.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.CHUCVUs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelChucVu chucVu, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    /*CHUCVU temp = new CHUCVU();
                    mapper.dbMapper(ChucVu, temp);
                    var model = dbContext.CHUCVUs.SingleOrDefault(x => x.ID == id);
                    model.ID = temp.ID;
                    model.TenChucVu = temp.TenChucVu;
                    model.MaChucVu = temp.MaChucVu;
                    model.GhiChu = temp.GhiChu;*/

                    CHUCVU model = dbContext.CHUCVUs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(chucVu, model);
                    if (!String.IsNullOrEmpty(chucVu.TenChucVu))
                    {
                        sb.Append(chucVu.TenChucVu.ToString());
                    }
                    if (!String.IsNullOrEmpty(chucVu.MaChucVu))
                    {
                        sb.Append(chucVu.MaChucVu.ToString());
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

    public interface IChucVuDAO
    {
    }
}