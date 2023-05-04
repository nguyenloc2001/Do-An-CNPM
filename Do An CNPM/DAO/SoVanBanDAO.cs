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
    public class SoVanBanDAO : ISoVanBanDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        SoVanBanMapper mapper = new SoVanBanMapper();
        public bool check(ModelSoVanBan soVanBan)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.SOVANBANs select temp.MaSoVanBan.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(soVanBan.MaSoVanBan));
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
                    SOVANBAN model = dbContext.SOVANBANs.SingleOrDefault(x => x.ID == id);
                    dbContext.SOVANBANs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelSoVanBan> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<SOVANBAN> listDB = (from temp in dbContext.SOVANBANs select temp).ToList();
                    List<ModelSoVanBan> listData = new List<ModelSoVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelSoVanBan> findByCode(string code)
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
                    List<SOVANBAN> listDB = new List<SOVANBAN>();
                    var model = from temp in dbContext.SOVANBANs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelSoVanBan> listData = new List<ModelSoVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelSoVanBan findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    SOVANBAN model = dbContext.SOVANBANs.SingleOrDefault(x => x.ID == id);
                    ModelSoVanBan phongBan = new ModelSoVanBan();
                    mapper.rowMapper(model, phongBan);
                    return phongBan;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelSoVanBan soVanBan)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    SOVANBAN temp = new SOVANBAN();
                    mapper.dbMapper(soVanBan, temp);
                    if (!String.IsNullOrEmpty(temp.TenSoVanBan))
                    {
                        sb.Append(temp.TenSoVanBan.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaSoVanBan))
                    {
                        sb.Append(temp.MaSoVanBan.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.SOVANBANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelSoVanBan soVanBan, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    SOVANBAN model = dbContext.SOVANBANs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(soVanBan, model);
                    if (!String.IsNullOrEmpty(soVanBan.TenSoVanBan))
                    {
                        sb.Append(soVanBan.TenSoVanBan.ToString());
                    }
                    if (!String.IsNullOrEmpty(soVanBan.MaSoVanBan))
                    {
                        sb.Append(soVanBan.MaSoVanBan.ToString());
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