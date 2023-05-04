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
    public class VanBanDenDAO : IVanBanDenDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        VanBanDenMapper mapper = new VanBanDenMapper();

        public bool check(ModelVanBanDen vanBanDen)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.VANBANDENs select temp.MaVanBan.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(vanBanDen.MaVanBan));
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
                    VANBANDEN model = dbContext.VANBANDENs.SingleOrDefault(x => x.ID == id);
                    dbContext.VANBANDENs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelVanBanDen> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<VANBANDEN> listDB = (from temp in dbContext.VANBANDENs select temp).ToList();
                    List<ModelVanBanDen> listData = new List<ModelVanBanDen>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelVanBanDen> findByCode(string code)
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
                    List<VANBANDEN> listDB = new List<VANBANDEN>();
                    var model = from temp in dbContext.VANBANDENs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelVanBanDen> listData = new List<ModelVanBanDen>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelVanBanDen findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    VANBANDEN model = dbContext.VANBANDENs.SingleOrDefault(x => x.ID == id);
                    ModelVanBanDen phongBan = new ModelVanBanDen();
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
                    var loaiVanBan = from loai in dbContext.LOAIVANBANs select new { ID = loai.ID, TenLoaiVanBan = loai.TenLoaiVanBan };
                    foreach (var loai in loaiVanBan)
                    {
                        ModelLoaiVanBan LVB = new ModelLoaiVanBan();
                        LVB.ID = loai.ID;
                        LVB.TenLoaiVanBan = loai.TenLoaiVanBan;
                        lists.Add(LVB);
                    }
                    return lists;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void insert(ModelVanBanDen vanBanDen)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    VANBANDEN temp = new VANBANDEN();
                    mapper.dbMapperNotID(vanBanDen, temp);
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
                    dbContext.VANBANDENs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelVanBanDen vanBanDen, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    VANBANDEN model = dbContext.VANBANDENs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(vanBanDen, model);

                    if (!String.IsNullOrEmpty(vanBanDen.TrichYeu))
                    {
                        sb.Append(vanBanDen.TrichYeu.ToString());
                    }
                    if (!String.IsNullOrEmpty(vanBanDen.MaVanBan))
                    {
                        sb.Append(vanBanDen.MaVanBan.ToString());
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