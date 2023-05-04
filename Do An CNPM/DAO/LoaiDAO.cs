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
    public class LoaiDAO : ILoaiDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        LoaiVanBanMapper mapper = new LoaiVanBanMapper();
        public bool check(ModelLoaiVanBan loai)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.LOAIVANBANs select temp.MaLoaiVanBan.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(loai.MaLoaiVanBan));
                if (isMore > 0)
                {
                    check = true;
                }
                return check;
            }
        }
        public bool check(string code)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var model = (from ma in dbContext.LOAIVANBANs select ma.MaLoaiVanBan).ToList();
                    bool checkMa = false ;
                    foreach (var item in model)
                    {
                        if (item.Contains(code))
                        {
                            checkMa = true ;
                            break;
                        }
                    }
                    return checkMa;
                }
                    
            }catch (Exception ex)
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
                    LOAIVANBAN model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID == id);
                    dbContext.LOAIVANBANs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelLoaiVanBan> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<LOAIVANBAN> listDB = (from temp in dbContext.LOAIVANBANs orderby temp.ID select temp).ToList(); ;
                    List<ModelLoaiVanBan> listData = new List<ModelLoaiVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelLoaiVanBan> findByCode(string code)
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
                    List<LOAIVANBAN> listDB = new List<LOAIVANBAN>();
                    var model = from temp in dbContext.LOAIVANBANs select temp;
                    if (!String.IsNullOrEmpty(code))
                    {
                        model = model.Where(s => s.KeyWord.Contains(code));
                    }
                    listDB = model.ToList();
                    List<ModelLoaiVanBan> listData = new List<ModelLoaiVanBan>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelLoaiVanBan findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LOAIVANBAN model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID == id);
                    ModelLoaiVanBan loaiVanBan = new ModelLoaiVanBan();
                    mapper.rowMapper(model, loaiVanBan);
                    return loaiVanBan;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelLoaiVanBan loai)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LOAIVANBAN temp = new LOAIVANBAN();
                    mapper.dbMapper(loai, temp);
                    if (!string.IsNullOrEmpty(loai.TenLoaiVanBan))
                    {
                        sb.Append(loai.TenLoaiVanBan.ToString());
                    }
                    if (!string.IsNullOrEmpty(loai.MaLoaiVanBan))
                    {
                        sb.Append(loai.MaLoaiVanBan.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.LOAIVANBANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                /*throw ex;*/
            }
        }

        public void update(ModelLoaiVanBan loai, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    LOAIVANBAN model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(loai, model);
                    if (!String.IsNullOrEmpty(loai.TenLoaiVanBan))
                    {
                        sb.Append(loai.TenLoaiVanBan.ToString());
                    }
                    if (!String.IsNullOrEmpty(loai.MaLoaiVanBan))
                    {
                        sb.Append(loai.MaLoaiVanBan.ToString());
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