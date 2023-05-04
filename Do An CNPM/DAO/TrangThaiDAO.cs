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
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Do_An_CNPM.DAO
{
    public class TrangThaiDAO : ITrangThaiDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        TrangThaiVanBanMapper mapper = new TrangThaiVanBanMapper();
        public bool check(ModelTrangThaiVanBan trangThai)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.TRANGTHAIVANBANs select temp.MaTrangThai.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(trangThai.MaTrangThai));
                if (isMore > 0)
                {
                    check = true;
                }
                return check;
            }
        }
        public List<ModelTrangThaiVanBan> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<TRANGTHAIVANBAN> listDB = (from temp in dbContext.TRANGTHAIVANBANs select temp).ToList();
                    List<ModelTrangThaiVanBan> listData = new List<ModelTrangThaiVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelTrangThaiVanBan> findByCode(string code)
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
                    List<TRANGTHAIVANBAN> listDB = new List<TRANGTHAIVANBAN>();
                    var model = from temp in dbContext.TRANGTHAIVANBANs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelTrangThaiVanBan> listData = new List<ModelTrangThaiVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelTrangThaiVanBan findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    TRANGTHAIVANBAN model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID == id);
                    ModelTrangThaiVanBan trangThai = new ModelTrangThaiVanBan();
                    mapper.rowMapper(model, trangThai);
                    return trangThai;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insert(ModelTrangThaiVanBan trangThai)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    TRANGTHAIVANBAN temp = new TRANGTHAIVANBAN();
                    mapper.dbMapper(trangThai, temp);
                    if (!String.IsNullOrEmpty(temp.TenTrangThai))
                    {
                        sb.Append(temp.TenTrangThai.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaTrangThai))
                    {
                        sb.Append(temp.MaTrangThai.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.TRANGTHAIVANBANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(ModelTrangThaiVanBan trangThai, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    TRANGTHAIVANBAN model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(trangThai, model);
                    if (!String.IsNullOrEmpty(trangThai.TenTrangThai))
                    {
                        sb.Append(trangThai.TenTrangThai.ToString());
                    }
                    if (!String.IsNullOrEmpty(trangThai.MaTrangThai))
                    {
                        sb.Append(trangThai.MaTrangThai.ToString());
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
        public void delete(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    TRANGTHAIVANBAN model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID == id);
                    dbContext.TRANGTHAIVANBANs.DeleteOnSubmit(model);
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