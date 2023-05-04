using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models.Model;
using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Do_An_CNPM.DAO
{
    public class NguoiDungDAO : INguoiDungDAO
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        NguoiDungMapper mapper = new NguoiDungMapper();

        public bool check(ModelNguoiDung nguoiDung)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                bool check = false;
                var data = (from temp in dbContext.NGUOIDUNGs select temp.MaNhanVien.ToString()).ToList();
                var isMore = data.Count(s => s.Contains(nguoiDung.MaNhanVien));
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
                    NGUOIDUNG model = dbContext.NGUOIDUNGs.SingleOrDefault(x => x.ID == id);
                    dbContext.NGUOIDUNGs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insert(ModelNguoiDung nguoiDung)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    NGUOIDUNG temp = new NGUOIDUNG();
                    mapper.dbMapper(nguoiDung, temp);
                    if (!String.IsNullOrEmpty(temp.MaNhanVien))
                    {
                        sb.Append(temp.MaNhanVien.ToString());
                    }
                    if (!String.IsNullOrEmpty(temp.HoVaTen))
                    {
                        sb.Append(temp.HoVaTen.ToString());
                    }
                    InsertKeyWord insertKeyWord = new InsertKeyWord();
                    temp.KeyWord = insertKeyWord.RemoveUnicode(sb.ToString());
                    dbContext.NGUOIDUNGs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(ModelNguoiDung nguoiDung, int id)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    NGUOIDUNG model = dbContext.NGUOIDUNGs.SingleOrDefault(x => x.ID == id);
                    mapper.dbMapper(nguoiDung, model);
                    if (!String.IsNullOrEmpty(nguoiDung.MaNhanVien))
                    {
                        sb.Append(nguoiDung.MaNhanVien.ToString());
                    }
                    if (!String.IsNullOrEmpty(nguoiDung.HoVaTen))
                    {
                        sb.Append(nguoiDung.HoVaTen.ToString());
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

        public List<ModelNguoiDung> findAll()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<NGUOIDUNG> listDB = (from temp in dbContext.NGUOIDUNGs select temp).ToList();
                    List<ModelNguoiDung> listData = new List<ModelNguoiDung>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ModelNguoiDung> findByCode(string code)
        {
            string tempText = " ";
            if (!string.IsNullOrEmpty(code))
            {
                InsertKeyWord insertKeyWord = new InsertKeyWord();
                tempText = insertKeyWord.RemoveUnicode(code.ToString());
            }
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    List<NGUOIDUNG> listDB = new List<NGUOIDUNG>();
                    var model = from temp in dbContext.NGUOIDUNGs select temp;
                    if (!String.IsNullOrEmpty(tempText))
                    {
                        model = model.Where(s => s.KeyWord.Contains(tempText));
                    }
                    listDB = model.ToList();
                    List<ModelNguoiDung> listData = new List<ModelNguoiDung>();
                    mapper.listMapper(listDB, listData);
                    return listData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelNguoiDung findById(int id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    NGUOIDUNG model = dbContext.NGUOIDUNGs.SingleOrDefault(x => x.ID == id);
                    ModelNguoiDung nguoiDung = new ModelNguoiDung();
                    mapper.rowMapper(model, nguoiDung);
                    return nguoiDung;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}