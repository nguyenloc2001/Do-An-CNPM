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
    public class CongViecDAO : ICongViecDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        CongViecMapper mapper = new CongViecMapper();

        public bool check(ModelCongViec congViec)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.CONGVIECs select temp.MaCongViec.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(congViec.MaCongViec));
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
                    CONGVIEC model = dbContext.CONGVIECs.SingleOrDefault(x => x.ID == id);
                    dbContext.CONGVIECs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelCongViec> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<CONGVIEC> listDB = (from temp in dbContext.CONGVIECs select temp).ToList();
                    List<ModelCongViec> listData = new List<ModelCongViec>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelCongViec> findByCode(string code)
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
                    List<CONGVIEC> listDB = new List<CONGVIEC>();
                    var model = from temp in dbContext.CONGVIECs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelCongViec> listData = new List<ModelCongViec>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelCongViec findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    CONGVIEC model = dbContext.CONGVIECs.SingleOrDefault(x => x.ID == id);
                    ModelCongViec CONGVIEC = new ModelCongViec();
                    mapper.rowMapper(model, CONGVIEC);
                    return CONGVIEC;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelCongViec congViec)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    CONGVIEC temp = new CONGVIEC();
                    mapper.dbMapper(congViec, temp);
                    if (!string.IsNullOrEmpty(congViec.TenCongViec))
                    {
                        sb.Append(congViec.TenCongViec.ToString());
                    }
                    if (!string.IsNullOrEmpty(congViec.MaCongViec))
                    {
                        sb.Append(congViec.MaCongViec.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.CONGVIECs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelCongViec congViec, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    CONGVIEC model = dbContext.CONGVIECs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(congViec, model);
                    if (!String.IsNullOrEmpty(congViec.TenCongViec))
                    {
                        sb.Append(congViec.TenCongViec.ToString());
                    }
                    if (!String.IsNullOrEmpty(congViec.MaCongViec))
                    {
                        sb.Append(congViec.MaCongViec.ToString());
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

    public interface ICongViecDAO
    {
    }
}