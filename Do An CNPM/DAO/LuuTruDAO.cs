using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.DAO
{
    public class LuuTruDAO : ILuuTruDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        LuuTruMapper mapper = new LuuTruMapper();
        public bool check(ModelLuuTru luuTru)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.LUUTRUs select temp.MaLuuTru.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(luuTru.MaLuuTru));
                if (isMore > 0)
                {
                    check = true;
                }
                return check;
            }
        }
        public Dictionary<string,string> getKieuLuu()
        {
            Dictionary<string,string> lists = new Dictionary<string, string>()
            {
                ["Offline"] = "Offline",
                ["Online"] = "Online",
                ["Offline va Online"] = "Offline va Online",
            };
            return lists;
        }
        public void delete(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LUUTRU model = dbContext.LUUTRUs.SingleOrDefault(x => x.ID == id);
                    dbContext.LUUTRUs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelLuuTru> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<LUUTRU> listDB = (from temp in dbContext.LUUTRUs select temp).ToList();
                    List<ModelLuuTru> listData = new List<ModelLuuTru>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelLuuTru> findByCode(string code)
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
                    List<LUUTRU> listDB = new List<LUUTRU>();
                    var model = from temp in dbContext.LUUTRUs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelLuuTru> listData = new List<ModelLuuTru>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelLuuTru findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LUUTRU model = dbContext.LUUTRUs.SingleOrDefault(x => x.ID == id);
                    ModelLuuTru luuTru = new ModelLuuTru();
                    mapper.rowMapper(model, luuTru);
                    return luuTru;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelLuuTru luuTru)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LUUTRU temp = new LUUTRU();
                    mapper.dbMapper(luuTru, temp);
                    if (!String.IsNullOrEmpty(temp.TenLuuTru))
                    {
                        sb.Append(temp.TenLuuTru.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.MaLuuTru))
                    {
                        sb.Append(temp.MaLuuTru.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.LUUTRUs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelLuuTru luuTru, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LUUTRU model = dbContext.LUUTRUs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(luuTru, model);
                    if (!String.IsNullOrEmpty(luuTru.TenLuuTru))
                    {
                        sb.Append(luuTru.TenLuuTru.ToString());
                    }
                    if (!String.IsNullOrEmpty(luuTru.MaLuuTru))
                    {
                        sb.Append(luuTru.MaLuuTru.ToString());
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