using Do_An_CNPM.DAO;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Models.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class TrangThaiVanBanController : Controller
    {
        // GET: TrangThaiVanBan
        TrangThaiDAO trangThaiDAO = new TrangThaiDAO();
        ModelTrangThaiVanBan trangThai = null;
        List<ModelTrangThaiVanBan> listTrangThai = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listTrangThai = trangThaiDAO.findAll();
            return View(listTrangThai);
        }

        public ActionResult Details(int id)
        {
            trangThai = trangThaiDAO.findById(id);
            return View(trangThai);
        }

        public ActionResult Create()
        {
            return View(new ModelTrangThaiVanBan());
        }

        [HttpPost]
        public ActionResult Create(ModelTrangThaiVanBan temp)
        {
            if (trangThaiDAO.check(temp))
            {
                ModelState.AddModelError("MaTrangThai", "Mã trạng thái đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                trangThaiDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            trangThai = trangThaiDAO.findById(id);
            return View(trangThai);
        }
        [HttpPost]
        public ActionResult Edit(ModelTrangThaiVanBan temp, int id)
        {
            if (trangThaiDAO.check(temp))
            {
                ModelState.AddModelError("MaTrangThai", "Mã trạng thái trùng với mã trạng thái khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                trangThaiDAO.update(temp, id);
                trangThai = trangThaiDAO.findById(id);
                return View(trangThai);
            }
        }
        public ActionResult Delete(int id)
        {
            trangThai = trangThaiDAO.findById(id);
            return View(trangThai);
        }

        [HttpPost]
        public ActionResult Delete(ModelTrangThaiVanBan temp ,int id)
        {
            trangThaiDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            trangThaiDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listTrangThai = trangThaiDAO.findByCode(text);
            return View(listTrangThai);
        }

        /*public ActionResult Tao()
        {
            return View(new IModelTrangThaiVanBan());
        }
        [HttpPost]
        public ActionResult Tao(IModelTrangThaiVanBan temp)
        {
            StringBuilder sb = new StringBuilder();



            //check model isvalid == true
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            try
            {
                if (string.IsNullOrEmpty(temp.TenTrangThai))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(temp);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
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
                    TRANGTHAIVANBAN temp = new TRANGTHAIVANBAN();
                    *//*temp.ID = temp.ID;
                    temp.TenTrangThai = temp.TenTrangThai;
                    temp.MaTrangThai = temp.MaTrangThai;
                    temp.GhiChu = temp.GhiChu;
                    temp.KeyWord = temp.KeyWord;*//*
                    temp = mapper.rowMapper(temp);
                    dbContext.TRANGTHAIVANBANs.InsertOnSubmit(temp);
                    dbContext.SubmitChanges();
                    return View(temp);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return base.View();
            }
        }*/
    }
}