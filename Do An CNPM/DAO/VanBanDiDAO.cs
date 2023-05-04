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

namespace Do_An_CNPM.DAO
{
    public class VanBanDiDAO : IVanBanDiDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        VanBanDiMapper mapper = new VanBanDiMapper();
        public bool check(ModelVanBanDi vanBanDi)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.VANBANDIs select temp.MaVanBan.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(vanBanDi.MaVanBan));
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
                    VANBANDI model = dbContext.VANBANDIs.SingleOrDefault(x => x.ID == id);
                    dbContext.VANBANDIs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelVanBanDi> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<VANBANDI> listDB = (from temp in dbContext.VANBANDIs select temp).ToList();
                    List<ModelVanBanDi> listData = new List<ModelVanBanDi>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelVanBanDi> findByCode(string code)
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
                    List<VANBANDI> listDB = new List<VANBANDI>();
                    var model = from temp in dbContext.VANBANDIs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelVanBanDi> listData = new List<ModelVanBanDi>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelVanBanDi findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    VANBANDI model = dbContext.VANBANDIs.SingleOrDefault(x => x.ID == id);
                    ModelVanBanDi phongBan = new ModelVanBanDi();
                    mapper.rowMapper(model, phongBan);
                    return phongBan;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelLoaiVanBan> findLoaiVB()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<ModelLoaiVanBan> lists = new List<ModelLoaiVanBan>();
                    var loaiVanBan = (from loai in dbContext.LOAIVANBANs select new { ID = loai.ID, TenLoaiVanBan = loai.TenLoaiVanBan }).ToList();
                    foreach (var loai in loaiVanBan)
                    {
                        ModelLoaiVanBan LVB = new ModelLoaiVanBan();
                        LVB.ID = loai.ID;
                        LVB.TenLoaiVanBan = loai.TenLoaiVanBan;
                        lists.Add(LVB);
                    }
                    return lists;
                }
            }catch (Exception ex) { throw ex; }
            
        }

        public void insert(ModelVanBanDi vanBanDi)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                { 
                    VANBANDI temp = new VANBANDI();
                    mapper.dbMapper(vanBanDi, temp);
                    if (!String.IsNullOrEmpty(temp.TrichYeu))
                    {
                        sb.Append(temp.TrichYeu.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaVanBan))
                    {
                        sb.Append(temp.MaVanBan.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.VANBANDIs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelVanBanDi vanBanDi, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    VANBANDI model = dbContext.VANBANDIs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(vanBanDi, model);

                    if (!String.IsNullOrEmpty(vanBanDi.TrichYeu))
                    {
                        sb.Append(vanBanDi.TrichYeu.ToString());
                    }
                    if (!String.IsNullOrEmpty(vanBanDi.MaVanBan))
                    {
                        sb.Append(vanBanDi.MaVanBan.ToString());
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